using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.UC.Dto;

namespace YuanTu.Platform.UC
{
    [AbpAuthorize]
    public class UCBlogAppService : AsynPermissionAppService<UCBlog, UCBlogDto, string, PagedUCBlogRequestDto, UCBlogDto, UCBlogDto>, IUCBlogAppService
    {
        private readonly IRepository<UCCatalog, string> _catalogRepository;
        public UCBlogAppService(IRepository<UCBlog, string> repository, IRepository<UCCatalog, string> catalogRepository) : base(repository)
        {
            _catalogRepository = catalogRepository;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<UCBlogDto>> GetAllAsync(PagedUCBlogRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            var list = await base.GetAllAsync(input);
            var catalogs = await _catalogRepository.GetAllListAsync();
            foreach (var blog in list.Items)
            {
                var catalog = catalogs.Find(s => s.Id.Equals(blog.CatalogId));
                if (catalog != null)
                    blog.Catalog = new UCCatalogDto { Id = catalog.Id, Name = catalog.Name };
            }

            return list;
        }

        [AbpAllowAnonymous]
        public override Task<UCBlogDto> GetAsync(EntityDto<string> input)
        {
            return base.GetAsync(input);
        }

        protected override IQueryable<UCBlog> CreateFilteredQuery(PagedUCBlogRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                    x => x.Title.Contains(input.Keyword)).Select(s => new UCBlog { Id = s.Id, Title = s.Title, Tag = s.Tag, Author = s.Author, CatalogId = s.CatalogId, CreationTime = s.CreationTime });
        }
    }
}