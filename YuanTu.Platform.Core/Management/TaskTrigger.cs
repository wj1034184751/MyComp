using Abp.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Management
{
    public class TaskTrigger : Entity<string>
    {
        /// <summary>
        /// 开始计划
        /// </summary>
        [StringLength(100)]
        public virtual string StartPlan { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 对应的任务
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TaskId { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Description { get; set; }

        /// <summary>
        /// 执行频率   一次，每天，每周，每月
        /// </summary>
        [StringLength(50)]
        public virtual string Frequency { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime StartTime { get; set; }

        /// <summary>
        /// 间隔时间
        /// </summary>
        [StringLength(10)]
        public virtual string Interval { get; set; }

        /// <summary>
        /// 间隔单位
        /// </summary>
        [StringLength(10)]
        public virtual string IntervalUnit { get; set; }
        /// <summary>
        /// 具体执行工作日(每周特用)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DetailWeek { get; set; }

        /// <summary>
        /// 具体执行工作日月(每月特用)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DetailMonth { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        
        public virtual DateTime ExpectTime { get; set; }
        /// <summary>
        /// 是否延迟
        /// </summary>
        public virtual bool IsDelay { get; set; }
        /// <summary>
        /// 任务延迟时间
        /// </summary>
        [StringLength(10)]
        public virtual string Delay { get; set; }

        /// <summary>
        /// 任务延迟时间单位
        /// </summary>
        [StringLength(10)]
        public virtual string DelayUnit { get; set; }
        /// <summary>
        /// 是否重复
        /// </summary>

        public virtual bool IsRepeat { get; set; }

        /// <summary>
        /// 重复间隔   1小时，五分钟，十分钟……
        /// </summary>
        [StringLength(10)]
        public virtual string RepeatInterval { get; set; }

        /// <summary>
        /// 重复间隔单位
        /// </summary>
        [StringLength(10)]
        public virtual string RepeatIntervalUnit { get; set; }
        /// <summary>
        /// 重复持续时间  1天，12小时，无期限
        /// </summary>
        [StringLength(10)]
        public virtual string RepeatLastTime { get; set; }


        /// <summary>
        /// 具体执行工作日月(每月特用)
        /// </summary>
        public virtual string DetailMonthDay { get; set; }


        /// <summary>
        /// 登录时操作用户
        /// </summary>
        public virtual string PerUser { get; set; }


    }
}
