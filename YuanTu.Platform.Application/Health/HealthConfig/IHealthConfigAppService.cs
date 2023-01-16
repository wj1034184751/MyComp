using System.Threading.Tasks;
using YuanTu.Platform.Health.Dto;

namespace YuanTu.Platform.Health
{
    public interface IHealthConfigAppService : IAsynPermissionAppService<HealthConfig, HealthConfigDto, string, PagedHealthConfigRequestDto, HealthConfigDto, HealthConfigDto>
    {
        Task<bool> BatchActiveAsync(dynamic data);
    }
}