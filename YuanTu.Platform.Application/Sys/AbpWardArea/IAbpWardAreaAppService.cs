 using System.Threading.Tasks;
 using Abp.Application.Services.Dto;
 using YuanTu.Platform.Sys.Dto;

namespace YuanTu.Platform.Sys
{
    public interface IAbpWardAreaAppService : IAsynPermissionAppService<AbpWardArea, AbpWardAreaDto, string, PagedAbpWardAreaRequestDto, AbpWardAreaDto, AbpWardAreaDto>
    {
        /// <summary>
        /// 根据orgid获取病区
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        Task<ListResultDto<AbpWardAreaDto>> GetAllByOrgIdAsync(long orgId);
    }
}