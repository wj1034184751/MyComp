using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.StDisinfects;

namespace YuanTu.Platform.ST
{
    [Abp.AutoMapper.AutoMap(typeof(StDisinfect))]
    public class StDisinfectDto : CustomEntityDto<string>
    {
        /// <summary>
        /// 消杀名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 周期频率
        /// </summary>
        public string PeriodFrequency { get; set; }

        /// <summary>
        /// 周期时间
        /// </summary>
        public string PeriodTimes { get; set; }

        /// <summary>
        /// 应用自助机
        /// </summary>
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
        public string VoiceText { get; set; }
        
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
