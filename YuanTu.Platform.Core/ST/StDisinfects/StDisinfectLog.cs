using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.StDisinfects
{
    /// <summary>
    /// 消杀日志
    /// </summary>
    public class StDisinfectLog : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 消杀启动时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 消杀状态
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string Status { get; set; }

        /// <summary>
        /// 自助机编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength512)]
        public string TerminalId { get; set; }

        /// <summary>
        /// 周期频率
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string PeriodFrequency { get; set; }

        /// <summary>
        /// 周期时间
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string PeriodTimes { get; set; } 
    }
}