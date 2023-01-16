using System;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using YuanTu.Platform.Sys.AbpLogs.Dto; 

namespace YuanTu.Platform.Sys.AbpLogs
{
    [AbpAuthorize]
    public class AbpLogAppService : AsynPermissionAppService<AbpLog, AbpLogDto, string, PagedAbpLogRequestDto, AbpLogDto, AbpLogDto>, IAbpLogAppService
    {
        private readonly IRepository<AbpLog, string> _repositoryAbpLog;
        public AbpLogAppService(IRepository<AbpLog, string> repository)
            : base(repository)
        {
            _repositoryAbpLog = repository;
        }

        protected override IQueryable<AbpLog> CreateFilteredQuery(PagedAbpLogRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            IQueryable<AbpLog> list = _repositoryAbpLog.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.TerminalNo.Contains(input.Keyword) || x.IP.Contains(input.Keyword) || x.Mac.Contains(input.Keyword))
                .WhereIf(!input.TraceId.IsNullOrWhiteSpace(), x => x.TraceId.Contains(input.TraceId) || x.ParentTraceId.Contains(input.TraceId))
                .WhereIf(!input.StartDate.IsNullOrWhiteSpace(), x => x.RecordTime >= Convert.ToDateTime(input.StartDate))
                .WhereIf(!input.EndDate.IsNullOrWhiteSpace(), x => x.RecordTime <= Convert.ToDateTime(input.EndDate));

            return list;
        }

        public override Task<AbpLogDto> CreateAsync(AbpLogDto input)
        {
            if (string.IsNullOrEmpty(input.TraceId))
            {
                input.TraceId = Guid.NewGuid().ToString("N");
            }

            return base.CreateAsync(input);
        }
    }
}