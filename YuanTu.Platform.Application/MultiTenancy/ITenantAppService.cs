using Abp.Application.Services;
using YuanTu.Platform.MultiTenancy.Dto;

namespace YuanTu.Platform.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

