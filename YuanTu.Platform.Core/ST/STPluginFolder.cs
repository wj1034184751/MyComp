using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    /// <summary>
    /// 插件文件夹
    /// </summary>
    public class STPluginFolder : ParentCustomEditEntityWithOrg<string>
    {
        /// <summary>
        /// 文件夹名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 关联文件ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string FileId { get; set; }

        /// <summary>
        /// 大小
        /// </summary> 
        public virtual long FileSize { get; set; }

        /// <summary>
        /// 哈希码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string HashCode { get; set; } 

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ExtendId { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [StringLength(PlatformConsts.MaxLength1024)]
        public virtual string FilePath { get; set; }
    }
}