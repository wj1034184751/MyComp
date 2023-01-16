using System.ComponentModel.DataAnnotations; 
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Authorization.Menus
{
    /// <summary>
    /// 菜单权限
    /// </summary>
    public class AbpMenuPermission: CustomCreationEntity<long>
    {
        /// <summary>
        /// 菜单ID
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string MenuId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [Required]
        public virtual int RoleId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public virtual long? UserId { get; set; }
    }
}