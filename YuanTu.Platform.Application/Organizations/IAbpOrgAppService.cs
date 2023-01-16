using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Organizations.Dto; 

namespace YuanTu.Platform.Organizations
{
    public interface IAbpOrgAppService : IAsynPermissionAppService<AbpOrg, AbpOrgDto, long, PagedAbpOrgResultRequestDto, AbpOrgDto, AbpOrgDto>
    {
        /// <summary>
        /// 获取机构信息
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<AbpOrgExDto>> GetOrgsAsync();
        /// <summary>
        /// 根据用户名获取机构信息
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<AbpOrgExDto>> GetOrgsByUidAsync(string u);
        /// <summary>
        /// 获取机构信息(供外部使用)
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<AbpExtOrgDto>> GetExtOrgsAsync();
    }
}