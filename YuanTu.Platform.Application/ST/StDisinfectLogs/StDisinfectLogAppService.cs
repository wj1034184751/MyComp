using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.StDisinfects;

namespace YuanTu.Platform.ST
{
    public class StDisinfectLogAppService : AsynPermissionAppService<StDisinfectLog, StDisinfectLogDto, string, PagedStDisinfectLogRequestDto, StDisinfectLogDto, StDisinfectLogDto>, IStDisinfectLogAppService
    {
        private readonly IRepository<StDisinfectLog, string> _repositoryDisinfectLog;
        public StDisinfectLogAppService(IRepository<StDisinfectLog, string> repository) : base(repository)
        {
            _repositoryDisinfectLog = repository;
        }

        protected override IQueryable<StDisinfectLog> CreateFilteredQuery(PagedStDisinfectLogRequestDto input)
        {
            input.Sorting = " CreationTime DESC";

            var res = _repositoryDisinfectLog.GetAll()
                .WhereIf(!input.TerminalId.IsNullOrWhiteSpace(), x => x.TerminalId.Contains(input.TerminalId))
                .WhereIf(!input.Status.IsNullOrWhiteSpace(), x => x.Status.Contains(input.Status))
                .WhereIf(!input.PeriodFrequency.IsNullOrWhiteSpace(), x => x.PeriodFrequency.Contains(input.PeriodFrequency))
                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.CreationTime >= Convert.ToDateTime(input.StartTime))
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.CreationTime <= Convert.ToDateTime(input.EndTime + " 23:59:59"));
            return res;
        }

        [AbpAllowAnonymous]
        [ActionName("GetPage")]
        public override Task<PagedResultDto<StDisinfectLogDto>> GetAllAsync(PagedStDisinfectLogRequestDto input)
        {
            return base.GetAllAsync(input);
        }

    }
}