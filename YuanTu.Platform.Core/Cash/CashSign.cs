using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Cash
{
    /// <summary>
    /// 钱箱签到记录
    /// </summary>
    public class CashSign : CustomEntityWithOrg<string>
    {
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
        /// 签退时间
        /// </summary>
        public virtual DateTime SignoutTime { get; set; }

        /// <summary>
        /// 判断是否已签退
        /// </summary>
        public virtual bool IsSignout { get; set; }

        /// <summary>
        /// 上报金额
        /// </summary>
        public virtual int ReportedMoney { get; set; }
        
        /// <summary>
        /// 总金额
        /// </summary>
        public virtual int TotalMoney { get; set; }

        /// <summary>
        /// 状态锁定
        /// </summary>
        public virtual bool IsLocked { get; set; }

        /// <summary>
        /// 交易次数
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TotalCount { get; set; }

        /// <summary>
        /// 未知总金额
        /// </summary>
        public virtual int UnkownTotalMoney { get; set; }

        /// <summary>
        /// 未知交易次数
        /// </summary>
        public virtual int UnkownTotalCount { get; set; }

        /// <summary>
        /// 失败总金额
        /// </summary>
        public virtual int FailTotalMoney { get; set; }

        /// <summary>
        /// 失败交易次数
        /// </summary>
        public int FailTotalCount { get; set; }

        /// <summary>
        /// 成功总金额
        /// </summary>
        public virtual int SuccessTotalMoney { get; set; }

        /// <summary>
        /// 成功交易次数
        /// </summary>
        public virtual int SuccessTotalCount { get; set; }

        /// <summary>
        /// 退款总金额
        /// </summary>
        public virtual int RefundTotalMoney { get; set; }

        /// <summary>
        /// 退款次数
        /// </summary>
        public virtual int RefundTotalCount { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Operator { get; set; }
    }
}
