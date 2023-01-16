using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Json;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.AdOrder;
using YuanTu.Platform.AdOrder.UserFlowLog.Dto;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.UserFlowLog;
using YuanTu.Platform.UserFlowLog.Dto;

namespace YuanTu.Platform.UserFlowLog
{
    [AbpAuthorize]
    public class UserFlowLogAppService : AsynPermissionAppService<AdUserFlowLog, UserFlowLogDto, string, PagedUserFlowLogRequestDto, UserFlowLogDto, UserFlowLogDto>, IUserFlowLogAppService
    {
        private readonly IRepository<AdUserFlowDetailLog, string> _adUserFlowDetailLogRepository;
        private readonly IRepository<AdUserHisFlowDetailLog, string> _adUserHisFlowDetailLogRepository;
        public UserFlowLogAppService(
            IRepository<AdUserFlowLog, string> repository, 
            IRepository<AdUserFlowDetailLog, string> adUserFlowDetailLogRepository,
            IRepository<AdUserHisFlowDetailLog, string> adUserHisFlowDetailLogRepository) : base(repository)
        {
            _adUserFlowDetailLogRepository = adUserFlowDetailLogRepository;
            _adUserHisFlowDetailLogRepository = adUserHisFlowDetailLogRepository;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<UserFlowLogDto>> GetAllAsync(PagedUserFlowLogRequestDto input)
        {
            var query = this.Repository.GetAll()
               .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.OperateTime >= Convert.ToDateTime(input.StartTime))
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.OperateTime <= Convert.ToDateTime(input.EndTime).AddDays(1))
                .WhereIf(!input.TerminalNo.IsNullOrWhiteSpace(), x => x.TerminalNo.Contains(input.TerminalNo) || x.DeviceIp.Contains(input.TerminalNo))
                .WhereIf(!input.CardNo.IsNullOrWhiteSpace(), x => x.IptOptNo.Contains(input.CardNo) || x.IptHospitalNo.Contains(input.CardNo) || x.IdCardNo.Contains(input.CardNo))
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.TraceId.Contains(input.Keyword) || x.PatientId.Contains(input.Keyword) || x.PatientName.Contains(input.Keyword))
                .WhereIf(input.BusinessType>-1, x => x.BusinessType.Equals(input.BusinessType))
                .WhereIf(input.Status>-1, x => x.Status.Equals(input.Status))
                .OrderByDescending(c => c.OperateTime);

            var result = new List<UserFlowLogDto>();


            var totalCount = await query.CountAsync();
            var pagedList = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            foreach (var info in pagedList)
            {
                var m = MapToEntityDto(info);
                var detailList = _adUserFlowDetailLogRepository.GetAll().Where(d => d.FlowId == info.Id).ToList();
                var hisIds = detailList.Select(d => d.Id).ToArray();
                var hisDetailList = _adUserHisFlowDetailLogRepository.GetAll().Where(d => hisIds.Contains(d.FlowDetailId));
                if (detailList != null && detailList.Any())
                {
                    var resultList = ObjectMapper.Map<List<UserFlowDetailLogDto>>(detailList);
                    m.YuDetailListlog.AddRange(resultList);
                }

                if (hisDetailList != null && hisDetailList.Any())
                {
                    var resultList = ObjectMapper.Map<List<UserHisFlowDetailLogDto>>(hisDetailList);
                    m.HisDetailListlog.AddRange(resultList);
                }
                result.Add(m);
            }

            var dto = new PagedResultDto<UserFlowLogDto>(totalCount, ObjectMapper.Map<List<UserFlowLogDto>>(result));

            return dto;
        }

        [ActionName("DownLoadFlowLogs")]
        [HttpGet, AbpAllowAnonymous]
        public async Task<IActionResult> DownLoadFlowLog(string  flowId)
        {
            if (flowId.IsNullOrWhiteSpace())
                throw new UserFriendlyException($"参数{nameof(flowId)}不能为空");

            var datas = _adUserFlowDetailLogRepository.GetAll().Where(d => d.FlowId == flowId);
            var text = datas.ToJsonString(true);
            var fileName = $"{Guid.NewGuid()}.json";

            var ms = new MemoryStream();
            await ms.WriteAsync(Encoding.UTF8.GetBytes(text));
            ms.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationOctetStream}") { FileDownloadName = fileName };
        }
    }
}