using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;
using YuanTu.Platform.StFuncConfigs;

namespace YuanTu.Platform.Sys
{
    public class AbpUserEnum : ParentCustomEditEntityWithOrg<string>
    {
         /// <summary>
         /// 配置编码
         /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>\
        [StringLength(PlatformConsts.MaxLength255)]
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
        /// 同步模式(0：追加, 1：同值覆盖, 2：覆盖)
        /// </summary>
        [Required]
        public int SyncMode { get; set; }

        /// <summary>
        /// 2：可写；1：机构只读；0：设备只读
        /// </summary>
        [Required]
        public int ReadOnly { get; set; }

        /// <summary>
        /// 层级码
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string LevelCode { get; set; }
    }
}
