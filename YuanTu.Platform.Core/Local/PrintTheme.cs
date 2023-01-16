using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Local
{
    /// <summary>
    /// 打印主题管理
    /// </summary>
    public class PrintTheme : CustomEntity<string>
    {
        /// <summary>
         /// 编号
         /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        [Required]
        public virtual string Content { get; set; }

        /// <summary>
        /// 模板类型
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PrintTypeId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsEnable { get; set; }

        /// <summary>
        /// 执行前脚本
        /// </summary>
        public virtual string BeforeScript { get; set; }

        /// <summary>
        /// 执行前脚本
        /// </summary>
        public virtual string AfterScript { get; set; }

        /// <summary>
        /// 默认数据源
        /// </summary>
        public virtual string DataSource { get; set; }

        /// <summary>
        /// 主题分类Id
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string PrintThemeCatalogId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; }
    }
}
