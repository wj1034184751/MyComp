using System.Threading.Tasks;
using Abp.Application.Services;
using YuanTu.Platform.Authorization.Accounts.Dto;

namespace YuanTu.Platform.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
