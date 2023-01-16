using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Cash
{
    /// <summary>
    /// 现金交易明细
    /// </summary>
    public class CashTradeDetail : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 交易ID
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string CashTradeId { get; set; }

        /// <summary>
        /// 投入币值
        /// </summary>
        public virtual int Money { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string LotId { get; set; }

        /// <summary>
        /// 追溯流水号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TraceId { get; set; }

        /// <summary>
        /// 充值流水号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string RechargeId { get; set; }
    }
}
