using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.StMaintains
{
    /// <summary>
    /// 维护人员管理的设备
    /// </summary>
    public class StMaintaintorTerminal : CustomEntity<string>
    {
        /// <summary>
        /// 维护人员
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string MaintaintorId { get; set; }

        /// <summary>
        /// 终端设备
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string TerminalId { get; set; }
    }
}