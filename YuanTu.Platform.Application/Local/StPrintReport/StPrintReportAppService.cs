using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.Local
{
    [AbpAuthorize]
    public class StPrintReportAppService : AsynPermissionAppService<StPrintReport, StPrintReportDto, string, PagedStPrintReportDto, StPrintReportDto, StPrintReportDto>, IStPrintReportAppService
    {
        private readonly IRepository<StPrintReport, string> m_repository;
        private readonly IRepository<STTerminal, string> m_repositorySTTerminal;
        public StPrintReportAppService(IRepository<StPrintReport, string> repository, IRepository<STTerminal, string> repositorySTTerminal) : base(repository)
        {
            this.m_repository = repository;
            this.m_repositorySTTerminal = repositorySTTerminal;
        }

        protected override IQueryable<StPrintReport> CreateFilteredQuery(PagedStPrintReportDto input)
        {
            input.Sorting = " CreationTime DESC";

            string terminalId = null;
            //统计(年/月/日)单独自助机数据
            if (!input.Key.IsNullOrWhiteSpace())
            {
                var terminal = m_repositorySTTerminal.GetAll()
                    .Where(x => x.IP.Contains(input.Key) || x.Code.Contains(input.Key)).FirstOrDefault();
                if (terminal != null)
                {
                    terminalId = terminal.Id;
                }
                else
                {
                    terminalId = "-9999";
                }
            }

            return m_repository.GetAll()
                .Where(v => v.ReportTimelyType == input.Timely)
                .WhereIf((input.OrgId != null && input.OrgId != 0),x=>x.OrgId==input.OrgId)
                .WhereIf(terminalId != null, x => x.StTerminalId == terminalId)
                .WhereIf(!input.ReportType.IsNullOrWhiteSpace(), x => x.BusinessTypeId == input.ReportType)
                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.CreationTime >= Convert.ToDateTime(input.StartTime))
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.CreationTime <= Convert.ToDateTime(input.EndTime + " 23:59:59"));

        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<StPrintReportDto>> GetAllAsync(PagedStPrintReportDto input)
        {
            if (input.IsALl == "1")
            {

                //统计(年/月/日)所有自助机数据

                var query = m_repository.GetAll()
                 .Where(v => v.ReportTimelyType == input.Timely)
                 .WhereIf((input.OrgId != null && input.OrgId != 0), x => x.OrgId == input.OrgId)
                 .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.CreationTime >= Convert.ToDateTime(input.StartTime))
                 .WhereIf(!input.ReportType.IsNullOrWhiteSpace()  , x=>x.BusinessTypeId==input.ReportType)
                 .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.CreationTime <= Convert.ToDateTime(input.EndTime + " 23:59:59")).ToList();

                var queryGroup = query.GroupBy(p => p.CreationTime).OrderByDescending(p => p.Key);
                var count = queryGroup.Count();

                var queryCloumn = queryGroup.Skip(input.SkipCount).Take(input.MaxResultCount).Select(p => new StPrintReportDto()
                {
                    Id = p.First().Id,
                    CreationTime = p.Key,
                    LastModificationTime = p.First().LastModificationTime,
                    OrgId = p.First().OrgId,
                    PrinterTypeId = p.First().PrinterTypeId,
                    PersonTime = p.Sum(m => m.PersonTime),
                    TotalPages = p.Sum(m => m.TotalPages),
                    TotalPagesInA4 = p.Sum(m => m.TotalPagesInA4),
                    TotalPagesInA5 = p.Sum(m => m.TotalPagesInA5),
                    TotalPagesCustom = p.Sum(m => m.TotalPagesCustom),
                    TotalPagesInReceipt = p.Sum(m => m.TotalPagesInReceipt),
                    BusinessTypeId= p.First().BusinessTypeId,
                    ReportTimelyType = p.First().ReportTimelyType
                });
                return Task.FromResult(new PagedResultDto<StPrintReportDto>(count, queryCloumn.ToList()));
            }
            else
            {
                return base.GetAllAsync(input);
            }


        }

        [AbpAllowAnonymous]
        public Task<StPrintReportChartRto> GetChart()
        {
            StPrintReportChartRto chart = new StPrintReportChartRto();

            var now = DateTime.Today;
            var last = now.AddMonths(-1);
            var from = new DateTime(last.Year, last.Month, last.Day).AddDays(1);
            var to = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59);

            var totaldaily = Repository.GetAll().Where(v => v.ReportTimelyType == ReportTimelyType.Daily).Select(v => v.CreationTime).Distinct().Count();

            var today = Repository.GetAll().Where(v => v.ReportTimelyType == ReportTimelyType.Daily && v.CreationTime >= now && v.CreationTime <= to).ToList();
            var daily = Repository.GetAll().Where(v => v.ReportTimelyType == ReportTimelyType.Daily && v.CreationTime >= from && v.CreationTime <= to).ToList();
            var weekly = Repository.GetAll().Where(v => v.ReportTimelyType == ReportTimelyType.Weekly).ToList();

            var lastmonth = new DateTime(now.Year, now.Month, 1).AddMonths(-11);
            var tomonth = new DateTime(now.Year, now.Month, 1);
            var monthly = Repository.GetAll().Where(v => v.ReportTimelyType == ReportTimelyType.Monthly && v.CreationTime >= lastmonth && v.CreationTime <= tomonth).OrderByDescending(v => v.TotalPages).ToList();

            var yearly = Repository.GetAll().Where(v => v.ReportTimelyType == ReportTimelyType.Yearly).OrderByDescending(v => v.TotalPages).ToList();
            //var allly = Repository.GetAll().Where(v => v.ReportTimelyType == ReportTimelyType.Daily).ToList();


            chart.TodayRank = this.ObjectMapper.Map<List<StPrintReportDto>>(today.OrderByDescending(v => v.TotalPages));
            chart.DailyView = this.ObjectMapper.Map<List<StPrintReportDto>>(daily.GroupBy(v => v.CreationTime).Select(v => new StPrintReport() { CreationTime = v.FirstOrDefault().CreationTime, TotalPages = v.Sum(m => m.TotalPages) }));
            chart.WeeklyView = this.ObjectMapper.Map<List<StPrintReportDto>>(weekly.GroupBy(v => v.CreationTime).Select(v => new StPrintReport() { CreationTime = v.FirstOrDefault().CreationTime, TotalPages = v.Sum(m => m.TotalPages) }));
            chart.MonthlyView = this.ObjectMapper.Map<List<StPrintReportDto>>(monthly.GroupBy(v => v.CreationTime).Select(v => new StPrintReport() { CreationTime = v.FirstOrDefault().CreationTime, TotalPages = v.Sum(m => m.TotalPages) }));
            chart.YearlyView = this.ObjectMapper.Map<List<StPrintReportDto>>(yearly.GroupBy(v => v.CreationTime).Select(v => new StPrintReport() { CreationTime = v.FirstOrDefault().CreationTime, TotalPages = v.Sum(m => m.TotalPages) }));
            chart.WeeklyRank = new List<StPrintReportDto>();
            chart.MonthlyRank = this.ObjectMapper.Map<List<StPrintReportDto>>(monthly.Where(v => v.CreationTime == new DateTime(now.Year, now.Month, 1)).OrderByDescending(v => v.TotalPages));
            chart.YearlyRank = this.ObjectMapper.Map<List<StPrintReportDto>>(yearly.Where(v => v.CreationTime == new DateTime(now.Year, 1, 1)).OrderByDescending(v => v.TotalPages));

            var termianls = m_repositorySTTerminal.GetAll().ToList();

            SetTerminalInfo(chart.TodayRank, termianls);
            SetTerminalInfo(chart.WeeklyRank, termianls);
            SetTerminalInfo(chart.MonthlyRank, termianls);
            SetTerminalInfo(chart.YearlyRank, termianls);

            chart.Summary = new StPrintReportSummary()
            {
                Total = yearly.Sum(v => v.TotalPages),
                TotalInA4 = yearly.Sum(v => v.TotalPagesInA4),
                TotalInA5 = yearly.Sum(v => v.TotalPagesInA5),
                Average = yearly.Sum(v => v.TotalPages) / (totaldaily == 0 ? 1 : totaldaily)
            };

            return Task.FromResult(chart);
        }

        private void SetTerminalInfo(List<StPrintReportDto> reports, List<STTerminal> terminals)
        {
            foreach (var report in reports)
            {
                var terminal = terminals.FirstOrDefault(v => v.Id == report.StTerminalId);
                if (terminal != null)
                {
                    report.StTerminalCode = terminal.Code;
                    report.StTerminalIp = terminal.IP;
                    report.StTerminalBid = terminal.BID;
                }
            }
        }
    }
}
