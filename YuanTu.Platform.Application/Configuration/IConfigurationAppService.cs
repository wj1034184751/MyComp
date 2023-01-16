using System.Threading.Tasks;
using YuanTu.Platform.Configuration.Dto;

namespace YuanTu.Platform.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
