using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    /// <summary>
    /// 终端文件夹
    /// </summary>
    public class STTerminalFolder : ParentCustomEditEntityWithOrg<string>
    {
        /// <summary>
        /// 文件夹名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; } 

        /// <summary>
        /// 扩展字段
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ExtendId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public virtual int Level { get; set; }
    }
}