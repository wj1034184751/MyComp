using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.ST.Dto; 

namespace YuanTu.Platform.ST
{
    public interface ISTPluginFolderAppService : IAsynPermissionAppService<STPluginFolder, STPluginFolderDto, string, PagedSTPluginFolderRequestDto, STPluginFolderDto, STPluginFolderDto>
    {  
    }
}