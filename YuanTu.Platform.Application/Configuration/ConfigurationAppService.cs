using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using YuanTu.Platform.Configuration.Dto;

namespace YuanTu.Platform.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : PlatformAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
