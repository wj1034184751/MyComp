using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.FuncConfigs
{
    /// <summary>
    /// 功能配置管理
    /// </summary>
    public class FuncConfig : ParentCustomEditEntity<string>
    {
        /// <summary>
        /// 配置编码
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string Code { get; set; }

        /// <summary>
        /// 层级码
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string LevelCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public string Value { get; set; }

        /// <summary>
        /// 指定关联配置项
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string FuncItemConfigId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; }

        /// <summary>
        /// 启用/停用
        /// </summary>
        [Required]
        public bool Enable { get; set; }

        /// <summary>
        /// 唯一全局模板
        /// </summary>
        [Required]
        public bool IsUnique { get; set; }
    }
}