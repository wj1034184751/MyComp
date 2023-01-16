using System;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Cash.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(CashTrade))]
    public class CashTradeDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 钱箱状态
        /// </summary>
        public virtual string Status { get; set; }

        /// <summary>
        /// 钱箱状态
        /// </summary>
        public virtual string StatusText { get; set; }

        /// <summary>
        /// 支付金额(分)
        /// </summary>
        public virtual int TotalMoney { get; set; }

        /// <summary>
        /// 病人ID
        /// </summary>
        public virtual string PatientId { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public virtual string PatientName { get; set; }

        /// <summary>
        /// 当前钞值
        /// </summary>
        public virtual int CurrentMoney { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public virtual string LotId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public virtual string TerminalID { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public virtual string IP { get; set; }

        /// <summary>
        /// 网卡MAC
        /// </summary>
        public virtual string MAC { get; set; }

        /// <summary>
        /// 硬盘序列号
        /// </summary>
        public string BID { get; set; }

        /// <summary>
        /// 结束入钞时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 追溯流水号
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 充值流水号
        /// </summary>
        public string RechargeId { get; set; }

        /// <summary>
        /// 充值状态 
        /// </summary>
        public int RechargeStatus { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        public int RefundStatus { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public int RefundMoney { get; set; }

        /// <summary>
        /// 退款时间
        /// </summary>
        public DateTime? RefundTime { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
    }
}
