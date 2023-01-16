using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Jc
{
    /// <summary>
    /// 内容分类
    /// </summary>
    public class Jc_AdvertisingCatalog : ParentCustomEditEntityWithOrg<string>
    {
        /// <summary>
        /// 层级码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string LevelCode { get; set; }

        /// <summary>
        /// 分类编码
        /// </summary>
        [StringLength(6)]
        public string Code { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 语言包Id(暂不用)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string LanguageId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; }
    }
}
