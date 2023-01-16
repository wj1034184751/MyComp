using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys
{
    public class STDocumentCatalogAppService : AsynPermissionAppService<STDocumentCatalog, STDocumentCatalogDto, string, CustomPagedAndSortedWithOrgDto, STDocumentCatalogDto, STDocumentCatalogDto>, ISTDocumentCatalogAppService
    {
        private readonly IRepository<STDocumentCatalog, string> m_repository;
        public STDocumentCatalogAppService(IRepository<STDocumentCatalog, string> repository) : base(repository)
        {
            this.m_repository = repository;
        }

        protected override IQueryable<STDocumentCatalog> CreateFilteredQuery(CustomPagedAndSortedWithOrgDto input)
        {
            input.Sorting = " Sort ";

            return m_repository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword));
        }

        public override Task<STDocumentCatalogDto> CreateAsync(STDocumentCatalogDto input)
        {
            var maxcode = "";
            var parent = this.m_repository.GetAll().Where(v => v.Id == input.ParentId).FirstOrDefault();

            if (parent != null)
            {
                maxcode = parent.LevelCode;
            }

            var max = this.m_repository.GetAll().Where(v => v.ParentId == input.ParentId).OrderByDescending(v => v.LevelCode).FirstOrDefault();
            if (max == null)
            {
                input.LevelCode = maxcode + "0001";
            }
            else
            {
                var maxv = int.Parse(max.LevelCode.Right(4)) + 1;
                if (maxv > 9999)
                {
                    throw new Exception("层级码超出预设值，无法新增");
                }
                input.LevelCode = maxcode + maxv.ToString().PadLeft(4, '0');
            }

            return base.CreateAsync(input);
        }
    }
}
