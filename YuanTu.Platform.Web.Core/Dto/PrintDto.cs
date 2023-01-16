using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Dto
{
    public class PrintDto
    {
        /// <summary>
        /// 打印数据源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 模板内容
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// 执行后脚本
        /// </summary>
        public string BeforeScript { get; set; }

        /// <summary>
        /// 执行前脚本
        /// </summary>
        public string AfterScript { get; set; }
    }
}
