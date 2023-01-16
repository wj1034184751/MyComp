using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Payment
{
    public class PayTrade : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 支付流水号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string OutTradeNo { get; set; }
        /// <summary>
        /// 第三方流水号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string OutPayNo { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public virtual byte Business { get; set; }
        /// <summary>
        /// 跟踪号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string TraceId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public virtual int Fee { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string PatientId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string PatientName { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string CardNo { get; set; }
        /// <summary>
        /// 支付渠道
        /// </summary>
        public virtual int FeeChannel { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength20)]
        public virtual string TradeMode { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public virtual int PayType { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public virtual DateTime? PayTime { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public virtual DateTime? TradeTime { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public virtual byte Status { get; set; }
        /// <summary>
        /// 支付账户
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string PayAccount { get; set; }
        /// <summary>
        /// 操作员编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string OperId { get; set; }
        /// <summary>
        /// 调用来源
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string Source { get; set; }
        /// <summary>
        /// 银联交易数据
        /// </summary>
        public virtual string PosDetail { get; set; }
        /// <summary>
        /// 请求报文
        /// </summary>
        public virtual string RequestContent { get; set; }
        /// <summary>
        /// 返回报文
        /// </summary>
        public virtual string ResponseContent { get; set; }
        /// <summary>
        /// 设备信息
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DeviceInfo { get; set; }
        /// <summary>
        /// 医院id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string ParentCorpId { get; set; }
        /// <summary>
        /// 医院区域编码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string  HisCode { get; set; }
        /// <summary>
        /// 资金托管行
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string FundCustodian { get; set; }
        /// <summary>
        /// 设备mac
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string DeviceMac { get; set; }
        /// <summary>
        /// 设备ip
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string DeviceIp { get; set; }

    }
    
}
