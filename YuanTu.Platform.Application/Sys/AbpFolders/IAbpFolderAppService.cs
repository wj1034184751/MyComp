using YuanTu.Platform.Sys.AbpFolders.Dto; 

namespace YuanTu.Platform.Sys.AbpFolders
{
    public interface IAbpFolderAppService : IAsynPermissionAppService<AbpFolder, AbpFolderDto, string, PagedAbpFolderRequestDto, AbpFolderDto, AbpFolderDto>
    {
    }
}