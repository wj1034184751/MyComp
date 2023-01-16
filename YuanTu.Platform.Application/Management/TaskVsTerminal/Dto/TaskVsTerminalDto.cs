using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Management.Operation.Dto;
using YuanTu.Platform.Management.Trigger.Dto;
using YuanTu.Platform.ST;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.Management.Dto
{
    public class TaskVsTerminalDto : EntityDto<string>
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

        /// <summary>
        /// 触发器列表
        /// </summary>
        public TaskTriggerDto Triggers { get; set; }

        /// <summary>
        ///操作列表
        /// </summary>
        public TaskOperationDto Operations { get; set; }

        public TaskDto Tasks { get; set; }

        public STTerminalDto Terminals { get; set; }


        #region  显示数据
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
        /// 开始计划
        /// </summary>
        public virtual string StartPlan { get; set; }
        /// <summary>
        /// 详细信息
        /// </summary>
        public virtual string TriggerDescription { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        public virtual string Operation { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public virtual string OperationDescription { get; set; }

        /// <summary>
        /// 终端名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Spec { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TerminalTypeId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        
        public virtual string Code { get; set; }

        #endregion
    }
}
