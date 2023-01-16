using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 文档分类
    /// </summary>
    public class STDocumentCatalog : ParentCustomEditEntityWithOrg<string>
    {
        /// <summary>
        /// 层级码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string LevelCode { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 语言包Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string STLanguageId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; }
    }
}