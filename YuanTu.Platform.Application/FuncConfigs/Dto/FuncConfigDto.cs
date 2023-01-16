using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.FuncConfigs
{
    [Abp.AutoMapper.AutoMap(typeof(FuncConfig))]
    public class FuncConfigDto : ParentCustomEntityDto<string>
    {
        /// <summary>
        /// 配置编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 层级码
        /// </summary>
        public string LevelCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 指定关联配置项
        /// </summary>
        public string FuncItemConfigId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 启用/停用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 唯一全局模板
        /// </summary>
        public bool IsUnique { get; set; }
    }
}
