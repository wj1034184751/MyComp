using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 字典管理
    /// </summary>
    public class AbpCustomEnum : ParentCustomEditEntityWithOrg<string>
    {
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code
        {
            get;
            set;
        }
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name
        {
            get;set;
        }
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ParentCode
        {
            get;
            set;
        }

        /// <summary>
        /// 图片
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ImageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 缩略图
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ThumbnailUrl
        {
            get;
            set;
        }

        public virtual int Sort
        {
            get;
            set;
        }

        /// <summary>
        /// 规则描述
        /// </summary>
        public virtual string Rule { get; set; }
    }
}