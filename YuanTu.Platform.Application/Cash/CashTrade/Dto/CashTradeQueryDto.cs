using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Cash.Dto
{
    public class CashTradeQueryDto
    {
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// 硬盘序列号
        /// </summary>
        public string Bid { get; set; }
    }
}
