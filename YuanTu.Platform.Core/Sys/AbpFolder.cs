using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 文件夹
    /// </summary>
    public class AbpFolder : ParentCustomEditEntityWithOrg<string>
    {
        /// <summary>
        /// 文件夹名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 文件夹类型
        /// </summary>
        [Required] 
        public virtual FolderEnum FolderType { get; set; } = FolderEnum.Terminal;

        /// <summary>
        /// 扩展字段
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ExtendId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }
    }
}