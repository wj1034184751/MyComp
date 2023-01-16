using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Medical.MedCheckAccountinfos.Dto;

namespace YuanTu.Platform.Medical.MedCheckAccountinfos
{
    public class MedCheckAccountinfoAppService : AsynPermissionAppService<MedCheckAccountinfo, MedCheckAccountinfoDto, string, MedCheckAccountinfoRequestDto, MedCheckAccountinfoDto, MedCheckAccountinfoDto>, IMedCheckAccountinfoAppService
    {
        private readonly IRepository<MedCheckAccountinfo, string> _repositoryMedCheckAccountinfo;
        public MedCheckAccountinfoAppService(IRepository<MedCheckAccountinfo, string> repository)
            : base(repository)
        {
            _repositoryMedCheckAccountinfo = repository;
        }

        /// <summary>
        /// 查询对账数据（列表和友好界面共用）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected override IQueryable<MedCheckAccountinfo> CreateFilteredQuery(MedCheckAccountinfoRequestDto input)
        {
            return _repositoryMedCheckAccountinfo.GetAll()
                .WhereIf(!input.MedicareType.IsNullOrWhiteSpace(), x => x.MedicareType == input.MedicareType)
                .WhereIf(!input.CheckAccResult.IsNullOrWhiteSpace(), x => x.CheckAccResult == input.CheckAccResult)
                .WhereIf(!input.StartDate .IsNullOrWhiteSpace(), x => Convert.ToInt32(x.CheckAccDate) >= Convert.ToInt32(Convert.ToDateTime(input.StartDate).ToString("yyyyMMdd")))
                .WhereIf(!input.EndDate.IsNullOrWhiteSpace(), x => Convert.ToInt32(x.CheckAccDate) <= Convert.ToInt32(Convert.ToDateTime(input.EndDate).ToString("yyyyMMdd")))
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
        }


        /// <summary>
        /// 月对账情况汇总
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<PagedResultDto<MedCheckAccountinfoByMonthDto>> GetDataByMonth(MedCheckAccountinfoRequestDto input)
        {
            CheckGetAllPermission();

            string yearMonth = string.IsNullOrWhiteSpace(input.YearMonth) ? DateTime.Now.ToString("yyyyMMdd").Substring(0, 6) : input.YearMonth;

            DateTime date = Convert.ToDateTime(yearMonth.Substring(0, 4) + "-" + yearMonth.Substring(4, 2) + "-" + "01");
            int daysinMonth = date.TotalDaysInMonth();
            string startDate = date.ToString("yyyyMMdd");
            string endDate = yearMonth + daysinMonth.ToString();

            List<MedCheckAccountinfo> templist = _repositoryMedCheckAccountinfo.GetAll()
                .WhereIf(true, x => Convert.ToInt32(x.CheckAccDate) >= Convert.ToInt32(startDate))
                .WhereIf(true, x => Convert.ToInt32(x.CheckAccDate) <= Convert.ToInt32(endDate)).ToList();

            if (templist?.Count > 0)
            {
                var list = templist.GroupBy(g => new { g.MedicareType, g.CheckTransType }).Select(e => new MedCheckAccountinfoByMonthDto { MedicareType = e.Key.MedicareType, CheckTransType = e.Key.CheckTransType, MedAllAmt = e.Sum(q => q.MedAllAmount), MedAllCount = e.Sum(q => q.MedAllCount), HisAllAmt = e.Sum(q => q.HisAllAmount), HisAllCount = e.Sum(q => q.HisAllCount), PluginAllAmt = e.Sum(q => q.PluginAllAmount), PluginAllCount = e.Sum(q => q.PluginAllCount), SuccessDays = e.Count(q => q.CheckAccResult == "0"), FailDays = e.Count(q => q.CheckAccResult != "0") });

                return Task.FromResult(new PagedResultDto<MedCheckAccountinfoByMonthDto>(list.Count(), list.ToList()));
            }
            else
            {
                return Task.FromResult(new PagedResultDto<MedCheckAccountinfoByMonthDto>(0, new List<MedCheckAccountinfoByMonthDto>()));
            }
        }

        /// <summary>
        /// 日对账情况列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<PagedResultDto<MedCheckDateInfoDto>> GetDateList(MedCheckAccountinfoRequestDto input)
        {
            CheckGetAllPermission();

            string yearMonth = string.IsNullOrWhiteSpace(input.YearMonth) ? DateTime.Now.ToString("yyyyMMdd").Substring(0, 6) : input.YearMonth;

            DateTime date = Convert.ToDateTime(yearMonth.Substring(0, 4) + "-" + yearMonth.Substring(4, 2) + "-" + "01");
            int daysinMonth = date.TotalDaysInMonth();
            string startDate = date.ToString("yyyyMMdd");
            string endDate = yearMonth + daysinMonth.ToString();

            List<MedCheckAccountinfo> tempList = _repositoryMedCheckAccountinfo.GetAll()
                .WhereIf(true, x => Convert.ToInt32(x.CheckAccDate) >= Convert.ToInt32(startDate))
                .WhereIf(true, x => Convert.ToInt32(x.CheckAccDate) <= Convert.ToInt32(endDate)).ToList();

            List<MedCheckDateInfoDto> Datelist = tempList.GroupBy(g => g.CheckAccDate).Select(e => new MedCheckDateInfoDto { Date = e.Key }).ToList();

            List<MedCheckDateInfoDto> retDatelist = new List<MedCheckDateInfoDto>();


            DateTime start_date = Convert.ToDateTime(startDate.Substring(0, 4) + "-" + startDate.Substring(4, 2) + "-" + startDate.Substring(6, 2)).Date;
            DateTime end_date = Convert.ToDateTime(endDate.Substring(0, 4) + "-" + endDate.Substring(4, 2) + "-" + endDate.Substring(6, 2)).Date;

            for (DateTime dt = start_date; dt <= end_date; dt = dt.AddDays(1))
            {
                List<MedCheckAccountinfo> tempListByDate = tempList.Where(p => p.CheckAccDate == dt.ToString("yyyyMMdd")).ToList();

                MedCheckDateInfoDto newDto = new MedCheckDateInfoDto();
                newDto.Date = Convert.ToInt32(dt.ToString("yyyyMMdd").Substring(6, 2)).ToString();

                if (tempListByDate == null || tempListByDate.Count == 0)
                {
                    newDto.CheckResult = "4";
                }
                else
                {

                    string checkResult = string.Empty;
                    foreach (MedCheckAccountinfo dateDto in tempListByDate)
                    {
                        checkResult += dateDto.CheckErrorType;
                    }

                    if (Convert.ToInt32(checkResult) == 0)
                    {
                        newDto.CheckResult = "0";
                    }
                    else if (checkResult.Contains("1") && checkResult.Contains("2") && checkResult.Contains("4"))
                    {
                        newDto.CheckResult = "3";
                    }
                    else if (checkResult.Contains("1") && checkResult.Contains("2"))
                    {
                        newDto.CheckResult = "3";
                    }
                    else if (checkResult.Contains("1") && checkResult.Contains("4"))
                    {
                        newDto.CheckResult = "3";
                    }
                    else if (checkResult.Contains("2") && checkResult.Contains("4"))
                    {
                        newDto.CheckResult = "3";
                    }
                    else if (checkResult.Contains("1"))
                    {
                        newDto.CheckResult = "1";
                    }
                    else if (checkResult.Contains("2"))
                    {
                        newDto.CheckResult = "2";
                    }
                    else if (checkResult.Contains("4"))
                    {
                        newDto.CheckResult = "4";
                    }
                }

                retDatelist.Add(newDto);
            }//end foreach

            return Task.FromResult(new PagedResultDto<MedCheckDateInfoDto>(retDatelist.Count(), retDatelist));


        }

        /// <summary>
        /// 根据日期获取日对账明细
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<PagedResultDto<MedCheckAccountinfoDto>> GetContentByDate(MedCheckAccountinfoRequestDto input)
        {
            CheckGetAllPermission();

            if (string.IsNullOrWhiteSpace(input.Date))
            {
                return Task.FromResult(new PagedResultDto<MedCheckAccountinfoDto>());
            }

            string strDate = input.Date.Substring(0,6) + input.Date.Substring(6).PadLeft(2,'0');

            List<MedCheckAccountinfoDto> list = _repositoryMedCheckAccountinfo.GetAll()
                .WhereIf(true, x => x.CheckAccDate == strDate)
                .ToList().OrderBy(p => p.MedicareType).ThenBy(p => p.CheckTransType).MapTo<List<MedCheckAccountinfoDto>>();


            return Task.FromResult(new PagedResultDto<MedCheckAccountinfoDto>(list.Count(), list));
        }
    }
}
