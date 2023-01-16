using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Management
{
    /// <summary>
    /// 任务触发计划
    /// </summary>
    public class TaskDetail : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 任务开始计划：每天，每周，每月，一次，计算机启动时，当前用户登录时，当特定事件被记录时等
        /// </summary>
        [StringLength(100)]
        public virtual string StartPlan { get; set; }

        /// <summary>
        /// 开始时刻
        /// </summary>
        [StringLength(100)]
        public virtual DateTime StartTime { get; set; }

        /// <summary>
        ///结束时刻
        /// </summary>
        [StringLength(100)]
        public virtual DateTime EndTime { get; set; }
        /// <summary>
        /// 时间间隔
        /// </summary>

        [StringLength(100)]
        public virtual string Interval { get; set; }
        /// <summary>
        /// 间隔单位 天/周
        /// </summary>
        [StringLength(100)]
        public virtual string Unit { get; set; }

        /// <summary>
        /// 具体更新时间  星期几   每周专用
        /// </summary>
        [StringLength(100)]
        public virtual string DetailWeek { get; set; }

        /// <summary>
        /// 具体更新月份   每月专用
        /// </summary>
        [StringLength(100)]
        public virtual string DetailMonth { get; set; }

        /// <summary>
        /// 是否可延迟
        /// </summary>
        public virtual bool IsDelay { get; set; }
        /// <summary>
        /// 延迟时间
        /// </summary>

        [StringLength(100)]
        public virtual string DelayTime { get; set; }
        /// <summary>
        /// 是否重复执行
        /// </summary>

        [StringLength(100)]
        public virtual string IsRepeat { get; set; }
        /// <summary>
        /// 重复执行间隔
        /// </summary>

        [StringLength(100)]
        public virtual string RepeatInterval { get; set; }
        /// <summary>
        /// 重复任务持续时间
        /// </summary>

        [StringLength(100)]
        public virtual string  RepeatLastTime { get; set; }

        /// <summary>
        /// 任务的运行时间超过特定时间不再执行
        /// </summary>

        [StringLength(100)]
        public virtual bool IsImplement { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
         
        public virtual DateTime ExpireTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsEnable { get; set; }
    }
}
