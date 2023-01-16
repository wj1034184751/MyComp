using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.POS
{
    public class PosTrade : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 业务平台支付流水号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PlatformNo { get; set; }

        /// <summary>
        /// 业务平台支付流水号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string OrgPlatformNo { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        [Required] 
        public virtual int PayState { get; set; } 

        /// <summary>
        /// 交易方式
        /// </summary> 
        public virtual int TradeType { get; set; }

        /// <summary>
        /// 检索参考号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string BankPayNo { get; set; }

        /// <summary>
        /// 支付金额(分)
        /// </summary>
        [Required] 
        public virtual int Amount { get; set; } 

        /// <summary>
        /// 用户名
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string UserName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string CardNo { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary> 
        public DateTime? PayTime { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        public virtual int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Msg { get; set; }

        /// <summary>
        /// 原始报文MAC
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string MAC { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string CPUTlv { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Track2 { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Track3 { get; set; }
        
        public virtual string Extend { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string CardSNum { get; set; }

        /// <summary>
        /// 卡片有效期
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string CardValidDate { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PayMethod { get; set; }

        /// <summary>
        /// 交易要素
        /// </summary>
        [StringLength(PlatformConsts.MaxLength2048)]
        public virtual string Element { get; set; }

        /// <summary>
        /// 发卡行号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string IssuerCode { get; set; }

        /// <summary>
        /// 发卡行名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string IssuerName { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string LotId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TerminalID { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string MerchantID { get; set; }

        /// <summary>
        /// 授权码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string AuthorizeNo { get; set; }

        /// <summary>
        /// 显示密码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Psd { get; set; }

        /// <summary>
        /// 支付完成时间
        /// </summary>

        public DateTime? FinishTime { get; set; }

        /// <summary>
        /// 扩展字段2
        /// </summary>
        public virtual string Extend2 { get; set; }

        /// <summary>
        /// 扩展字段3
        /// </summary>
        public virtual string Extend3 { get; set; }

        /// <summary>
        /// 扩展字段4
        /// </summary>
        public virtual string Extend4 { get; set; }

        /// <summary>
        /// 扩展字段5
        /// </summary>
        public virtual string Extend5 { get; set; }

        public bool IsSuccess { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string HospitalId { get; set; }

        /// <summary>
        /// 登记号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string PatientId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string PatientName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string IdNo { get; set; }

        /// <summary>
        /// 操作员编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Source { get; set; }

        /// <summary>
        /// 交易渠道
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string FeeChannel { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DeviceIp { get; set; }

        /// <summary>
        /// 终端电脑MAC
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DeviceMAC { get; set; }

        /// <summary>
        /// 上传支付次数
        /// </summary>
        [Required] 
        public virtual int Num { get; set; } 

        /// <summary>
        /// 医院编码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string HisCode { get; set; }
         
        /// <summary>
        /// PIN密码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PIN { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary> 
        public virtual int? OptType { get; set; }

        /// <summary>
        /// 银行类型
        /// </summary> 
        public virtual int? BankType { get; set; }

        /// <summary>
        /// 凭证号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string TransSeq { get; set; }

        /// <summary>
        /// 就诊卡号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string PatientCardNo { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string TerminalNo { get; set; }

        /// <summary>
        /// 发票号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string InvoiceNo { get; set; }
    }
}