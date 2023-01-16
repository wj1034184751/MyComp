using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Jc.Advertising.Dto;

namespace YuanTu.Platform.Jc
{
    public interface IAdvertisingCatalogAppService : IAsynPermissionAppService<Jc_AdvertisingCatalog, AdvertisingCatalogDto, string, CustomPagedAndSortedWithOrgDto, AdvertisingCatalogDto, AdvertisingCatalogDto>
    {
    }
}
