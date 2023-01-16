using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Local
{
    /// <summary>
    /// 打印主题分类
    /// </summary>
    public class PrintThemeCatalog : ParentCustomEditEntity<string>
    {
        /// <summary>
        /// 层级码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string LevelCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; }
    }
}
