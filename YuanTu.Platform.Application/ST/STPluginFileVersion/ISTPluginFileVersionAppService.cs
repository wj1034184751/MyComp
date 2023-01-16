using System.Threading.Tasks;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{  
    /// <summary>
    /// 文件版本
    /// </summary>
    public interface ISTPluginFileVersionAppService : IAsynPermissionAppService<STPluginFileVersion, STPluginFileVersionDto, string, PagedSTPluginFileVersionDto, STPluginFileVersionDto, STPluginFileVersionDto>
    {
        Task<string> GetFileListAsync(string id);
        /// <summary>
        /// 回退版本号
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> RollbackVersionAsync(dynamic data);
    }
}
