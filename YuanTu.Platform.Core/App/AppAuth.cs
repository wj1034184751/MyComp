using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.App
{
    public class AppAuth : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 应用名称
        /// </summary> 
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string AppName { get; set; }
        /// <summary>
        /// 应用ID
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string AppId { get; set; }

        /// <summary>
        /// 公钥
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string AppKey { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string AppSecret { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public virtual bool Enabled { get; set; }

    }
}