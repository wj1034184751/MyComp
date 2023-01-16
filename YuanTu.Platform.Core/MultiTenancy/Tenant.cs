using Abp.MultiTenancy;
using YuanTu.Platform.Authorization.Users;

namespace YuanTu.Platform.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
