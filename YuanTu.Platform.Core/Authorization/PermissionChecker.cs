using Abp.Authorization;
using YuanTu.Platform.Authorization.Roles;
using YuanTu.Platform.Authorization.Users;

namespace YuanTu.Platform.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
