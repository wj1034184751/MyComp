using System.Threading.Tasks;
using Abp.Application.Services;
using YuanTu.Platform.Sessions.Dto;

namespace YuanTu.Platform.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
