using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.StFuncConfigs
{
    /// <summary>
    /// 功能配置管理
    /// </summary>
    public class StFuncConfig : ParentCustomEditEntity<string>
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
        /// 唯一全局模板
        /// </summary>
        [Required]
        public bool IsUnique { get; set; }

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
        [StringLength(PlatformConsts.MaxLength32)]
        public string ReferUniqueId { get; set; }

        /// <summary>
        /// 关联父级全局模板Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string ReferParentUniqueId { get; set; }
    }

    public enum ComponentTypes
    {
        // 默认文本框
        Text = 0,
        // 数字控件
        Number = 1,
        // 是否开关
        Switch = 2,
        // 下拉框
        Dropdown = 3,
        // 单选框
        RadioButton = 4,
        // 多选框
        Checkbox = 5,
        // 图片路径
        Image = 6,
        // 多行文本
        TextArea = 7,
        // 富文本
        Html = 8,
        // 可视化布局
        Layout = 9
    }
}