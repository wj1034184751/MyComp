using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.UC
{
    public class UCBlog : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Title { get; set; }
        /// <summary>
        ///  分类
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string CatalogId { get; set; }
        /// <summary>
        /// 正文
        /// </summary>
        [Required]
        public virtual string Content { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Tag { get; set; }
        /// <summary>
        /// 可见级别
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string VisibleLevel { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [StringLength(PlatformConsts.MaxLength20)]
        public virtual string Author { get; set; }
    }
}