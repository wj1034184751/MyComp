using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Json;
using Newtonsoft.Json;
using YuanTu.Platform.Sessions.Dto;

namespace YuanTu.Platform.Sessions
{
    public class SessionAppService : PlatformAppServiceBase, ISessionAppService
    {
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput
            {
                Application = new ApplicationInfoDto
                {
                    Version = AppVersionHelper.Version,
                    ReleaseDate = AppVersionHelper.ReleaseDate,
                    Features = new Dictionary<string, bool> { { "SignalR", true }, { "SignalR.AspNetCore", true } }
                },
                Cache =(await AppCacheHelper.UpdateCache(CacheType.UnKnown)).FromJsonString<CacheInfoDto>()
            };

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
            }

            if (AbpSession.UserId.HasValue)
            { 
                output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
            }

            return output;
        }
    }
}
