using System.Threading.Tasks;
using YuanTu.Platform.App.Dto; 

namespace YuanTu.Platform.App
{
    public interface IAppAuthAppService : IAsynPermissionAppService<AppAuth, AppAuthDto, string, PagedAppAuthRequestDto, AppAuthDto, AppAuthDto>
    {
        /// <summary>
        /// 根据APPID获取实体
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        Task<AppAuthDto> GetByAppIdAsync(string appId);

        /// <summary>
        /// 批量启用
        /// </summary> 
        /// <param name="data">包含以下字段：ids  status</param>
        /// <returns></returns>
        Task<bool> BatchActiveAsync(dynamic data);
    }
}