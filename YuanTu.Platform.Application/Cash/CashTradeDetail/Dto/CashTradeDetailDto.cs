using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Cash.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(CashTradeDetail))]
    public class CashTradeDetailDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 交易ID
        /// </summary>
        public string CashTradeId { get; set; }

        /// <summary>
        /// 投入币值
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string LotId { get; set; }

        /// <summary>
        /// 追溯流水号
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 充值流水号
        /// </summary>
        public string RechargeId { get; set; }
    }
}
