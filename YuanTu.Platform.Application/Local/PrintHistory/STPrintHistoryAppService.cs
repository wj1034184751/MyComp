using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.Local
{
    [AbpAuthorize]
    public class STPrintHistoryAppService : AsynPermissionAppService<STPrintHistory, STPrintHistoryDto, string, PagedSTPrintHistoryDto, STPrintHistoryDto, STPrintHistoryDto>, ISTPrintHistoryAppService
    {
        private readonly IRepository<STPrintHistory, string> m_repository;
        private readonly IRepository<STTerminal, string> m_repositorySTTerminal;
        private readonly IRepository<StPrintReport, string> m_repositoryStPrintReport;
        private readonly IRepository<STReportRecord, string> m_repositoryStReportRecord;
        public STPrintHistoryAppService(IRepository<STPrintHistory, string> repository
            , IRepository<STTerminal, string> repositorySTTerminal
            , IRepository<StPrintReport, string> repositoryStPrintReport,
            IRepository<STReportRecord, string> repositoryStReportRecord
            ) : base(repository)
        {

            this.m_repository = repository;
            this.m_repositorySTTerminal = repositorySTTerminal;
            this.m_repositoryStPrintReport = repositoryStPrintReport;
            this.m_repositoryStReportRecord = repositoryStReportRecord;
        }

        protected override IQueryable<STPrintHistory> CreateFilteredQuery(PagedSTPrintHistoryDto input)
        {
            //input.Sorting = " CreationTime DESC";
            //string terminalId = string.Empty;
            //if (!input.BID.IsNullOrWhiteSpace() || !input.IP.IsNullOrWhiteSpace() || !input.STTerminalCode.IsNullOrWhiteSpace())
            //{
            //    var terminal = m_repositorySTTerminal.GetAll()
            //        .WhereIf(!input.BID.IsNullOrWhiteSpace(), x => x.BID.Contains(input.BID))
            //        .WhereIf(!input.IP.IsNullOrWhiteSpace(), x => x.IP.Contains(input.IP))
            //        .WhereIf(!input.STTerminalCode.IsNullOrWhiteSpace(), x => x.Code.Contains(input.STTerminalCode)).FirstOrDefault();
            //    if (terminal != null)
            //    {
            //        terminalId = terminal.Id;
            //    }
            //    else
            //    {
            //        terminalId = "-9999";
            //    }
            //}
            //return m_repository.GetAll()
            //    // 匹配身份证/社保卡号
            //    .WhereIf(!input.IdCardNo.IsNullOrWhiteSpace(), x => x.IdCardNo.Contains(input.IdCardNo) || x.SsCardNo.Contains(input.IdCardNo))
            //    .WhereIf(!input.PatientId.IsNullOrWhiteSpace(), x => x.PatientId.Contains(input.PatientId))
            //    .WhereIf(!input.PatientName.IsNullOrWhiteSpace(), x => x.PatientName.Contains(input.PatientName))
            //    .WhereIf(!terminalId.IsNullOrWhiteSpace(), x => x.StTerminalId == terminalId)
            //    .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.CreationTime >= Convert.ToDateTime(input.StartTime))
            //    .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.CreationTime <= Convert.ToDateTime(input.EndTime + " 23:59:59"));

            input.Sorting = " ReportTime DESC";
            return m_repository.GetAll()
                .WhereIf(input.Reporttype != null, x => x.ReportType == input.Reporttype)
                .WhereIf(!input.Reportid.IsNullOrWhiteSpace(), x => x.ReportId.Contains(input.Reportid.Trim()))
                .WhereIf(!input.ReportName.IsNullOrWhiteSpace(), x => x.ReportName.Contains(input.ReportName.Trim()))
                .WhereIf(!input.Patientname.IsNullOrWhiteSpace(), x => x.PatientName.Contains(input.Patientname.Trim()))
                .WhereIf(!input.IdNo.IsNullOrWhiteSpace(), x => x.IdNo.Contains(input.IdNo.Trim()))
                .WhereIf(input.Checkstatus != null, x => x.CheckStatus == input.Checkstatus)
                .WhereIf(input.Reportstatus != null, x => x.ReportStatus == input.Reportstatus)
                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.ReportTime >= Convert.ToDateTime(input.StartTime))
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.ReportTime <= Convert.ToDateTime(input.EndTime + " 23:59:59"));
        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<STPrintHistoryDto>> GetAllAsync(PagedSTPrintHistoryDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAllowAnonymous]
        public override async Task<STPrintHistoryDto> CreateAsync(STPrintHistoryDto input)
        {
            var today = DateTime.Today;
            if (input.IsPrinted)
            {
                //&& v.OrgId==input.OrgId
                // 增加日统计-分自助机
                var daily = m_repositoryStPrintReport.GetAll().FirstOrDefault(v => v.ReportTimelyType == ReportTimelyType.Daily
                    && v.StTerminalId == input.StTerminalId && v.OrgId == input.OrgId
                    && v.BusinessTypeId == "0"
                    && v.CreationTime == today);

                SyncStPrintReport(daily, input, today, ReportTimelyType.Daily);

                // 增加月统计-分自助机
                today = new DateTime(today.Year, today.Month, 1);
                var monthly = m_repositoryStPrintReport.GetAll().FirstOrDefault(v => v.ReportTimelyType == ReportTimelyType.Monthly
                    && v.StTerminalId == input.StTerminalId && v.OrgId == input.OrgId
                    && v.BusinessTypeId == "0"
                    && v.CreationTime == today);

                SyncStPrintReport(monthly, input, today, ReportTimelyType.Monthly);

                // 增加年统计-分自助机
                today = new DateTime(today.Year, 1, 1);
                var yearly = m_repositoryStPrintReport.GetAll().FirstOrDefault(v => v.ReportTimelyType == ReportTimelyType.Yearly
                    && v.StTerminalId == input.StTerminalId && v.OrgId == input.OrgId
                    && v.BusinessTypeId == "0"
                    && v.CreationTime == today);

                SyncStPrintReport(yearly, input, today, ReportTimelyType.Yearly);

                //增加一个报告类型纬度的统计
                if (!string.IsNullOrWhiteSpace(input.BusinessTypeId) && input.BusinessTypeId.Length > 2)
                {
                    today = DateTime.Today;
                    var dailyType = m_repositoryStPrintReport.GetAll().FirstOrDefault(v => v.ReportTimelyType == ReportTimelyType.Daily
                     && v.StTerminalId == input.StTerminalId && v.OrgId == input.OrgId
                     && v.BusinessTypeId == input.BusinessTypeId.Substring(0, 2)
                     && v.CreationTime == today);
                    SyncStPrintReport(dailyType, input, today, ReportTimelyType.Daily, "1");

                    today = new DateTime(today.Year, today.Month, 1);
                    var monthlyType = m_repositoryStPrintReport.GetAll().FirstOrDefault(v => v.ReportTimelyType == ReportTimelyType.Monthly
                        && v.StTerminalId == input.StTerminalId && v.OrgId == input.OrgId
                        && v.BusinessTypeId == input.BusinessTypeId.Substring(0, 2)
                        && v.CreationTime == today);

                    SyncStPrintReport(monthlyType, input, today, ReportTimelyType.Monthly, "1");

                    today = new DateTime(today.Year, 1, 1);
                    var yearlyType = m_repositoryStPrintReport.GetAll().FirstOrDefault(v => v.ReportTimelyType == ReportTimelyType.Yearly
                        && v.StTerminalId == input.StTerminalId && v.OrgId == input.OrgId
                        && v.BusinessTypeId == input.BusinessTypeId.Substring(0, 2)
                        && v.CreationTime == today);

                    SyncStPrintReport(yearlyType, input, today, ReportTimelyType.Yearly, "1");
                }
            }

            var print = await m_repository.GetAll().FirstOrDefaultAsync(p => p.ReportId == input.ReportId);

            if (print != null)
            {
                //进行了打印操作,增加计数
                print.IsPrinted = true;
                print.PrintCount += 1;
                print.PrintTime = input.PrintTime;
                m_repository.Update(print);
            }
            else
            {
                //增加基础信息
                print = new STPrintHistory();
                print = MapToEntity(input);
                print.Id = Guid.NewGuid().ToString("N");
                print.IsPrinted = true;
                print.PrintCount = 1;
                print.PrintType = (PrinterType)Convert.ToInt32(input.PrinterTypeId);
                //基本为凭条打印
                m_repository.Insert(print);
            }
            //②增加每次的打印记录
            STReportRecord record = new STReportRecord();
            record = ObjectMapper.Map<STReportRecord>(input);
            record.Id = Guid.NewGuid().ToString("N");
            record.PrintHistoryId = print.Id;
            record.PrintStatusDesc = input.IsPrinted ? "打印成功" : "打印失败";
            record.PrintFailMsg = input.PrintFailMsg;
            m_repositoryStReportRecord.Insert(record);

            return new STPrintHistoryDto(0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="daily">计数记录</param>
        /// <param name="input">数据</param>
        /// <param name="today">时间记录纬度</param>
        /// <param name="timely">日月年</param>
        /// <param name="countType">计数类型0纯计数1增加报告类型纬度2增加科室纬度</param>
        protected void SyncStPrintReport(StPrintReport daily, STPrintHistoryDto input, DateTime today, ReportTimelyType timely, string countType = "0")
        {
            if (daily != null)
            {
                switch (input.PaperSize)
                {
                    case "A4":
                        daily.TotalPages += input.PageCount;
                        daily.TotalPagesInA4 += input.PageCount;
                        break;
                    case "A5":
                        daily.TotalPages += input.PageCount;
                        daily.TotalPagesInA5 += input.PageCount;
                        break;
                    case "Custom":
                        daily.TotalPages += input.PageCount;
                        daily.TotalPagesCustom += input.PageCount;
                        break;
                    default:
                        daily.TotalPagesInReceipt += input.PageCount;
                        break;
                }
                daily.PersonTime++;
                m_repositoryStPrintReport.Update(daily);
            }
            else
            {

                daily = new StPrintReport();
                daily.StTerminalId = input.StTerminalId;
                daily.DeptCode = input.DeptCode;
                daily.DeptName = input.DeptName;
                daily.PrinterName = input.PrinterName;
                daily.BusinessTypeId = countType == "0" ? "0" : input.BusinessTypeId.Substring(0, 2);
                daily.OrgId = input.OrgId;
                daily.PrinterTypeId = input.PrinterTypeId;
                daily.ReportTimelyType = timely;
                daily.PersonTime = 1;
                switch (input.PaperSize)
                {
                    case "A4":
                        daily.TotalPages = input.PageCount;
                        daily.TotalPagesInA4 = input.PageCount;
                        break;
                    case "A5":
                        daily.TotalPages = input.PageCount;
                        daily.TotalPagesInA5 = input.PageCount;
                        break;
                    case "Custom":
                        daily.TotalPages = input.PageCount;
                        daily.TotalPagesCustom = input.PageCount;
                        break;
                    default:
                        daily.TotalPagesInReceipt = input.PageCount;
                        break;
                }
                daily.CreationTime = today;
                daily.Id = Guid.NewGuid().ToString("N");

                m_repositoryStPrintReport.Insert(daily);
            }
        }


        /// <summary>
        /// 更改报告打印状态
        /// </summary>
        /// <param name="reportList">报告的list 分号分割</param>
        /// <param name="status">0(打印完成/下次可查询打印)1(打印中/下次不可查询打印)</param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public Task<bool> ChangePringStatus(ChangeStatus changeStatus)
        {
            try
            {
                var reportIds = changeStatus.reportList.Split(new[] { ',', '|', ';' }, StringSplitOptions.RemoveEmptyEntries);

                List<STPrintHistory> pacsUpdate = new List<STPrintHistory>();

                var pasData = m_repository.GetAll().Where(p => reportIds.Contains(p.ReportId));

                foreach (var item in pasData)
                {
                    item.PrintStatus = changeStatus.status;
                    pacsUpdate.Add(item);
                }
                if (pacsUpdate.Count > 0)
                {
                    m_repository.GetDbContext().BulkUpdate(pacsUpdate);
                }
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
                return Task.FromResult(false);
            }
        }

        [AbpAllowAnonymous]
        public Task<int> GetPrintCount(STPrintHistoryCountDto input)
        {
            //todo 调整打印次数查询*-*
            int count = 0;
            try
            {
                var resultPrintReport = m_repositoryStReportRecord.GetAll()
               .Where(x => x.BusinessTypeId.Contains(input.BusinessTypeId))
               .WhereIf(!input.BusinessId.IsNullOrWhiteSpace(), x => x.BusinessId == input.BusinessId)
               .WhereIf(!input.ReportId.IsNullOrWhiteSpace(), x => x.ReportId == input.ReportId)
               .Where(x => x.IsPrinted)
               .Where(x => !x.IsDeleted);
                count = resultPrintReport.Count();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
            }
            //return Task.FromResult(new ListResultDto<STPrintHistory>(ObjectMapper.Map<List<STPrintHistory>>(resultPrintReport)));

            return Task.FromResult(count);
        }

    }

    public class ChangeStatus
    {
        public string reportList { get; set; }
        public int status { get; set; }
    }
}
