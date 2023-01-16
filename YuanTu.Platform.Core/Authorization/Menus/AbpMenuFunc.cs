using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Authorization.Menus
{
    /// <summary>
    /// 功能管理
    /// </summary>
    public class AbpMenuFunc : CustomEntityWithOrg<string>
    {
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string MenuId
        {
            get;
            set;
        }
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code
        {
            get;
            set;
        }
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name
        {
            get;
            set;
        }
    }
}