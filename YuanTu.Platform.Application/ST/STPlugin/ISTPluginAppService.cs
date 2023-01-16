using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    public interface ISTPluginAppService : IAsynPermissionAppService<STPlugin, STPluginDto, string, PagedSTPluginRequestDto, STPluginDto, STPluginDto>
    { 
    }
}