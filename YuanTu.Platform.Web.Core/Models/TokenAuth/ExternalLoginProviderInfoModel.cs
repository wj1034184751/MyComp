using Abp.AutoMapper;
using YuanTu.Platform.Authentication.External;

namespace YuanTu.Platform.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
