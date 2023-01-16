using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.StDisinfects
{
    /// <summary>
    /// 消杀数据
    /// </summary>
    public class StDisinfect : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 消杀名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string Name { get; set; }

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

        /// <summary>
        /// 应用自助机
        /// </summary>
        [StringLength(PlatformConsts.MaxLength512)]
        public string TerminalId { get; set; }

        /// <summary>
        /// 消杀前暂停时间(分)
        /// </summary>
        public int DisableTime { get; set; }

        /// <summary>
        /// 是否播放语音
        /// </summary>
        public bool PlayVoice { get; set; }

        /// <summary>
        /// 语音文本
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string VoiceText { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}