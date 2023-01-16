using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys
{
    public class STDocumentAppService : AsynPermissionAppService<STDocument, STDocumentDto, string, ParentCustomPagedAndSortedWithOrgDto, STDocumentDto, STDocumentDto>, ISTDocumentAppService
    {
        private readonly IRepository<STDocument, string> m_repository;
        private readonly IRepository<STDocumentCatalog, string> m_catalogRepository;

        public STDocumentAppService(IRepository<STDocument, string> repository, IRepository<STDocumentCatalog, string> catalogRepository) : base(repository)
        {
            this.m_repository = repository;
            this.m_catalogRepository = catalogRepository;
        }

        protected override IQueryable<STDocument> CreateFilteredQuery(ParentCustomPagedAndSortedWithOrgDto input)
        {
            input.Sorting = " CreationTime DESC";

            return m_repository.GetAll()
                .Where(v => v.STDocumentCatalogId == input.Mid)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Caption.Contains(input.Keyword));
        }

        [AbpAllowAnonymous]
        public async Task<ListResultDto<STDocumentCatalogDto>> GetHelpDocument()
        {
            var list = await m_catalogRepository.GetAllListAsync();

            var doc = await m_repository.GetAllListAsync();

            list = list.OrderBy(v => v.Sort).ToList();
            
            list.AddRange(doc.Select(v => new STDocumentCatalog() { Id = v.Id, ParentId = v.STDocumentCatalogId, Name = v.Caption }));

            return new ListResultDto<STDocumentCatalogDto>(ObjectMapper.Map<List<STDocumentCatalogDto>>(list));
        }
    }
}
