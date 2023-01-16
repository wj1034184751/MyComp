
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Extensions;
using Abp.Json;
using Abp.Linq.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Local.StReportRecord.Dto;
using YuanTu.Platform.Local.StReportRecord.Rto;
using YuanTu.Platform.ST;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.Local
{
    /// <summary>
    /// 报告记录
    /// 作者: 系统用户
    /// 生成时间: 2022年07月19日 11:47:42
    /// </summary>
    [AbpAuthorize]
    public class STReportRecordAppService : AsynPermissionAppService<STReportRecord, STReportRecordDto, string, PagedSTReportRecordRequestDto, STReportRecordDto, STReportRecordDto>, ISTReportRecordAppService
    {
        private readonly IRepository<AbpCustomEnum, string> _repositoryEnum;
        private readonly IRepository<STPrintHistory, string> m_repositorySTPrintHistory;
        private readonly IRepository<STReportRecord, string> m_repository;
        public STReportRecordAppService(IRepository<STReportRecord, string> repository
            , IRepository<STPrintHistory, string> repositorySTPrintHistory
            , IRepository<AbpCustomEnum, string> repositoryEnum
            ) : base(repository)
        {
            this._repositoryEnum = repositoryEnum;
            this.m_repository = repository;
            this.m_repositorySTPrintHistory = repositorySTPrintHistory;

        }

        #region 网关接口 




        [AbpAllowAnonymous]
        public Task<StReportRecordRto> UpLoadReportData(ReportData input)
        {
            StReportRecordRto stRto = new StReportRecordRto();
            stRto.msg += "接收0 " + DateTime.Now.ToString("HH:mm:ss:ffff") + "\r\n";
            try
            {
                List<ReportRecord> listPacs = new List<ReportRecord>();
                if (input.code != 0)
                {
                    stRto.success = false;
                    stRto.msg = $"Code不正确{input.code}";
                    return Task.FromResult(stRto);
                }
                listPacs = input.data;
                if (listPacs == null || listPacs.Count == 0)
                {
                    stRto.success = false;
                    stRto.msg = $"参数不正确:没有data数据";
                    return Task.FromResult(stRto);
                }
                 
               
                List<STPrintHistory> pacsUpdate = new List<STPrintHistory>();
                List<ReportRecord> pacsInsert = new List<ReportRecord>();
                var colorListName = this._repositoryEnum.GetAll().Where(P => P.ParentCode == "ColorPrint").ToList();
                stRto.msg += $"数量{listPacs.Count} 数据处理1  " + DateTime.Now.ToString("HH:mm:ss:ffff") + "\r\n";

                //串行
                foreach (var item in listPacs)
                {
                    if (colorListName.Where(p => p.Name == item.CheckItem).FirstOrDefault() != null)
                    {
                        //判断上传的数据checkitem(检查项)是否与数据库中保存的相片打印检查项相等
                        item.PrintType = PrinterType.PhotoReport;
                    }
                    else
                    {
                        item.PrintType = PrinterType.Report;
                    }
                    var exist = m_repositorySTPrintHistory.GetAll().FirstOrDefault(p => p.ReportId == item.CheckNo);
                    if (exist != null)
                    {
                        exist.CheckStatus = item.CheckStatus;
                        exist.ReportStatus = item.ExtendMap.ReportStatus;
                        exist.ReportIntranetUrl = exist.PrintFile = item.ReportIntranetUrl;
                        exist.ReportTime = item.ReportTime ?? DateTime.Now;
                        exist.PrintType = item.PrintType;
                        exist.ReportName = item.CheckItem;
                        pacsUpdate.Add(exist);
                    }
                    else
                    {

                        //通过checkItem判断打印类型
                        item.Id = Guid.NewGuid().ToString("N");
                        pacsInsert.Add(item);
                    }
                }


                ////并行
                //Parallel.ForEach(listPacs, new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount }, item =>
                //{
                //    if (colorListName.Where(p => p.Name == item.CheckItem).FirstOrDefault() != null)
                //    {
                //        //判断上传的数据checkitem(检查项)是否与数据库中保存的相片打印检查项相等
                //        item.PrintType = PrinterType.PhotoReport;
                //    }
                //    else
                //    {
                //        item.PrintType = PrinterType.Report;
                //    }
                //    var exist = m_repositorySTPrintHistory.GetAll().FirstOrDefault(p => p.ReportId == item.CheckNo);
                //    if (exist != null)
                //    {
                //        exist.CheckStatus = item.CheckStatus;
                //        exist.ReportStatus = item.ExtendMap.ReportStatus;
                //        exist.ReportIntranetUrl = exist.PrintFile = item.ReportIntranetUrl;
                //        exist.ReportTime = item.ReportTime ?? DateTime.Now;
                //        exist.PrintType = item.PrintType;
                //        exist.ReportName = item.CheckItem;
                //        pacsUpdate.Add(exist);
                //    }
                //    else
                //    {

                //        //通过checkItem判断打印类型
                //        item.Id = Guid.NewGuid().ToString("N");
                //        pacsInsert.Add(item);
                //    }
                //});

                stRto.msg += "筛选处理 " + DateTime.Now.ToString("HH:mm:ss:ffff") + "\r\n";
                if (pacsUpdate.Count > 0)
                {
                    m_repositorySTPrintHistory.GetDbContext().BulkUpdate(pacsUpdate);
                }
                stRto.msg += "更新处理1 " + DateTime.Now.ToString("HH:mm:ss:ffff") + "\r\n";
                if (pacsInsert.Count > 0)
                {
                    m_repositorySTPrintHistory.GetDbContext().BulkInsert(ObjectMapper.Map<List<STPrintHistory>>(pacsInsert));
                }
                stRto.msg += "新增处理 " + DateTime.Now.ToString("HH:mm:ss:ffff") + "\r\n";
            }
            catch (Exception ex)
            {
                stRto.success = false;
                stRto.msg = ex.ToString();
                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
                return Task.FromResult(stRto);
            }
            return Task.FromResult(stRto);
        }


        [AbpAllowAnonymous]
        public Task<StReportRecordRto> GetReportRecord(StQueryReportRecordDto input)
        {
            StReportRecordRto stRto = new StReportRecordRto();
            stRto.data = new List<StQueryReportRecordRto>();
            try
            {
                if (string.IsNullOrEmpty(input.StartTime))
                {
                    stRto.success = false;
                    stRto.msg = $"开始时间为必填项";
                    return Task.FromResult(stRto);
                }
                if (string.IsNullOrEmpty(input.EndTime))
                {
                    input.EndTime = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
                }

                if (!DateTime.TryParse(input.StartTime, out DateTime startTime))
                {
                    stRto.success = false;
                    stRto.msg = $"开始时间转换异常:入参格式错误";
                    return Task.FromResult(stRto);
                }
                if (!DateTime.TryParse(input.EndTime, out DateTime endTime))
                {
                    stRto.success = false;
                    stRto.msg = $"结束时间转换异常:入参格式错误";
                    return Task.FromResult(stRto);
                }


                var allPasData = m_repositorySTPrintHistory.GetAll()
                    .Where(x => x.ReportTime >= startTime)
                    .Where(x => x.ReportTime <= endTime)
                    .Where(x => x.PrintStatus == 0)
                    .WhereIf(!input.ReportId.IsNullOrWhiteSpace(), x => x.ReportId == input.ReportId)
                    .WhereIf(!input.PatientId.IsNullOrWhiteSpace(), x => x.PatientId == input.PatientId)
                    .WhereIf(input.ReportType != null, x => x.ReportType == input.ReportType);

                if (allPasData.Count() == 0)
                {
                    stRto.success = false;
                    stRto.msg = $"没有查询到数据";
                    return Task.FromResult(stRto);
                }

                stRto.data = ObjectMapper.Map<List<StQueryReportRecordRto>>(allPasData);

            }
            catch (Exception ex)
            {
                stRto.success = false;
                stRto.msg = ex.ToString();

                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
                return Task.FromResult(stRto);
            }
            return Task.FromResult(stRto);
        }

        /// <summary>
        /// 根据报告Id获取对应pacs报告
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public Task<STPrintHistory> GetReportById(StQueryReportRecordDto input)
        {
            var pasData = m_repositorySTPrintHistory.GetAll().Where(p => p.ReportId == input.ReportId).FirstOrDefault();
            // return Task.FromResult(new ListResultDto<STPrintHistory>(pasData));
            return Task.FromResult(pasData);
        }

        #endregion


        #region  vue接口



        protected override IQueryable<STReportRecord> CreateFilteredQuery(PagedSTReportRecordRequestDto input)
        {
            input.Sorting = " PrintTime DESC";
            return m_repository.GetAll()
                .WhereIf((input.OrgId != null && input.OrgId != 0), x => x.OrgId == input.OrgId)
                .WhereIf(!input.Reportid.IsNullOrWhiteSpace(), x => x.ReportId.Contains(input.Reportid.Trim()))
                .WhereIf(!input.Patientname.IsNullOrWhiteSpace(), x => x.PatientName.Contains(input.Patientname.Trim()))
                .WhereIf(!input.PrinterName.IsNullOrWhiteSpace(), x => x.PrinterName.Contains(input.PrinterName.Trim()))
                .WhereIf(!input.IdCardNo.IsNullOrWhiteSpace(), x => x.IdCardNo.Contains(input.IdCardNo.Trim()))
                .WhereIf(!input.traceId.IsNullOrWhiteSpace(), x => x.TraceId.Contains(input.traceId.Trim()))
                .WhereIf(!input.stTerminalId.IsNullOrWhiteSpace(), x => x.StTerminalId.Contains(input.stTerminalId.Trim()))
                .WhereIf(!input.ReportType.IsNullOrWhiteSpace()&&input.ReportType !="0", x => x.BusinessTypeId.Substring(0,2) == input.ReportType)
                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.PrintTime >= Convert.ToDateTime(input.StartTime))
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.PrintTime <= Convert.ToDateTime(input.EndTime + " 23:59:59"));
        }
        [ActionName("GetPage")]
        public override Task<PagedResultDto<STReportRecordDto>> GetAllAsync(PagedSTReportRecordRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        #endregion
    }
}
