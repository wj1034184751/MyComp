using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace YuanTu.Platform.Local.Dto
{
    /// <summary>
    /// 打印模板管理
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(PrintTemplate))]
    public class PrintTemplateDto : PrintTemplateBaseDto<string>
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// 模板类型
        /// </summary>
        [Required]
        public string PrintTypeId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

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
    }
}
