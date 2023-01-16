using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Json;
using Abp.Linq.Extensions;
using Abp.UI;
using Abp.Web.Models;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using YuanTu.Platform.Dept;
using YuanTu.Platform.Dept.Dto;
using YuanTu.Platform.Health;
using YuanTu.Platform.Health.Dto;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.Organizations;
using YuanTu.Platform.POS;
using YuanTu.Platform.ST.Dto;
using YuanTu.Platform.Sys;
using YuanTu.Platform.Sys.Dto;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTerminalAppService : AsynPermissionAppService<STTerminal, STTerminalDto, string, PagedSTTerminalRequestDto, STTerminalDto, STTerminalDto>, ISTTerminalAppService
    {
        protected IHttpContextAccessor httpContext;
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;
        private readonly IRepository<STTerminalPart, string> _repositoryPart;
        private readonly IRepository<STTerminalPlugin, string> _repositoryPlugin;
        private readonly IRepository<STTerminalPluginNet, string> _repositoryPluginNet;
        private readonly IRepository<STTemplatePart, string> _repositoryTPart;
        private readonly IRepository<STTemplatePlugin, string> _repositoryTPlugin;
        private readonly IRepository<STTemplatePluginNet, string> _repositoryTPluginNet;
        private readonly IRepository<AbpWardArea, string> _repositoryAbpWardArea;
        private readonly IRepository<STPluginFileVersion, string> _repositoryFileVersion;
        private readonly IRepository<HealthConfig, string> _repositoryHConfig;
        private readonly IRepository<AbpOrg, long> _repositoryAbpOrg;
        private readonly IRepository<AbpCustomEnum, string> _repositoryAbpCustomEnum;
        private readonly IRepository<PosConfig, string> _repositoryPosConfig;
        private readonly IRepository<STTemplateCustomEnum, string> _repositoryTCustomEnum;
        private readonly IRepository<STTerminalCustomEnum, string> _repositoryCustomEnum;
        private readonly IRepository<STTerminalDeptMap, string> _repositorySTTerminalDeptMap;


        public STTerminalAppService(IHttpContextAccessor httpContextAccessor, IRepository<STTerminal, string> repository, IRepository<STTerminalPart, string> repositoryPart, IRepository<STTerminalPlugin, string> repositoryPlugin, IRepository<STTerminalPluginNet, string> repositoryPluginNet, IRepository<STTemplatePart, string> repositoryTPart, IRepository<STTemplatePlugin, string> repositoryTPlugin, IRepository<STTemplatePluginNet, string> repositoryTPluginNet, IRepository<AbpWardArea, string> repositoryAbpWardArea, IRepository<STPluginFileVersion, string> repositoryFileVersion, IRepository<HealthConfig, string> repositoryHConfig, IRepository<AbpOrg, long> repositoryAbpOrg, IRepository<AbpCustomEnum, string> repositoryAbpCustomEnum, IRepository<PosConfig, string> repositoryPosConfig, IRepository<STTemplateCustomEnum, string> repositoryTCustomEnum, IRepository<STTerminalCustomEnum, string> repositoryCustomEnum, IRepository<STTerminalDeptMap, string> repositorySTTerminalDeptMap) : base(repository)
        {
            httpContext = httpContextAccessor;
            _repositorySTTerminal = repository;
            _repositoryPart = repositoryPart;
            _repositoryPlugin = repositoryPlugin;
            _repositoryPluginNet = repositoryPluginNet;
            _repositoryTPart = repositoryTPart;
            _repositoryTPlugin = repositoryTPlugin;
            _repositoryTPluginNet = repositoryTPluginNet;
            _repositoryAbpWardArea = repositoryAbpWardArea;
            _repositoryFileVersion = repositoryFileVersion;
            _repositoryHConfig = repositoryHConfig;
            _repositoryAbpOrg = repositoryAbpOrg;
            _repositoryAbpCustomEnum = repositoryAbpCustomEnum;
            _repositoryPosConfig = repositoryPosConfig;
            _repositoryTCustomEnum = repositoryTCustomEnum;
            _repositoryCustomEnum = repositoryCustomEnum;
            _repositorySTTerminalDeptMap = repositorySTTerminalDeptMap;
        }

        protected override IQueryable<STTerminal> CreateFilteredQuery(PagedSTTerminalRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Code.Contains(input.Keyword) || x.Name.Contains(input.Keyword) || x.BID.Contains(input.Keyword) || x.IP.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive)
                .WhereIf(input.IsPowerOn.HasValue, x => x.IsPowerOn == input.IsPowerOn)
                .WhereIf(input.CanbeAccess.HasValue, x => x.CanbeAccess == input.CanbeAccess)
                .WhereIf(!input.TerminalType.IsNullOrWhiteSpace(), x => x.TerminalTypeId.Equals(input.TerminalType))
                .WhereIf(!input.WardAreaId.IsNullOrWhiteSpace(), x => x.WardAreaId.Equals(input.WardAreaId))
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
        }

        [AbpAllowAnonymous]
        public async Task<List<STTerminalAbbrDto>> GetAllData()
        {
            return ObjectMapper.Map<List<STTerminalAbbrDto>>(await Repository.GetAllListAsync());
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<STTerminalDto>> GetAllAsync(PagedSTTerminalRequestDto input)
        {
            input.Sorting = "CreationTime,Sort";
            // input.IsActive ??= true;
            var list = await base.GetAllAsync(input);

            SetPluginVersion(input, list);

            if (input.Original != 1)
                await GetDtos(list.Items);
            return list;
        }

        private void SetPluginVersion(PagedSTTerminalRequestDto input, PagedResultDto<STTerminalDto> list)
        {
            if (input.ShowVersion == 1 && !string.IsNullOrWhiteSpace(input.PluginCode))
            {
                var ids = list.Items.Select(s => s.Id).ToList();
                var plugins =
                    _repositoryPlugin.GetAll().Where(s => ids.Contains(s.TermianlId) && s.PluginCode.Equals(input.PluginCode))
                    .OrderByDescending(s => s.CreationTime).ToList();
                if (plugins.Count > 0)
                    foreach (var info in list.Items)
                    {
                        var plugin = plugins.FirstOrDefault(s => s.TermianlId.Equals(info.Id));
                        info.Version = plugin?.Version;
                    }
            }
        }

        private async Task GetDtos(IEnumerable<STTerminalDto> infos)
        {
            var wardAreaList = await GetWardAreaList(infos);
            var configList = await GetHealthConfigList(infos);

            var terminalIds = infos.Select(s => s.Id).ToList();
            var parts = await _repositoryPart.GetAllListAsync(s => terminalIds.Contains(s.TermianlId));
            var plugins = await GetPlugins(terminalIds);
            var depts = await _repositorySTTerminalDeptMap.GetAllListAsync(s => terminalIds.Contains(s.TerminalId));

            foreach (var info in infos)
            {
                info.HealthConfig = ObjectMapper.Map<HealthConfigDto>(configList.Find(s => s.Id.Equals(info.HealthConfigId)));
                info.WardArea = ObjectMapper.Map<AbpWardAreaDto>(wardAreaList.Find(s => s.Id.Equals(info.WardAreaId)));
                info.Parts = ObjectMapper.Map<List<STTerminalPartDto>>(parts.Where(s => s.TermianlId.Equals(info.Id)));
                info.Plugins = plugins.Where(s => s.TermianlId.Equals(info.Id)).ToList();

                var m = depts.Find(s => info.Id == s.TerminalId);
                if (m != null)
                {
                    info.PriorityType = m.PriorityType;
                    info.PriorityTypeDept = m.PriorityTypeDept;
                    info.RestrictionType = m.RestrictionType;
                    info.RestrictionTypeDept = m.RestrictionTypeDept;
                }
            }
        }

        private async Task<List<STTerminalPluginDto>> GetPlugins(IEnumerable<string> terminalIds)
        {
            var plugins = await _repositoryPlugin.GetAllListAsync(s => terminalIds.Contains(s.TermianlId));
            var dto = ObjectMapper.Map<List<STTerminalPluginDto>>(plugins);
            var ids = dto.Select(s => s.Id);
            var list = await _repositoryPluginNet.GetAllListAsync(s => ids.Contains(s.PluginId));
            foreach (var pluginDto in dto)
            {
                pluginDto.NetList =
                    ObjectMapper.Map<List<STTerminalPluginNetDto>>(list.Where(s => s.PluginId.Equals(pluginDto.Id)));
            }

            return dto;
        }

        private async Task<List<HealthConfig>> GetHealthConfigList(IEnumerable<STTerminalDto> infos)
        {
            var configIds = infos.Where(s => !string.IsNullOrWhiteSpace(s.HealthConfigId))
                .Select(s => s.HealthConfigId);
            var configList = await _repositoryHConfig.GetAllListAsync(s => configIds.Contains(s.Id));
            return configList;
        }

        private async Task<List<AbpWardArea>> GetWardAreaList(IEnumerable<STTerminalDto> infos)
        {
            var wardAreaIds = infos.Where(s => !string.IsNullOrWhiteSpace(s.WardAreaId))
                .Select(s => s.WardAreaId);
            var wardAreaList = await _repositoryAbpWardArea.GetAllListAsync(s => wardAreaIds.Contains(s.Id));
            return wardAreaList;
        }

        private async Task GetHealthConfig(STTerminalDto info)
        {
            if (!string.IsNullOrWhiteSpace(info.HealthConfigId))
            {
                try
                {
                    var m = await _repositoryHConfig.GetAsync(info.HealthConfigId);
                    if (m != null) info.HealthConfig = ObjectMapper.Map<HealthConfigDto>(m);
                }
                catch (Exception e)
                {
                    Logger.Error(e.ToString());
                }
            }
        }

        private async Task GetWardArea(STTerminalDto info)
        {
            if (!string.IsNullOrWhiteSpace(info.WardAreaId))
            {
                try
                {
                    var m = await _repositoryAbpWardArea.GetAsync(info.WardAreaId);
                    if (m != null) info.WardArea = ObjectMapper.Map<AbpWardAreaDto>(m);
                }
                catch (Exception e)
                {
                    Logger.Error(e.ToString());
                }
            }
        }

        private async Task GetPartsAndPlugins(STTerminalDto info)
        {
            //配件
            info.Parts =
                ObjectMapper.Map<List<STTerminalPartDto>>(
                    await _repositoryPart.GetAllListAsync(s => s.TermianlId.Equals(info.Id)));
            //插件
            var plugins = await _repositoryPlugin.GetAllListAsync(s => s.TermianlId.Equals(info.Id));
            var dto = ObjectMapper.Map<List<STTerminalPluginDto>>(plugins);
            var ids = dto.Select(s => s.Id);
            var list = await _repositoryPluginNet.GetAllListAsync(s => ids.Contains(s.PluginId));
            foreach (var pluginDto in dto)
            {
                pluginDto.NetList = ObjectMapper.Map<List<STTerminalPluginNetDto>>(list.Where(s => s.PluginId.Equals(pluginDto.Id)));
            }

            info.Plugins = dto;
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<STTerminalDto>> GetAllListAsync()
        {
            var list = Repository.GetAll().Where(s => s.IsActive && s.CanbeAccess).OrderBy(s => s.CreationTime).ThenBy(s => s.Sort);
            var dto = ObjectMapper.Map<List<STTerminalDto>>(list);
            await GetDtos(dto);
            return await Task.FromResult(new ListResultDto<STTerminalDto>(dto));
        }

        public override async Task<STTerminalDto> GetAsync(EntityDto<string> input)
        {
            var info = await base.GetAsync(input);
            await GetWardArea(info);
            await GetHealthConfig(info);
            await GetPartsAndPlugins(info);
            return info;
        }

        public async Task<ListResultDto<object>> GetSimpleListAsync()
        {
            var list = Repository.GetAll().Where(s => s.IsActive && s.CanbeAccess).OrderBy(s => s.CreationTime)
                .ThenBy(s => s.Sort).Select(s => new
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    IP = s.IP
                });
            return await Task.FromResult(new ListResultDto<object>(list.ToList()));
        }

        [AbpAllowAnonymous]
        public async Task<STTerminalDto> GetByBIdAsync(string bid)
        {
            if (string.IsNullOrWhiteSpace(bid)) return null;
            var info = await Repository.FirstOrDefaultAsync(s => s.BID.Equals(bid));
            if (info == null) return null;
            var dto = MapToEntityDto(info);
            dto.Parts =
                ObjectMapper.Map<List<STTerminalPartDto>>(
                    await _repositoryPart.GetAllListAsync(s => s.TermianlId.Equals(info.Id)));
            return dto;
        }

        [AbpAllowAnonymous]
        public async Task<bool> ImportTemplateAsync(dynamic data)
        {
            string ids = data.ids;
            string templateId = data.templateId;
            string type = data.type;
            if (string.IsNullOrWhiteSpace(ids) || string.IsNullOrWhiteSpace(templateId)) return false;
            var arr = ids.Split(',');
            var list = await Repository.GetAllListAsync(s => arr.Contains(s.Id));
            foreach (var model in list)
            {
                model.TemplateId = templateId;

                await CopyDatas(templateId, model.Id, type);
                await Repository.UpdateAsync(model);
            }

            return true;
        }

        public async Task<bool> ImportHealthConfigAsync(dynamic data)
        {
            string ids = data.ids;
            string configId = data.configId;
            if (string.IsNullOrWhiteSpace(ids) || string.IsNullOrWhiteSpace(configId)) return false;
            var arr = ids.Split(',');
            var list = await Repository.GetAllListAsync(s => arr.Contains(s.Id));
            foreach (var model in list)
            {
                model.HealthConfigId = configId;
                await Repository.UpdateAsync(model);
            }

            return true;
        }

        public async Task<bool> ImportVoiceAsync([FromBody] STTerminalVoiceDto input)
        {
            if (input == null) return false;
            if (string.IsNullOrWhiteSpace(input.ids)) return false;
            var arr = input.ids.Split(',');
            var list = await Repository.GetAllListAsync(s => arr.Contains(s.Id));
            foreach (var model in list)
            {
                model.Rate = input.Rate;
                model.Volumn = input.Volumn;
                model.VoiceType = input.VoiceType;
                model.IsVoiceEnable = input.IsVoiceEnable;
                await Repository.UpdateAsync(model);
            }

            return true;
        }

        public async Task<bool> ImportEnumTemplateAsync(dynamic data)
        {
            string ids = data.ids, templateId = data.templateId, type = data.type;
            if (string.IsNullOrWhiteSpace(ids) || string.IsNullOrWhiteSpace(templateId)) return false;
            int orgId = data.orgId;
            var arr = ids.Split(',');

            List<STTerminalCustomEnum> list = null;
            //替换时删除原有项
            if ("3".Equals(type))
                await _repositoryCustomEnum.DeleteAsync(s => arr.Contains(s.TerminalId));
            else
                list = await _repositoryCustomEnum.GetAllListAsync(s => arr.Contains(s.TerminalId));

            var tempList = await _repositoryTCustomEnum.GetAllListAsync(s => templateId.Equals(s.TemplateId));

            var root = tempList.Find(s => string.IsNullOrWhiteSpace(s.ParentId));

            if (root == null) return false;

            foreach (var s in arr)
            {
                var copy = new STTerminalCustomEnum
                {
                    Id = CreateSequentialGuid(),
                    Code = root.Code,
                    Name = root.Name,
                    ParentId = root.ParentId,
                    ParentCode = root.ParentCode,
                    Sort = root.Sort,
                    OrgId = root.OrgId,
                    Remark = root.Remark,
                    Rule = root.Rule
                };
                var copyList = new List<STTerminalCustomEnum> { copy };

                SetTerminalEnumValue(root.Id, copy.Id, tempList, copyList);

                switch (type)
                {
                    case "1":
                        await Update(list, copyList, s);
                        break;
                    case "2":
                        await Append(list, copyList, s);
                        break;
                    case "3":
                        await Replace(copyList, s);
                        break;
                }
            }

            return true;
        }

        public async Task<bool> ExportEnumAsync(dynamic data)
        {
            string id = data.tid, templateId = data.templateId;
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(templateId)) return false;

            var list = await _repositoryCustomEnum.GetAllListAsync(s => id.Equals(s.TerminalId));

            var root = list.Find(s => string.IsNullOrWhiteSpace(s.ParentId));

            if (root == null) return false;

            var copy = CopyModel(root.ParentId, root);
            var copyList = new List<STTemplateCustomEnum> { copy };

            SetTemplateEnumValue(root.Id, copy.Id, list, copyList);

            foreach (var info in copyList)
            {
                info.TemplateId = templateId;
                await _repositoryTCustomEnum.InsertAsync(info);
            }

            return true;
        }

        private async Task Update(List<STTerminalCustomEnum> list, List<STTerminalCustomEnum> copyList, string s)
        {
            if (list == null || list.Count == 0)
            {
                await Replace(copyList, s);
            }
            else
            {
                var filterList = list.FindAll(t => s.Equals(t.TerminalId));
                foreach (var m in filterList)
                {
                    var n = copyList.Find(x => x.Code == m.Code && x.ParentCode == m.ParentCode);
                    if (n == null) continue;

                    m.Remark = n.Remark;
                    m.Rule = n.Rule;

                    await _repositoryCustomEnum.UpdateAsync(m);
                }

                await InsertExcludeInfo(copyList, s, filterList);
            }
        }

        private async Task Append(List<STTerminalCustomEnum> list, List<STTerminalCustomEnum> copyList, string s)
        {
            if (list == null || list.Count == 0)
            {
                await Replace(copyList, s);
            }
            else
            {
                var filterList = list.FindAll(t => s.Equals(t.TerminalId));
                await InsertExcludeInfo(copyList, s, filterList);
            }
        }

        private async Task InsertExcludeInfo(List<STTerminalCustomEnum> copyList, string s, List<STTerminalCustomEnum> filterList)
        {
            var a = filterList.Select(x => x.Code);
            foreach (var info in copyList.Where(x => !a.Contains(x.Code)))
            {
                var m = filterList.Find(x => x.Code == info.ParentCode);
                if (m != null) info.ParentId = m.Id;
                info.TerminalId = s;
                await _repositoryCustomEnum.InsertAsync(info);
            }
        }

        private async Task Replace(List<STTerminalCustomEnum> copyList, string s)
        {
            foreach (var info in copyList)
            {
                info.TerminalId = s;
                await _repositoryCustomEnum.InsertAsync(info);
            }
        }

        private void SetTerminalEnumValue(string oldPid, string newPid, List<STTemplateCustomEnum> list, List<STTerminalCustomEnum> copyList)
        {
            var ss = list.FindAll(s => s.ParentId.Equals(oldPid));
            foreach (var info in ss)
            {
                var copy = new STTerminalCustomEnum
                {
                    Id = CreateSequentialGuid(),
                    Code = info.Code,
                    Name = info.Name,
                    ParentId = newPid,
                    ParentCode = info.ParentCode,
                    Sort = info.Sort,
                    OrgId = info.OrgId,
                    Remark = info.Remark,
                    Rule = info.Rule
                };
                copyList.Add(copy);

                SetTerminalEnumValue(info.Id, copy.Id, list, copyList);
            }
        }

        private void SetTemplateEnumValue(string oldPid, string newPid, List<STTerminalCustomEnum> list, List<STTemplateCustomEnum> copyList)
        {
            var ss = list.FindAll(s => s.ParentId.Equals(oldPid));
            foreach (var info in ss)
            {
                var copy = CopyModel(newPid, info);
                copyList.Add(copy);

                SetTemplateEnumValue(info.Id, copy.Id, list, copyList);
            }
        }

        private STTemplateCustomEnum CopyModel(string newPid, STTerminalCustomEnum info)
        {
            var copy = new STTemplateCustomEnum
            {
                Id = CreateSequentialGuid(),
                Code = info.Code,
                Name = info.Name,
                ParentId = newPid,
                ParentCode = info.ParentCode,
                Sort = info.Sort,
                OrgId = info.OrgId,
                Remark = info.Remark,
                Rule = info.Rule
            };
            return copy;
        }

        public async Task<bool> ImportCashTypeAsync(dynamic data)
        {
            string ids = data.ids;
            string cashType = data.cashType;
            if (string.IsNullOrWhiteSpace(ids) || string.IsNullOrWhiteSpace(cashType)) return false;
            var arr = ids.Split(',');
            var parts = await _repositoryPart.GetAllListAsync(s => arr.Contains(s.TermianlId) && s.PartType.Equals("STCashBox"));
            if (parts == null || parts.Count == 0) return false;

            foreach (var part in parts)
            {
                var temp = part.JsonText.FromJsonString<dynamic>();
                temp["cashType"] = cashType;
                part.JsonText = JsonExtensions.ToJsonString(temp, true);
                await _repositoryPart.UpdateAsync(part);
            }

            return true;
        }

        public async Task<bool> BatchActiveAsync(dynamic data)
        {
            string ids = data.ids;
            string status = data.status;
            if (string.IsNullOrWhiteSpace(ids)) return false;
            var all = await Repository.GetAllListAsync();
            var arr = ids.Split(',');
            foreach (var id in arr)
            {
                var model = all.Find(s => s.Id.Equals(id));
                if (model == null) continue;

                if (all.Count(s => s.Code.Equals(model.Code) && s.OrgId == model.OrgId) > 1)
                    return false;
                model.IsActive = "1".Equals(status);
                model.CanbeAccess = true;
                model.DeviceSecret = id;

                if (model.HospitalCode.IsNullOrWhiteSpace() || model.HospitalId.IsNullOrWhiteSpace())
                {
                    var hosp = await _repositoryAbpOrg.FirstOrDefaultAsync(s => s.Id.Equals(model.OrgId));
                    if (hosp != null)
                    {
                        model.HospitalCode = hosp.Code;
                        model.HospitalId = hosp.HospitalId.ToString();
                    }
                }
                await Repository.UpdateAsync(model);
            }

            return true;
        }

        [AbpAllowAnonymous]
        public async Task<List<STTerminalExDto>> GetPluginFileList(string bid)
        {
            if (string.IsNullOrWhiteSpace(bid)) return null;
            var m = await Repository.FirstOrDefaultAsync(s => s.BID.Equals(bid));
            if (m == null) return null;
            var result = new List<STTerminalExDto>();
            var versions = await _repositoryFileVersion.GetAllListAsync();
            var nets = await _repositoryPluginNet.GetAllListAsync(s => s.TermianlId.Equals(m.Id));
            var plugins = await _repositoryPlugin.GetAllListAsync(s => s.TermianlId.Equals(m.Id) && s.Enabled);
            foreach (var plugin in plugins)
            {
                var info = ObjectMapper.Map<STTerminalExDto>(plugin);
                info.Nets = nets.Where(s => s.PluginId.Equals(plugin.Id)).Select(s => new { s.Port, s.NetType });

                var file = versions.FirstOrDefault(s => s.Id.Equals(plugin.VersionId));
                if (file != null && !string.IsNullOrWhiteSpace(file.JsonText))
                {
                    var list = file.JsonText.FromJsonString<STPluginDirectoryDto>()?.Children;
                    SetFullPath(list);

                    info.List = list;
                    info.Path = file.Path;
                    info.Args = file.Args;
                    info.Type = string.IsNullOrWhiteSpace(file.PluginType) ? "none" : file.PluginType;
                    info.Remark = file.Remark;
                    info.AbsolutePath = file.AbsolutePath;
                }
                result.Add(info);
            }
            return result;
        }

        private void SetFullPath(List<STPluginDirectoryDto> list)
        {
            if (list == null) return;

            foreach (var d in list)
            {
                if (!string.IsNullOrWhiteSpace(d.FileId) && !string.IsNullOrWhiteSpace(d.HashCode) && !string.IsNullOrWhiteSpace(d.Path))
                    d.Path =
                        $"{httpContext.HttpContext.Request.Scheme}://{httpContext.HttpContext.Request.Host}/{Path.Combine(d.Path, $"{d.HashCode}{Path.GetExtension(d.Name)}").Replace(@"\", "/")}";

                SetFullPath(d.Children);
            }
        }

        [AbpAllowAnonymous]
        public async Task<List<STTerminalPartDto>> GetPartFileList(string bid)
        {
            if (string.IsNullOrWhiteSpace(bid)) return null;
            var m = await Repository.FirstOrDefaultAsync(s => s.BID.Equals(bid));
            if (m == null) return null;

            var parts = await _repositoryPart.GetAllListAsync(s => s.TermianlId.Equals(m.Id));
            return ObjectMapper.Map<List<STTerminalPartDto>>(parts);
        }

        [AbpAllowAnonymous, HttpGet, HttpPost]
        public async Task<STHardwareInfoDto> GetHardwareInfo(string bid)
        {
            if (string.IsNullOrWhiteSpace(bid)) return null;
            var m = await Repository.FirstOrDefaultAsync(s => s.BID.Equals(bid));
            if (m == null) return null;

            var ret = ObjectMapper.Map<STHardwareInfoDto>(m);

            await GetParts(m, ret);
            await GetPlugins(m, ret);
            await GetHospital(m, ret);
            await GetPosConfigs(m, ret);
            await GetPatientCard(ret);

            return ret;
        }

        private async Task GetPatientCard(STHardwareInfoDto ret)
        {
            var card = (await _repositoryAbpCustomEnum.GetAllListAsync(s => s.ParentCode.Equals("PatientCard")))?.ToDictionary(s => s.Code.ToCamelCase(), s => s.Remark);
            ret.PatientCard = card;
        }

        private async Task GetParts(STTerminal m, STHardwareInfoDto ret)
        {
            var parts = await _repositoryPart.GetAllListAsync(s => s.TermianlId.Equals(m.Id));
            if (parts != null)
            {
                ret.HardwareInfo = new STHardwareInfo
                {
                    CardReaders = GetCardTypeList(parts, "STCardReader"),
                    Cameras = GetCardTypeList(parts, "STCamera"),
                    CardDispensers = GetCardTypeList(parts, "STCardDispenser"),
                    Cashboxs = GetCardTypeList(parts, "STCashBox"),
                    Keyboards = GetCardTypeList(parts, "STKeyBoard"),
                    Printers = GetCardTypeList(parts, "STPrinter"),
                    Sumatuns = GetCardTypeList(parts, "STScanner"),
                    Leds = GetCardTypeList(parts, "STLedScreen"),
                    Motherboards = GetCardTypeList(parts, "STOther"),
                    Ecgs = GetCardTypeList(parts, "STECG"),
                    Oximeters = GetCardTypeList(parts, "STOximeter"),
                    HeightAndWeights = GetCardTypeList(parts, "STHeightAndWeight"),
                    Sphygmomanometers = GetCardTypeList(parts, "STSphygmomanometer"),
                    Thermometers = GetCardTypeList(parts, "STThermometer")
                };
            }
        }

        private async Task GetPlugins(STTerminal m, STHardwareInfoDto ret)
        {
            var plugins = await _repositoryPlugin.GetAllListAsync(s => s.TermianlId.Equals(m.Id) && s.Enabled);
            if (plugins != null)
            {
                var versions = await _repositoryFileVersion.GetAllListAsync();
                var nets = await _repositoryPluginNet.GetAllListAsync(s => s.TermianlId.Equals(m.Id));
                ret.Plugins = plugins.Select(plugin =>
                {
                    var v = ObjectMapper.Map<STTerminalExDto>(plugin);
                    v.Nets = nets.Where(s => s.PluginId.Equals(plugin.Id)).Select(s => new { s.Port, s.NetType });
                    var version = versions.FirstOrDefault(s => s.Id.Equals(plugin.VersionId));
                    v.Path = version?.Path;
                    v.Type = string.IsNullOrWhiteSpace(version?.PluginType) ? "none" : version.PluginType;
                    v.Args = version?.Args;
                    v.Remark = version?.Remark;
                    v.AbsolutePath = version?.AbsolutePath;
                    return v;
                });
            }
        }

        private async Task GetHospital(STTerminal m, STHardwareInfoDto ret)
        {
            var hosp = await _repositoryAbpOrg.FirstOrDefaultAsync(s => s.Id.Equals(m.OrgId));
            if (hosp != null)
            {
                var ip = await GetIp();
                ret.Hospital = ObjectMapper.Map<Hospital>(hosp);
                ret.Hospital.RemoteIP = ip;
            }
        }

        private async Task<string> GetIp()
        {
            try
            {
                var ip = (await Dns.GetHostEntryAsync(Dns.GetHostName())).AddressList
                    .FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork)
                    ?.ToString();
                return ip;
            }
            catch (Exception ex)
            {
                NullLogger.Instance.Error(ex.ToString);
                return null;
            }
        }

        private async Task GetPosConfigs(STTerminal m, STHardwareInfoDto ret)
        {
            var pos = await _repositoryPosConfig.GetAllListAsync();
            if (pos != null && pos.Count > 0)
            {
                var filterT = pos.Where(s => s.TerminalIds == m.Id).ToList();
                var filter = pos.Where(s => string.IsNullOrEmpty(s.TerminalIds)).ToList();
                ret.PosConfig = ObjectMapper.Map<List<PosConfigs>>(filterT.Any() ? filterT : filter);
            }
        }

        private List<dynamic> GetCardTypeList(List<STTerminalPart> parts, string key)
        {
            return parts.Where(s => s.PartType.Equals(key)).Select(s =>
            {
                var temp = s.JsonText.FromJsonString<dynamic>();
                temp["id"] = s.Id;
                return temp;
            }).ToList();
        }

        [AbpAllowAnonymous, HttpPost]
        public async Task<string> GetHealthConfig(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return null;
            var m = await Repository.FirstOrDefaultAsync(s => s.Code.Equals(code) && s.IsActive);
            if (m == null) return null;
            var hc = await _repositoryHConfig.GetAsync(m.HealthConfigId);
            return hc?.JsonText;
        }

        [AbpAllowAnonymous]
        public async Task<bool> GetPowerOnAsync(string bid)
        {
            if (string.IsNullOrWhiteSpace(bid)) return false;
            var info = await Repository.FirstOrDefaultAsync(s => s.BID.Equals(bid) && s.IsActive && s.CanbeAccess);
            return info != null && info.IsPowerOn;
        }

        [AbpAllowAnonymous, HttpPost]
        public async Task<bool> UpdatePowerOn(STStatusDto data)
        {
            if (data == null || string.IsNullOrWhiteSpace(data.BID))
                return false;

            var m = await Repository.FirstOrDefaultAsync(s => s.BID.Equals(data.BID));
            if (m == null) return false;

            m.IsPowerOn = data.IsPowerOn == 1;
            await Repository.UpdateAsync(m);

            return true;
        }

        [AbpAllowAnonymous, HttpPost]
        public async Task<bool> UpdateStatus(STUpdateStatusDto data)
        {
            if (data == null || string.IsNullOrWhiteSpace(data.BID))
                return false;

            var m = await Repository.FirstOrDefaultAsync(s => s.BID.Equals(data.BID));
            if (m == null) return false;

            m.IsUpdated = data.IsUpdated == 1;
            await Repository.UpdateAsync(m);

            return true;
        }

        [AbpAllowAnonymous, HttpPost]
        public async Task<bool> UpdatePartStatus(string id, int status, string message)
        {
            if (string.IsNullOrWhiteSpace(id)) return false;
            var m = await _repositoryPart.FirstOrDefaultAsync(s => s.Id.Equals(id));
            if (m == null) return false;
            m.Status = status;
            if (!string.IsNullOrWhiteSpace(message))
                m.Message = message;
            await _repositoryPart.UpdateAsync(m);
            return true;
        }

        [AbpAllowAnonymous, HttpPost]
        public async Task<bool> UpdateDisinfectId(string terminalId, string disinfectId)
        {
            var terminalList = await _repositorySTTerminal.GetAllListAsync(s => s.DisinfectId == disinfectId);
            foreach (var terminal in terminalList)
                terminal.DisinfectId = "";

            if (string.IsNullOrWhiteSpace(terminalId))
                return false;

            string[] terminalIds = terminalId.Split(',');
            foreach (var id in terminalIds)
            {
                var m = await _repositorySTTerminal.FirstOrDefaultAsync(s => s.Id.Equals(id));
                if (m == null)
                    return false;

                if (!string.IsNullOrWhiteSpace(disinfectId))
                    m.DisinfectId = disinfectId;

                await _repositorySTTerminal.UpdateAsync(m);
            }

            return true;
        }

        public async Task<bool> ExistCode(string code, long orgId)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;
            var m = await Repository.FirstOrDefaultAsync(s => s.Code.Equals(code) && s.OrgId == orgId);
            return m != null;
        }

        [AbpAllowAnonymous]
        public Task<PagedResultDto<STTerminalCustomEnumDto>> GetTerminalEnums(string bid)
        {
            if (string.IsNullOrWhiteSpace(bid)) return null;
            var list = _repositoryCustomEnum.GetAll().Join(Repository.GetAll().Where(s => s.BID.Equals(bid)),
                s => s.TerminalId,
                t => t.Id, (s, t) => s).ToList();
            var dto = ObjectMapper.Map<List<STTerminalCustomEnumDto>>(list);
            return Task.FromResult(new PagedResultDto<STTerminalCustomEnumDto>(list.Count, dto));
        }

        public async Task<IActionResult> ExportAsync(dynamic data)
        {
            string idsStr = data.ids;
            int orgId = data.orgId;
            var ids = idsStr?.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var list = Repository.GetAll()
                .Where(x => x.CanbeAccess)
                .Where(x => x.IsActive)
                .WhereIf(ids?.Length > 0, x => ids.Contains(x.Id))
                .WhereIf(orgId > 0, x => x.OrgId == orgId)
                .ToList();
            var orgIds = list.Select(x => x.OrgId).ToList();
            var orgs = await _repositoryAbpOrg.GetAllListAsync(x => orgIds.Contains(x.Id));

            var datas = list.OrderBy(x => x.OrgId)
                .ThenBy(x=>x.Code)
                .Select(x =>
            {
                var org = orgs.Find(s => s.Id == x.OrgId);
                return new
                {
                    x.Code,
                    x.Name,
                    x.TerminalTypeId,
                    x.IP,
                    x.Mac,
                    x.BID,
                    x.DeviceNo,
                    x.Position,
                    OrgName = org?.DisplayName
                };
            });
            var (fileName, filePath) = await ExcelUtil.ExportAsync(null, datas, new List<string> { "终端编号", "终端名称", "设备型号", "IP", "网卡MAC", "主板序列号", "设备出厂编号", "点位", "所属机构" });

            var ms = new MemoryStream();
            await using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
                await fs.CopyToAsync(ms);

            ms.Seek(0, SeekOrigin.Begin);

            if (File.Exists(filePath)) File.Delete(filePath);

            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet}") { FileDownloadName = fileName };
        }

        private async Task CopyDatas(string templateId, string id, string type)
        {
            try
            {
                switch (type)
                {
                    case "1":
                        await CopyParts(templateId, id);
                        break;
                    case "2":
                        await CopyPlugins(templateId, id);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        private async Task CopyParts(string templateId, string id)
        {
            await _repositoryPart.DeleteAsync(s => s.TermianlId.Equals(id));

            var tparts = await _repositoryTPart.GetAllListAsync(s => s.TemplateId.Equals(templateId));
            if (tparts != null && tparts.Count > 0)
            {
                var parts = ObjectMapper.Map<List<STTerminalPart>>(tparts);
                parts.ForEach(async s =>
                {
                    s.Id = CreateSequentialGuid();
                    s.TermianlId = id;
                    await _repositoryPart.InsertAsync(s);
                });
            }
        }

        private async Task CopyPlugins(string templateId, string id)
        {
            var tplugins = await _repositoryTPlugin.GetAllListAsync(s => s.TemplateId.Equals(templateId));
            if (tplugins != null && tplugins.Count > 0)
            {
                await _repositoryPlugin.DeleteAsync(s => s.TermianlId.Equals(id));
                await _repositoryPluginNet.DeleteAsync(s => s.TermianlId.Equals(id));

                var tnets = await _repositoryTPluginNet.GetAllListAsync(s => s.TemplateId.Equals(templateId));
                var plugins = ObjectMapper.Map<List<STTerminalPlugin>>(tplugins);
                plugins.ForEach(async s =>
                {
                    //添加对应网络信息
                    var guid = CreateSequentialGuid();
                    var filters = tnets.FindAll(x => x.PluginId.Equals(s.Id));
                    CopyNetList(id, guid, filters);

                    //添加插件信息
                    s.Id = guid;
                    s.TermianlId = id;
                    await _repositoryPlugin.InsertAsync(s);
                });
            }
        }

        private void CopyNetList(string id, string pluginId, List<STTemplatePluginNet> tnets)
        {
            if (tnets != null && tnets.Count > 0)
            {
                var nets = ObjectMapper.Map<List<STTerminalPluginNet>>(tnets);
                nets.ForEach(async s =>
                {
                    s.Id = CreateSequentialGuid();
                    s.TermianlId = id;
                    s.PluginId = pluginId;
                    await _repositoryPluginNet.InsertAsync(s);
                });
            }
        }

        public override async Task<STTerminalDto> CreateAsync(STTerminalDto input)
        {
            try
            {
                var m = await Repository.FirstOrDefaultAsync(s => s.Code.Equals(input.Code));
                if (m != null) return null;

                var model = ObjectMapper.Map<STTerminal>(input);
                model.Id = input.Id = CreateSequentialGuid();

                await AddParts(input, model);

                await AddPlugins(input, model);

                await Repository.InsertAsync(model);
                return input;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                throw;
            }
        }

        private async Task AddParts(STTerminalDto input, STTerminal model)
        {
            if (input.Parts != null && input.Parts.Count > 0)
            {
                foreach (var info in input.Parts)
                {
                    info.Id = CreateSequentialGuid();
                    info.TermianlId = model.Id;
                    await _repositoryPart.InsertAsync(ObjectMapper.Map<STTerminalPart>(info));
                }
            }
        }

        private async Task AddPlugins(STTerminalDto input, STTerminal model)
        {
            if (input.Plugins != null && input.Plugins.Count > 0)
            {
                foreach (var info in input.Plugins)
                {
                    info.Id = CreateSequentialGuid();
                    info.TermianlId = model.Id;
                    if (info.NetList != null && info.NetList.Count > 0)
                    {
                        await AddNetList(info);
                    }

                    await _repositoryPlugin.InsertAsync(ObjectMapper.Map<STTerminalPlugin>(info));
                }
            }
        }

        private async Task AddNetList(STTerminalPluginDto info)
        {
            foreach (var net in info.NetList)
            {
                net.Id = CreateSequentialGuid();
                net.TermianlId = info.TermianlId;
                net.PluginId = info.Id;
                await _repositoryPluginNet.InsertAsync(ObjectMapper.Map<STTerminalPluginNet>(net));
            }
        }

        public override async Task<STTerminalDto> UpdateAsync(STTerminalDto input)
        {
            try
            {
                var model = await Repository.FirstOrDefaultAsync(s => s.Id.Equals(input.Id));
                MapToEntity(input, model);

                await DeleteAllAsync(input.Id);

                await AddParts(input, model);
                await AddPlugins(input, model);

                await Repository.UpdateAsync(model);

                return MapToEntityDto(model);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                throw;
            }
        }

        private async Task DeleteAllAsync(string id)
        {
            await _repositoryPart.DeleteAsync(s => s.TermianlId.Equals(id));
            await _repositoryPlugin.DeleteAsync(s => s.TermianlId.Equals(id));
            await _repositoryPluginNet.DeleteAsync(s => s.TermianlId.Equals(id));
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            await DeleteAllAsync(input.Id);
            await base.DeleteAsync(input);
        }

        public override async Task DeleteByIds(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");
            var inputs = ids.Split(",");
            if (inputs.Length > 0)
            {
                await Repository.DeleteAsync(s => inputs.Contains(s.Id));
            }
        }
    }
}