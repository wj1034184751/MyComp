using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YuanTu.Platform.Management
{
    public class TaskVsTerminal : Entity<string>
    {
        /// <summary>
        /// 开始计划
        /// </summary>
        public virtual string TaskId { get; set; }

        /// <summary>
        /// 开始计划
        /// </summary>
        
        public virtual string TriggerId { get; set; }

        /// <summary>
        /// 开始计划
        /// </summary>
        public virtual string OperationId { get; set; }

        /// <summary>
        /// 终端id
        /// </summary>
        public virtual string TerminalId { get; set; }

      
    }
}
