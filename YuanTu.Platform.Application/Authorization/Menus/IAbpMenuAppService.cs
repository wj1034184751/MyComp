using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Authorization.Menus.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Authorization.Menus
{
    public interface IAbpMenuAppService : IAsynPermissionAppService<AbpMenu, AbpMenuDto, string, CustomPagedAndSortedDto, AbpMenuDto, AbpMenuDto>
    {
        /// <summary>
        /// 根据用户ID获取菜单
        /// </summary>
        /// <param name="uid">用户ID</param>
        /// <returns></returns>
        Task<ListResultDto<AbpMenuDto>> GetAllByUserIdAsync(int uid);
    }
}
