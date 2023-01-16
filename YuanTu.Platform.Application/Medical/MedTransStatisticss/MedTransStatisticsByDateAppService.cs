using System.Linq;
using Abp.Domain.Repositories;
using YuanTu.Platform.Medical.MedTransStatisticss.Dto;
using Abp.Application.Services.Dto;
using YuanTu.Platform.ST;
using Abp.Collections.Extensions;
using Abp.Extensions;
using System;
using Castle.Windsor.Diagnostics;
using Abp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using Abp.Extensions;
using Abp.Linq.Extensions;

namespace YuanTu.Platform.Medical.MedTransStatisticss
{
    public class MedTransStatisticsByDateAppService : AsynPermissionAppService<MedTransStatistics, MedTransStatisticsDto, string, MedTransStatisticsRequestDto, MedTransStatisticsDto, MedTransStatisticsDto>, IMedTransStatisticsAppService
    {
        //private readonly IRepository<STTerminal, string> _repositorySTTerminal;
        public MedTransStatisticsByDateAppService(IRepository<MedTransStatistics, string> repository)
            : base(repository)
        {
        }

        //[ActionName("GetPage")]
        //public override Task<PagedResultDto<MedTransStatisticsDto>> GetAllAsync(MedTransStatisticsRequestDto input)
        //{
        //    CheckGetAllPermission();

        //    if (string.IsNullOrEmpty(input.StartDate) && string.IsNullOrEmpty(input.EndDate))
        //    {
        //        return Task.FromResult(new PagedResultDto<MedTransStatisticsDto>());
        //    }

        //    List<MedTransStatisticsDto> templist = Repository.GetAll().Join(_repositorySTTerminal.GetAll(), med => med.TerminalNo, terminal => terminal.Id, (med, terminal) => new MedTransStatisticsDto { Id = med.Id, TerminalName = terminal.Name, FailAmt = med.FailAmt, FailCount = med.FailCount, SuccessAmt = med.SuccessAmt, SuccessCount = med.SuccessCount, MedicareType = med.MedicareType, TerminalNo = med.TerminalNo, Transdate = med.Transdate, HospId = med.HospId, AreaCode = med.AreaCode, Memo = med.Memo, TenantId = med.TenantId, IsDeleted = med.IsDeleted, Extend = med.Extend, Remark = med.Remark }).WhereIf(!input.StartDate.IsNullOrWhiteSpace(), x => Convert.ToInt32(x.Transdate) >= Convert.ToInt32(Convert.ToDateTime(input.StartDate).ToString("yyyyMMdd"))).WhereIf(!input.EndDate.IsNullOrWhiteSpace(), x => Convert.ToInt32(x.Transdate) <= Convert.ToInt32(Convert.ToDateTime(input.EndDate).ToString("yyyyMMdd"))).ToList();

        //    var list = templist.GroupBy(g => g.TerminalName).Select(e => new MedTransStatisticsDto { TerminalName = e.Key, SuccessCount = e.Sum(q => q.SuccessCount), SuccessAmt = e.Sum(q => q.SuccessAmt), FailCount = e.Sum(q => q.FailCount), FailAmt = e.Sum(q => q.FailAmt) });

        //    return Task.FromResult(new PagedResultDto<MedTransStatisticsDto>(list.Count(),list.ToList()));
        //}

        protected override IQueryable<MedTransStatistics> CreateFilteredQuery(MedTransStatisticsRequestDto input)
        {
            //if (string.IsNullOrEmpty(input.StartDate) && string.IsNullOrEmpty(input.EndDate))
            //{
            //    return null;
            //}

            return Repository.GetAll()
                .WhereIf(!input.StartDate.IsNullOrWhiteSpace(), x => Convert.ToInt32(x.Transdate) >= Convert.ToInt32(Convert.ToDateTime(input.StartDate).ToString("yyyyMMdd")))
                .WhereIf(!input.EndDate.IsNullOrWhiteSpace(), x => Convert.ToInt32(x.Transdate) <= Convert.ToInt32(Convert.ToDateTime(input.EndDate).ToString("yyyyMMdd")));
        }
    }
}