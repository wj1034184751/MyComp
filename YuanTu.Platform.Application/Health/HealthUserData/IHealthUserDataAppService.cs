using System.Threading.Tasks;
using YuanTu.Platform.Health.Dto;

namespace YuanTu.Platform.Health
{
    public interface IHealthUserDataAppService : IAsynPermissionAppService<HealthUserData, HealthUserDataDto, string, PagedHealthUserDataRequestDto, HealthUserDataDto, HealthUserDataDto>
    {
        /// <summary>
        /// 根据条件统计
        /// </summary> 
        /// <returns></returns>
        Task<HealthStatisticsDto> GetHealthStatisticsAsync(HealthStatisticsInputDto input);
    }
}