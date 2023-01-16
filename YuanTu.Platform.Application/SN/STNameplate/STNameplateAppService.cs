using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.Organizations;
using YuanTu.Platform.SN.Dto;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.SN
{
    [AbpAuthorize]
    public class STNameplateAppService : AsynPermissionAppService<STNameplate, STNameplateDto, string, PagedSTNameplateRequestDto, STNameplateDto, STNameplateDto>, ISTNameplateAppService
    {
        private readonly IRepository<STSerialNo, string> _stserialNoRepository;
        private readonly IRepository<AbpOrg, long> _orgRepository;
        public STNameplateAppService(IRepository<STNameplate, string> repository, IRepository<STSerialNo, string> stserialNoRepository, IRepository<AbpOrg, long> orgRepository) : base(repository)
        {
            _stserialNoRepository = stserialNoRepository;
            _orgRepository = orgRepository;
        }

        protected override IQueryable<STNameplate> CreateFilteredQuery(PagedSTNameplateRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Code.ToString().Equals(input.Keyword) || x.Name.Contains(input.Keyword))
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<STNameplateDto>> GetAllAsync(PagedSTNameplateRequestDto input)
        {
            input.Sorting = "CreationTime DESC";
            var list = await base.GetAllAsync(input);
            if (input.Original != 1)
                await GetDetails(list);
            return list;
        }

        private async Task GetDetails(PagedResultDto<STNameplateDto> list)
        {
            var ids = list.Items.Select(s => s.Id).ToList();
            var details = await _stserialNoRepository.GetAllListAsync(s => ids.Contains(s.NameplateId) && s.Status);
            foreach (var item in list.Items)
            {
                var sns = details.Where(s => s.NameplateId.Equals(item.Id));
                item.SerialNos = ObjectMapper.Map<List<STSerialNoDto>>(sns.OrderBy(s => s.SerialNo));
                //var sn = item.SerialNos.Select(s => s.SerialNo);
                if (item.SerialNos.Count > 0)
                    item.SnBlock = $"{item.SerialNos[0].SerialNo}..."; //item.SerialNos.Count > 2 ? $"{string.Join('、', sn.Take(2))}..." : string.Join('、', sn);
            }
        }

        public override async Task<STNameplateDto> CreateAsync(STNameplateDto input)
        {
            input.LastModificationTime = DateTime.Now;
            var model = await base.CreateAsync(input);

            await EditSerialNos(input, model.Id);

            return model;
        }

        private async Task EditSerialNos(STNameplateDto input, string nameplateId)
        {
            if (input.SerialNos?.Count > 0)
            {
                await _stserialNoRepository.DeleteAsync(s => s.NameplateId.Equals(nameplateId));
                foreach (var no in input.SerialNos)
                {
                    for (var i = 0; i < no.Num; i++)
                    {
                        var sn = ObjectMapper.Map<STSerialNo>(no);
                        sn.OrderDate = input.OrderDate;
                        sn.Id = CreateSequentialGuid();
                        sn.NameplateId = nameplateId;
                        sn.Num = 1;
                        sn.SerialNo = $"{input.OrderDate:yyMM}{sn.Color}{((int.TryParse(sn.StartNum, out var n) ? n : 1) + i):D4}{sn.Factory}";

                        await _stserialNoRepository.InsertAsync(sn);
                    }
                }
            }
        }

        public override async Task<STNameplateDto> UpdateAsync(STNameplateDto input)
        {
            var model = await base.UpdateAsync(input);

            await EditSerialNos(input, model.Id);

            return model;
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            await _stserialNoRepository.DeleteAsync(s => s.NameplateId == input.Id);
            await base.DeleteAsync(input);
        }

        [HttpPost, AbpAllowAnonymous]
        public async Task<IActionResult> ExportAsync(dynamic data)
        {

            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(data)}不能为空");

            var arr = ids.Split(',');
            var serialNos = _stserialNoRepository.GetAll().Where(s => s.Status)
                .Join(Repository.GetAll().Where(s => arr.Contains(s.Id)), x => x.NameplateId, s => s.Id,
                    (x, s) => new
                    {
                        x.SerialNo,
                        x.OrderModel,
                        x.TerminalModel,
                        s.Name,
                        s.Code,
                        s.OrgId,
                        s.OrderDate,
                        s.PreDeliveryDate,
                        s.WeChatCode
                    })
                .OrderBy(s=>s.OrderDate)
                .ThenBy(s => s.Code)
                .ThenBy(s=>s.SerialNo)
                .ToList();

            #region 带机构名称

            /*var serialNos = _stserialNoRepository.GetAll().Where(s => s.Status)
            .Join(Repository.GetAll().Where(s => arr.Contains(s.Id)), x => x.NameplateId, s => s.Id, (x, s) => new { x.SerialNo, x.OrderModel, x.TerminalModel, s.Name, s.Code, s.OrgId, s.OrderDate, s.PreDeliveryDate, s.WeChatCode })
            .GroupJoin(_orgRepository.GetAll(), x => x.OrgId, s => s.Id, (x, s) => new { x, s })
            .SelectMany(t=>t.s.DefaultIfEmpty(),(x,s)=>new
            {
                x.x.SerialNo,
                x.x.OrderModel,
                x.x.TerminalModel,
                x.x.Name,
                x.x.Code,
                x.x.OrgId,
                x.x.OrderDate,
                x.x.PreDeliveryDate,
                x.x.WeChatCode,
                s.DisplayName
            })
              .OrderBy(s=>s.OrderDate)
               .ThenBy(s => s.Code)
               .ThenBy(s=>s.SerialNo)
            .ToList();*/

            #endregion

            var index = 0;
            var datas = serialNos.Select(s => new
            {
                s.Code,
                s.Name,
                s.OrderModel,
                s.TerminalModel,
                s.SerialNo,
                s.WeChatCode,
                s.OrderDate,
                s.PreDeliveryDate
            }).GroupBy(s => new { s.Code, s.OrderModel }).Select(s => new
            {
                Index = ++index,
                s.FirstOrDefault()?.Code,
                s.FirstOrDefault()?.Name,
                s.Key.OrderModel,
                TerminalModel = s.FirstOrDefault()?.TerminalModel == 0 ? "自助机" : "诊间屏",
                Num = s.Count(),
                SerialNo = $"{s.FirstOrDefault()?.SerialNo}({s.LastOrDefault()?.SerialNo.Substring(6)})",
                s.FirstOrDefault()?.WeChatCode,
                OrderDate = s.FirstOrDefault()?.OrderDate.ToString("yyyyMMdd"),
                PreDeliveryDate = s.FirstOrDefault()?.PreDeliveryDate.ToString("yyyyMMdd")
            }).ToList();

            var (fileName, filePath) = await ExcelUtil.ExportAsync(datas.FirstOrDefault()?.Name, datas, new List<string> { "序号", "项目编号", "项目名称", "设备型号", "设备类别", "数量", "铭牌编码", "微信摄像头随机码", "下单时间", "预发货时间" });

            var ms = new MemoryStream();
            await using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
                await fs.CopyToAsync(ms);

            ms.Seek(0, SeekOrigin.Begin);

            if (File.Exists(filePath)) File.Delete(filePath);

            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet}") { FileDownloadName = fileName };
        }

        [AbpAllowAnonymous]
        public async Task<PagedResultDto<STNameplateExDto>> GetSns(PagedSTNameplateExRequestDto input)
        {
            var result = new List<STNameplateExDto>();
            var list = Repository.GetAll()
                .Join(_orgRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.HospitalId),
                            s => s.HospitalId.ToString().Equals(input.HospitalId))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.HospitalCode), s => s.Code.Equals(input.HospitalCode))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.HospitalName),
                            s => s.DisplayName.Equals(input.HospitalCode))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UnionId), s => s.UnionId.Equals(input.UnionId)),
                    x => x.OrgId, s => s.Id, (x, s) => new { x, s.Code, s.DisplayName, s.UnionId, s.HospitalId });
            var totalCount = await list.CountAsync();
            var pagedList = list.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();


            var nameplateIds = pagedList.Select(s => s.x.Id);
            var snsAll= _stserialNoRepository.GetAll().Where(s => nameplateIds.Contains(s.NameplateId) && s.Status).OrderBy(s => s.SerialNo).ToList();
            foreach (var info in pagedList)
            {
                var sns = snsAll.FindAll(s => s.NameplateId.Equals(info.x.Id));
                if (sns.Count == 0) continue;

                var m = ObjectMapper.Map<STNameplateExDto>(info.x);
                m.HospitalCode = info.Code;
                m.HospitalId = info.HospitalId.ToString();
                m.HospitalName = info.DisplayName;
                m.UnionId = info.UnionId;
                 
                var groups = sns.GroupBy(s => s.TerminalTypeId);
                m.SerialNos = groups
                    .Select(s => new { s.Key, list = s.OrderBy(t => t.SerialNo).Select(t => t.SerialNo).ToList() })
                    .ToDictionary(s => s.Key, s => s.list);
                var g = groups.Select(s => new { s.Key, status = s.FirstOrDefault()?.DeliveryStatus == 1 ? "已发" : "未发" });
                foreach (var a in g)
                    m.Situation += $"{a.Key}({a.status}),";

                result.Add(m);
            }

            var dto = new PagedResultDto<STNameplateExDto>(totalCount, result);

            return dto;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public override async Task DeleteByIds(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");

            var arr = ids.Split(',');
            if (arr.Length == 0) return;

            await _stserialNoRepository.DeleteAsync(s => arr.Contains(s.NameplateId));

            await Repository.DeleteAsync(s => arr.Contains(s.Id));
        }
    }
}