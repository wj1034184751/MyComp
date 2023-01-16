using YuanTu.Platform.UC.Dto;

namespace YuanTu.Platform.UC
{
    public interface IUCCatalogAppService : IAsynPermissionAppService<UCCatalog, UCCatalogDto, string, PagedUCCatalogRequestDto, UCCatalogDto, UCCatalogDto>
    { 
    }
}