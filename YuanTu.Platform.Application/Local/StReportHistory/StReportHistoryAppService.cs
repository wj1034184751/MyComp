
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
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Local.StReportHistory.Dto;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.Local
{
    /// <summary>
    /// 报告打印查询
    /// 作者: 系统用户
    /// 生成时间: 2022年08月04日 08:17:16
    /// </summary>
    [AbpAuthorize]
    public class StReportHistoryAppService : AsynPermissionAppService<STReportHistory, StReportHistoryDto, string, PagedSTReportHistoryRequestDto, StReportHistoryDto, StReportHistoryDto>, IStReportHistoryAppService
    {
        private readonly IRepository<STReportHistory, string> m_repository;
        private readonly IRepository<STPrintHistory, string> m_repositoryStPrinthistory;

        private readonly IRepository<STReportRecord, string> m_repositoryStReportRecord;

        public StReportHistoryAppService(IRepository<STReportHistory, string> repository
              , IRepository<STPrintHistory, string> repositoryStPrinthistory
              , IRepository<STReportRecord, string> repositoryStReportRecord
            ) : base(repository)
        {

            this.m_repositoryStReportRecord = repositoryStReportRecord;
            this.m_repositoryStPrinthistory = repositoryStPrinthistory;
        }


        //[ActionName("GetPage")]
        //public override async Task<PagedResultDto<StReportHistoryDto>> GetAllAsync(PagedSTReportHistoryRequestDto input)
        //{
        //    input.Sorting = " PrintTime DESC";

        //    var printHisoty = m_repositoryStPrinthistory.GetAll()
        //        .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.PrintTime >= Convert.ToDateTime(input.StartTime))
        //        .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.PrintTime <= Convert.ToDateTime(input.EndTime + " 23:59:59"))
        //        .WhereIf(!input.Reportid.IsNullOrWhiteSpace(), x => x.ReportId.Contains(input.Reportid.Trim()))
        //        .WhereIf(!input.Patientname.IsNullOrWhiteSpace(), x => x.PatientName.Contains(input.Patientname.Trim()))
        //        .WhereIf(!input.IdNo.IsNullOrWhiteSpace(), x => x.IdCardNo.Contains(input.IdNo) || x.SsCardNo.Contains(input.IdNo) || x.PatientId.Contains(input.IdNo))
        //        .WhereIf(input.PrintStatus != null, x => x.IsPrinted == (input.PrintStatus == 1));

        //    var recordhistory = printHisoty.GroupJoin(m_repositoryStReportRecord.GetAll()
        //        .WhereIf(input.Reporttype != null, p => p.ReportType == input.Reporttype)
        //        .WhereIf(!input.ReportName.IsNullOrWhiteSpace(), p => p.ReportName.Contains(input.ReportName)),
        //         print => print.ReportId, report => report.ReportId, (print, report) => new { print, report })
        //        .SelectMany(t => t.report.DefaultIfEmpty(), (a, report) => new { a.print, report });
        //    ;

        //    var totalCount = await recordhistory.CountAsync();
        //    var list = new List<StReportHistoryDto>();
        //    var pagedList = recordhistory.Skip(input.SkipCount).Take(input.MaxResultCount);

        //    foreach (var info in pagedList)
        //    {
        //        var rh = ObjectMapper.Map<StReportHistoryDto>(info.print);
        //        rh.ReportType = info.report?.ReportType ;
        //        switch (rh.ReportType)
        //        {
        //            case 1:
        //                rh.ReportTypeDesc = "检验报告";
        //                break;
        //            case 2:
        //                rh.ReportTypeDesc = "影像报告";
        //                break;
        //            default:
        //                rh.ReportTypeDesc = "";
        //                break;
        //        }
        //        rh.ReportName = info.report?.ReportName;
        //        list.Add(rh);
        //    }
        //    var dto = new PagedResultDto<StReportHistoryDto>(totalCount, ObjectMapper.Map<List<StReportHistoryDto>>(list));
        //    return dto;
        //}


    }
}
