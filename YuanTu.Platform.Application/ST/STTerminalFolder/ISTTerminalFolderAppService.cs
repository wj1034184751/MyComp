using YuanTu.Platform.ST.Dto; 

namespace YuanTu.Platform.ST
{
    public interface ISTTerminalFolderAppService : IAsynPermissionAppService<STTerminalFolder, STTerminalFolderDto, string, PagedSTTerminalFolderRequestDto, STTerminalFolderDto, STTerminalFolderDto>
    {
    }
}