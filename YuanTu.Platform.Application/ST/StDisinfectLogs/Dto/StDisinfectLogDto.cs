using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.StDisinfects;

namespace YuanTu.Platform.ST
{
    [Abp.AutoMapper.AutoMap(typeof(StDisinfectLog))]
    public class StDisinfectLogDto : CustomEntityDto<string>
    {
        /// <summary>
        /// 消杀启动时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 消杀状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 自助机编号
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// 周期频率
        /// </summary>
        public string PeriodFrequency { get; set; }

        /// <summary>
        /// 周期时间
        /// </summary>
        public string PeriodTimes { get; set; }
    }
}
