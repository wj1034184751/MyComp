using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.StFuncConfigs
{
    public class StTerminalFuncConfig : ParentCustomEditEntity<string>
    {
        /// <summary>
        /// 终端ID
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string TerminalId { get; set; }

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
        /// </summary>\
        [StringLength(PlatformConsts.MaxLength1024)]
        public string Value { get; set; }

        /// <summary>
        /// 指定关联配置项
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string StFuncItemConfigId { get; set; }

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
        /// 组件类型
        /// </summary>
        [Required]
        public ComponentTypes ComponentType { get; set; }

        /// <summary>
        /// 同步模式（true：覆盖, false：追加）
        /// </summary>
        [Required]
        public bool SyncMode { get; set; }

        /// <summary>
        /// 0：可写；1：模板只读；2：设备只读
        /// </summary>
        [Required]
        public int ReadOnly { get; set; }

        /// <summary>
        /// 关联全局模板明细Id
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string ReferUniqueId { get; set; }

        /// <summary>
        /// 关联父级全局模板Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string ReferParentUniqueId { get; set; }

        /// <summary>
        /// 关联模板Id
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string ReferRootId { get; set; }

        /// <summary>
        /// 关联模板明细Id
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string ReferSourceId { get; set; }
    }
}
