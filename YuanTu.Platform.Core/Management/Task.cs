using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Management
{
    /// <summary>
    /// 任务计划管理器
    /// </summary>
    public class Task : CustomEntityWithOrg<string>
    {
        
        /// <summary>
        /// 计划名称
        /// </summary>
        [StringLength(100)]
        public virtual string TaskName { get; set; }
        /// <summary>
        /// 状态  1 启用 2 准备就绪 3 禁用
        /// </summary>
        [StringLength(10)]
        public virtual string Status { get; set; }
        /// <summary>
        /// 触发器
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TriggerId { get; set; }

        /// <summary>
        /// 操作  
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string OperationId { get; set; }
        /// <summary>
        /// 下次运行时间
        /// </summary>

        public virtual DateTime NextStartTime { get; set; }

        /// <summary>
        /// 上次运行时间
        /// </summary>

        public virtual DateTime LastStartTime { get; set; }
        /// <summary>
        /// 上次运行结果
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string LastStartResult { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Description { get; set; }

      


    }
}
