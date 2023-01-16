using System;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Payment.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(PayTrade))]
    public class PayTradeDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 支付流水号
        /// </summary> 
        public string OutTradeNo { get; set; }
        /// <summary>
        /// 第三方流水号
        /// </summary> 
        public string OutPayNo { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public byte Business { get; set; }
        /// <summary>
        /// 跟踪号
        /// </summary> 
        public string TraceId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public int Fee { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary> 
        public string PatientId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary> 
        public string PatientName { get; set; }
        /// <summary>
        /// 卡号
        /// </summary> 
        public string CardNo { get; set; }
        /// <summary>
        /// 支付渠道
        /// </summary>
        public int FeeChannel { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary> 
        public string TradeMode { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public int? PayType { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? PayTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? TradeTime { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// 支付账户
        /// </summary> 
        public string PayAccount { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary> 
        public string OperId { get; set; }
        /// <summary>
        /// 调用来源
        /// </summary> 
        public string Source { get; set; }
        /// <summary>
        /// 银联交易数据
        /// </summary>
        public string PosDetail { get; set; }
        /// <summary>
        /// 请求报文
        /// </summary>
        public string RequestContent { get; set; }
        /// <summary>
        /// 返回报文
        /// </summary>
        public string ResponseContent { get; set; } 
        /// <summary>
        /// 设备信息
        /// </summary>
        public string DeviceInfo { get; set; }
        /// <summary>
        /// 医院id
        /// </summary> 
        public string ParentCorpId { get; set; }
        /// <summary>
        /// 医院区域编码
        /// </summary> 
        public string HisCode { get; set; }
        /// <summary>
        /// 资金托管行
        /// </summary> 
        public string FundCustodian { get; set; }
        /// <summary>
        /// 设备mac
        /// </summary> 
        public string DeviceMac { get; set; }
        /// <summary>
        /// 设备ip
        /// </summary> 
        public string DeviceIp { get; set; }
    }
}
