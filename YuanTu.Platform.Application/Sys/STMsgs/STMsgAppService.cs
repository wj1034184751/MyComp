using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Linq;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys
{
    public class STMsgAppService : AsynPermissionAppService<STMsg, STMsgDto, string, STMsgCustomPagedAndSortedWithOrgDto, STMsgDto, STMsgDto>, ISTMsgAppService
    {
        private readonly IRepository<STMsg, string> m_repository;
        public STMsgAppService(IRepository<STMsg, string> repository) : base(repository)
        {
            this.m_repository = repository;
        }

        protected override IQueryable<STMsg> CreateFilteredQuery(STMsgCustomPagedAndSortedWithOrgDto input)
        {
            input.Sorting = " CreationTime DESC";

            return m_repository.GetAll()
                .Where(v=>v.STMsgCatalogId == input.Mid)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Code.Contains(input.Keyword))
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Remark.Contains(input.Keyword));
        }
    }
}
