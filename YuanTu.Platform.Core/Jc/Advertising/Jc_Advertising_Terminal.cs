using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Jc
{
    /// <summary>
    /// 投放设备清单（建议缓存）
    /// </summary>
    public class Jc_Advertising_Terminal : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 投放内容Id
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Jc_AdvertisingId { get; set; }

        /// <summary>
        /// 投放设备Id
        /// </summary>
        [Required]
        [StringLength(32)]
        public string StTerminalId { get; set; }
    }
}
