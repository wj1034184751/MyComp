using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Jc.Advertising.Dto;

namespace YuanTu.Platform.Jc
{
    public interface IAdvertisingAppService : IAsynPermissionAppService<Jc_Advertising, AdvertisingDto, string, ParentCustomPagedAndSortedWithOrgDto, AdvertisingDto, AdvertisingDto>
    {
    }
}
