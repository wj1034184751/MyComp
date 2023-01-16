using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using YuanTu.Platform.Authorization.Users;

namespace YuanTu.Platform.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        public const int MaxDescriptionLength = 5000;

        public Role()
        {
        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {
        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {
        }

        [StringLength(MaxDescriptionLength)]
        public virtual string Description {get; set;}
    }
}
