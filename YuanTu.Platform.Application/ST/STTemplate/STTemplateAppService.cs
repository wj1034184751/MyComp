using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTemplateAppService : AsynPermissionAppService<STTemplate, STTemplateDto, string, PagedSTTemplateRequestDto, STTemplateDto, STTemplateDto>, ISTTemplateAppService
    {
        private readonly IRepository<STTemplatePart, string> _repositoryPart;
        private readonly IRepository<STTemplatePlugin, string> _repositoryPlugin;
        private readonly IRepository<STTemplatePluginNet, string> _repositoryPluginNet;
        public STTemplateAppService(IRepository<STTemplate, string> repository, IRepository<STTemplatePart, string> repositoryPart, IRepository<STTemplatePlugin, string> repositoryPlugin, IRepository<STTemplatePluginNet, string> repositoryPluginNet) : base(repository)
        {
            _repositoryPart = repositoryPart;
            _repositoryPlugin = repositoryPlugin;
            _repositoryPluginNet = repositoryPluginNet;
        }

        protected override IQueryable<STTemplate> CreateFilteredQuery(PagedSTTemplateRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Code.Contains(input.Keyword) || x.Name.Contains(input.Keyword))
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
        }


        [ActionName("GetPage")]
        public override async Task<PagedResultDto<STTemplateDto>> GetAllAsync(PagedSTTemplateRequestDto input)
        {
            var list = await base.GetAllAsync(input);
            await GetDtos(list.Items);
            return list;
        }

        private async Task GetDtos(IEnumerable<STTemplateDto> infos)
        {
            var templateIds = infos.Select(s => s.Id);
            var parts = await _repositoryPart.GetAllListAsync(s => templateIds.Contains(s.TemplateId));
            var plugins = await GetPlugins(templateIds);

            foreach (var info in infos)
            {
                info.Parts =
                    ObjectMapper.Map<List<STTemplatePartDto>>(parts.Where(s => s.TemplateId.Equals(info.Id)));
                info.Plugins = plugins.Where(s => s.TemplateId.Equals(info.Id)).ToList();
            }
        }

        private async Task<List<STTemplatePluginDto>> GetPlugins(IEnumerable<string> templateIds)
        {
            var plugins = await _repositoryPlugin.GetAllListAsync(s => templateIds.Contains(s.TemplateId));
            var dto = ObjectMapper.Map<List<STTemplatePluginDto>>(plugins);
            var ids = dto.Select(s => s.Id);
            var list = await _repositoryPluginNet.GetAllListAsync(s => ids.Contains(s.PluginId));
            foreach (var pluginDto in dto)
            {
                pluginDto.NetList =
                    ObjectMapper.Map<List<STTemplatePluginNetDto>>(list.Where(s => s.PluginId.Equals(pluginDto.Id)));
            }

            return dto;
        }

        public override async Task<STTemplateDto> CreateAsync(STTemplateDto input)
        {
            try
            {
                var model = ObjectMapper.Map<STTemplate>(input);
                model.Id = input.Id = CreateSequentialGuid();

                await AddParts(input, model);

                await AddPlugins(input, model);

                await Repository.InsertAsync(model);
                return input;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                return null;
            }
        }

        private async Task AddParts(STTemplateDto input, STTemplate model)
        {
            if (input.Parts != null && input.Parts.Count > 0)
            {
                foreach (var info in input.Parts)
                {
                    info.Id = CreateSequentialGuid();
                    info.TemplateId = model.Id;
                    await _repositoryPart.InsertAsync(ObjectMapper.Map<STTemplatePart>(info));
                }
            }
        }

        private async Task AddPlugins(STTemplateDto input, STTemplate model)
        {
            if (input.Plugins != null && input.Plugins.Count > 0)
            {
                foreach (var info in input.Plugins)
                {
                    info.Id = CreateSequentialGuid();
                    info.TemplateId = model.Id;
                    if (info.NetList != null && info.NetList.Count > 0)
                    {
                        await AddNetList(info);
                    }

                    await _repositoryPlugin.InsertAsync(ObjectMapper.Map<STTemplatePlugin>(info));
                }
            }
        }

        private async Task AddNetList(STTemplatePluginDto info)
        {
            foreach (var net in info.NetList)
            {
                net.Id = CreateSequentialGuid();
                net.TemplateId = info.TemplateId;
                net.PluginId = info.Id;
                await _repositoryPluginNet.InsertAsync(ObjectMapper.Map<STTemplatePluginNet>(net));
            }
        }

        public override async Task<STTemplateDto> UpdateAsync(STTemplateDto input)
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
                return null;
            }
        }

        private async Task DeleteAllAsync(string id)
        {
            await _repositoryPart.DeleteAsync(s => s.TemplateId.Equals(id));
            await _repositoryPlugin.DeleteAsync(s => s.TemplateId.Equals(id));
            await _repositoryPluginNet.DeleteAsync(s => s.TemplateId.Equals(id));
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            await DeleteAllAsync(input.Id);
            await base.DeleteAsync(input);
        }

        public async Task<ListResultDto<STTemplateDto>> GetAllByTypeAsync(int type, long orgId, string pluginCode)
        { 
            var list = Repository.GetAll()
                .Where(s => s.TemplateType == type)
                .WhereIf(orgId > 0, s => s.OrgId == orgId);
            var dtos = ObjectMapper.Map<List<STTemplateDto>>(list);

            if (type == 2 && !string.IsNullOrWhiteSpace(pluginCode))
            {
                var ids = dtos.Select(s => s.Id).ToList();
                var plugins =
                    (await _repositoryPlugin.GetAllListAsync(s => ids.Contains(s.TemplateId) && s.PluginCode.Equals(pluginCode)))
                    .OrderByDescending(s => s.CreationTime).ToList();
                if (plugins.Count > 0)
                    foreach (var info in dtos)
                    {
                        var plugin = plugins.FirstOrDefault(s => s.TemplateId.Equals(info.Id));
                        info.Version = plugin?.Version;
                    }
            }

            return new ListResultDto<STTemplateDto>(dtos);
        }

        public async Task<bool> ExistCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return false;
            var m = await Repository.FirstOrDefaultAsync(s => s.Code.Equals(code) || s.Name.Equals(code));
            return m != null;
        }

        [AbpAllowAnonymous]
        public async Task<ListResultDto<STTemplateDto>> GetAllByOrgIdAsync(long orgId)
        {
            var list = await Repository.GetAllListAsync(s => s.OrgId == orgId);
            var dtos = ObjectMapper.Map<List<STTemplateDto>>(list);
            return new ListResultDto<STTemplateDto>(dtos);
        }
    }
}