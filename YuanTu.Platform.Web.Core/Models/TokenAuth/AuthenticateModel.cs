using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;

namespace YuanTu.Platform.Models.TokenAuth
{
    public class AuthenticateModel
    {
        [Required]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string UserNameOrEmailAddress { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        public string Password { get; set; }
        
        public bool RememberClient { get; set; }

        public long OrgId { get; set; }

        public string OrgIds { get; set; }
    }
}
