using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.StMaintains
{
    /// <summary>
    /// 维护操作日志
    /// </summary>
    public class StMaintainLog : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 终端ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string TerminalId { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public string TerminalCode { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 运维人员Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string StMaintaintorId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string IdNo { get; set; }

        /// <summary>
        /// 射频卡号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public string CardNo { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string Phone { get; set; }

        /// <summary>
        /// 就诊号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string PatientId { get; set; }

        /// <summary>
        /// 来源类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string SourceTypeId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string OperateTypeId { get; set; }
    }
}