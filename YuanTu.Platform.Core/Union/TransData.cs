using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Union
{
    public abstract class TransData : CustomEntityWithOrg<string>
    {

        /// <summary>				
        /// 平台流水号				
        /// </summary>				
        public string PlatformNo { get; set; }

        /// <summary>				
        /// 消费金额(分)				
        /// </summary>				
        public int Amount { get; set; }

        /// <summary>				
        /// 商户类型				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string BankType { get; set; }

        /// <summary>				
        ///商户号				
        /// </summary>		
        [StringLength(PlatformConsts.MaxLength255)]
        public string MerchantId { get; set; }

        /// <summary>				
        /// 银行终端号				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string TerminalId { get; set; }

        /// <summary>				
        /// 地址:端口				
        /// </summary>			
        [StringLength(PlatformConsts.MaxLength255)]
        public string IPAndPort { get; set; }

        /// <summary>				
        /// 银行TPDU				
        /// </summary>		
        [StringLength(PlatformConsts.MaxLength255)]
        public string TPDU { get; set; }

        /// <summary>				
        /// 调用方式				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string CallType { get; set; }

        /// <summary>				
        /// 医院编号				
        /// </summary>			
        [StringLength(PlatformConsts.MaxLength255)]
        public string HospitalId { get; set; }

        /// <summary>				
        /// 医院名称				
        /// </summary>			
        [StringLength(PlatformConsts.MaxLength255)]
        public string HpspitalName{ get; set; }

        /// <summary>				
        /// 登记号				
        /// </summary>				
        public string PatientId { get; set; }

        /// <summary>				
        /// 姓名				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string PatientName { get; set; }

        /// <summary>				
        /// 身份证号码				
        /// </summary>		
        [StringLength(PlatformConsts.MaxLength255)]
        public string IdNo { get; set; }

        /// <summary>				
        /// 操作员编号				
        /// </summary>				
        public string Source { get; set; }

        /// <summary>				
        /// 银行卡号				
        /// </summary>			
        [StringLength(PlatformConsts.MaxLength255)]
        public string CardNo { get; set; }

        /// <summary>				
        /// 交易方式				
        /// </summary>		
        [StringLength(PlatformConsts.MaxLength255)]
        public string TradeType { get; set; }

        /// <summary>				
        /// 交易渠道				
        /// </summary>	
        [StringLength(PlatformConsts.MaxLength255)]
        public string FeeChannel { get; set; }

        /// <summary>				
        /// 交易状态				
        /// </summary>				
        public int PayState { get; set; }

        /// <summary>				
        /// 支付时间				
        /// </summary>				
        public DateTime PayTime { get; set; }

        /// <summary>				
        ///支付完成时间				
        /// </summary>				
        public DateTime FinishTime { get; set; }

        /// <summary>				
        /// 银行流水号/检索参考号				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string BankPayNo { get; set; }

        /// <summary>				
        /// 授权码				
        /// </summary>			
        [StringLength(PlatformConsts.MaxLength255)]
        public string AuthorizeNo { get; set; }

        /// <summary>				
        /// 批次号				
        /// </summary>		
        [StringLength(PlatformConsts.MaxLength255)]
        public string LotId { get; set; }

        /// <summary>				
        /// 发卡行号				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string IssuerCode { get; set; }

        /// <summary>				
        /// 发卡行名称				
        /// </summary>		
        [StringLength(PlatformConsts.MaxLength255)]
        public string IssuerName { get; set; }

        /// <summary>				
        /// 卡片有效期				
        /// </summary>				
        public DateTime CardValidDate { get; set; }

        /// <summary>				
        /// 终端IP				
        /// </summary>		
        [StringLength(PlatformConsts.MaxLength255)]
        public string DeviceIp { get; set; }

        /// <summary>				
        /// 交易要素				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength4000)]
        public string Element { get; set; }

        /// <summary>				
        /// 银联原始入参报文				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string ResquestContext { get; set; }

        /// <summary>				
        /// 银联原始出参报文				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string ResponseContext { get; set; }

        /// <summary>				
        /// 扩展参数				
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string Extend { get; set; }


        /// <summary>				
        /// 唯一标识号	
        /// </summary>				
        [StringLength(PlatformConsts.MaxLength255)]
        public string TraceId { get; set; }

        /// <summary>
        /// 流水类型
        /// </summary>
        public int TransType { get; set; }


    }
}
