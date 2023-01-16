using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.StFuncConfigs
{
    [Abp.AutoMapper.AutoMap(typeof(StTerminalFuncConfig))]
    public class StTerminalFuncConfigDto : ParentCustomEntityDto<string>
    {
        /// <summary>
        /// 终端ID
        /// </summary> 
        public virtual string TerminalId { get; set; }

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
        public string Name { get; set; } = "";

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 指定关联配置项
        /// </summary>
        public string StFuncItemConfigId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 启用/停用
        /// </summary>
        public bool Enable { get; set; } = true;

        /// <summary>
        /// 唯一全局模板
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// 组件类型
        /// </summary>
        public ComponentTypes ComponentType { get; set; }

        /// <summary>
        /// 同步模式（true：覆盖, false：不覆盖）
        /// </summary>
        public bool SyncMode { get; set; }

        /// <summary>
        /// 0：可写；1：模板只读；2：设备只读
        /// </summary>
        public int ReadOnly { get; set; }
        
        /// <summary>
        /// 关联全局模板Id
        /// </summary>
        public string ReferUniqueId { get; set; }

        /// <summary>
        /// 关联父级全局模板Id
        /// </summary>
        public string ReferParentUniqueId { get; set; }

        /// <summary>
        /// 关联模板Id
        /// </summary>
        public string ReferRootId { get; set; }

        /// <summary>
        /// 关联模板Id
        /// </summary>
        public string ReferSourceId { get; set; }
    }
}
