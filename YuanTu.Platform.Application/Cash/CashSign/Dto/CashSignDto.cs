using System;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Cash.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(CashSign))]
    public class CashSignDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string TerminalID { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 网卡MAC
        /// </summary>
        public string MAC { get; set; }

        /// <summary>
        /// 硬盘序列号
        /// </summary>
        public string BID { get; set; }

        /// <summary>
        /// 签退时间
        /// </summary>
        public DateTime SignoutTime { get; set; }

        /// <summary>
        /// 判断是否已签退
        /// </summary>
        public bool IsSignout { get; set; }

        /// <summary>
        /// 上报金额
        /// </summary>
        public int ReportedMoney { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public int TotalMoney { get; set; }

        /// <summary>
        /// 状态锁定
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// 交易次数
        /// </summary>
        public string TotalCount { get; set; }

        /// <summary>
        /// 未知总金额
        /// </summary>
        public int UnkownTotalMoney { get; set; }

        /// <summary>
        /// 未知交易次数
        /// </summary>
        public int UnkownTotalCount { get; set; }

        /// <summary>
        /// 失败总金额
        /// </summary>
        public int FailTotalMoney { get; set; }

        /// <summary>
        /// 失败交易次数
        /// </summary>
        public int FailTotalCount { get; set; }

        /// <summary>
        /// 成功总金额
        /// </summary>
        public int SuccessTotalMoney { get; set; }

        /// <summary>
        /// 成功交易次数
        /// </summary>
        public int SuccessTotalCount { get; set; }

        /// <summary>
        /// 退款总金额
        /// </summary>
        public int RefundTotalMoney { get; set; }

        /// <summary>
        /// 退款次数
        /// </summary>
        public int RefundTotalCount { get; set; }

        /// <summary>
        /// 操作员
        /// </summary>
        public string Operator { get; set; }
    }
}
