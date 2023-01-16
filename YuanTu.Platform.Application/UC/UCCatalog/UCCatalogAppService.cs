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
    public class UCCatalogAppService : AsynPermissionAppService<UCCatalog, UCCatalogDto, string, PagedUCCatalogRequestDto, UCCatalogDto, UCCatalogDto>, IUCCatalogAppService
    { 
        public UCCatalogAppService(IRepository<UCCatalog, string> repository) : base(repository)
        { 
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<UCCatalogDto>> GetAllAsync(PagedUCCatalogRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            var list = await base.GetAllAsync(input); 
            return list;
        }

        protected override IQueryable<UCCatalog> CreateFilteredQuery(PagedUCCatalogRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(input.Keyword));
        } 
    }
}