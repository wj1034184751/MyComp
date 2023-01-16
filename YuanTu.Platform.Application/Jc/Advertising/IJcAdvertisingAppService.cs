using YuanTu.Platform.Cash.Dto;
using YuanTu.Platform.Jc;
using YuanTu.Platform.Jc.Advertising.Dto;

namespace YuanTu.Platform.Jc
{
    public interface IJcAdvertisingAppService : IAsynPermissionAppService<Jc_Advertising, JcAdvertisingDto, string, PagedAdvertisingRequestDto, JcAdvertisingDto, JcAdvertisingDto>
    {
    }
}
