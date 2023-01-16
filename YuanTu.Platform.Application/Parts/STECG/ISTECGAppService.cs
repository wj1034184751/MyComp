using YuanTu.Platform.Parts.Dto;

namespace YuanTu.Platform.Parts
{
    public interface ISTECGAppService : IAsynPermissionAppService<STECG, STECGDto, string, PagedSTECGRequestDto, STECGDto, STECGDto>
    {
    }
}