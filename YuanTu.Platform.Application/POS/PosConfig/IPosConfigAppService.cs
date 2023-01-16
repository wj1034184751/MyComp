using YuanTu.Platform.POS.Dto; 

namespace YuanTu.Platform.POS
{
    public interface IPosConfigAppService : IAsynPermissionAppService<PosConfig, PosConfigDto, string, PagedPosConfigRequestDto, PosConfigDto, PosConfigDto>
    { 
    }
}