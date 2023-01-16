using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Cash
{
    /// <summary>
    /// 现金交易
    /// </summary>
    public class CashTrade : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 钱箱状态
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Status { get; set; }

        /// <summary>
        /// 钱箱状态
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string StatusText { get; set; }

        /// <summary>
        /// 支付金额(分)
        /// </summary>
        public virtual int TotalMoney { get; set; }

        /// <summary>
        /// 病人ID
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PatientId { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PatientName { get; set; }

        /// <summary>
        /// 当前钞值
        /// </summary>
        public virtual int CurrentMoney { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string LotId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TerminalID { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string IP { get; set; }

        /// <summary>
        /// 网卡MAC
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string MAC { get; set; }

        /// <summary>
        /// 硬盘序列号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string BID { get; set; }

        /// <summary>
        /// 结束入钞时间
        /// </summary>
        public virtual DateTime? EndTime { get; set; } 

        /// <summary>
        /// 扩展字段
        /// </summary>
        public virtual string Extend { get; set; }

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

        /// <summary>
        /// 充值状态
        /// </summary>
        public virtual int RechargeStatus { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual int RefundStatus { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public virtual int RefundMoney { get; set; }

        /// <summary>
        /// 退款时间
        /// </summary>
        public virtual DateTime RefundTime { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Operator { get; set; }
    }
}
