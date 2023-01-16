using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.POS.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(PosTrade))]
    public class PosTradeDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 业务平台支付流水号
        /// </summary>
        [Required]
        public string PlatformNo { get; set; }

        /// <summary>
        /// 业务平台支付流水号
        /// </summary> 
        public string OrgPlatformNo { get; set; }

        /// <summary>
        /// 支付状态
        /// </summary>
        [Required]
        public int PayState { get; set; }

        /// <summary>
        /// 交易方式
        /// </summary> 
        public int TradeType { get; set; }

        /// <summary>
        /// 检索参考号
        /// </summary> 
        public string BankPayNo { get; set; }

        /// <summary>
        /// 支付金额(分)
        /// </summary>
        [Required]
        public int Amount { get; set; }

        /// <summary>
        /// 用户名
        /// </summary> 
        public string UserName { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary> 
        public string CardNo { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary> 
        public DateTime? PayTime { get; set; }

        private int m_code = 0;

        /// <summary>
        /// 返回码
        /// </summary>
        public int Code
        {
            get
            {
                return m_code;
            }
            set
            {
                m_code = value;

                IsSuccess = m_code == 0;
            }
        }

        /// <summary>
        /// 消息
        /// </summary> 
        public string Msg { get; set; }

        /// <summary>
        /// 原始报文MAC
        /// </summary> 
        public string MAC { get; set; }

        public string CPUTlv { get; set; }

        public string Track2 { get; set; }

        public string Track3 { get; set; }

        public string Extend { get; set; }

        public string CardSNum { get; set; }

        /// <summary>
        /// 卡片有效期
        /// </summary> 
        public string CardValidDate { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary> 
        public string PayMethod { get; set; }

        /// <summary>
        /// 交易要素
        /// </summary> 
        public string Element { get; set; }

        /// <summary>
        /// 发卡行号
        /// </summary> 
        public string IssuerCode { get; set; }

        /// <summary>
        /// 发卡行名称
        /// </summary> 
        public string IssuerName { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>

        public string LotId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>

        public string TerminalID { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>

        public string MerchantID { get; set; }

        /// <summary>
        /// 授权码
        /// </summary>

        public string AuthorizeNo { get; set; }

        /// <summary>
        /// 显示密码
        /// </summary>

        public string Psd { get; set; }

        /// <summary>
        /// 支付完成时间
        /// </summary>

        public DateTime? FinishTime { get; set; }

        /// <summary>
        /// 扩展字段2
        /// </summary>

        public string Extend2 { get; set; }

        /// <summary>
        /// 扩展字段3
        /// </summary>

        public string Extend3 { get; set; }

        /// <summary>
        /// 扩展字段4
        /// </summary>

        public string Extend4 { get; set; }

        /// <summary>
        /// 扩展字段5
        /// </summary>

        public string Extend5 { get; set; }

        public bool IsSuccess { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>

        public string HospitalId { get; set; }

        /// <summary>
        /// 登记号
        /// </summary>

        public string PatientId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>

        public string PatientName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>

        public string IdNo { get; set; }

        /// <summary>
        /// 操作员编号
        /// </summary>

        public string Source { get; set; }

        /// <summary>
        /// 交易渠道
        /// </summary>

        public string FeeChannel { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>

        public string DeviceIp { get; set; }

        /// <summary>
        /// 终端电脑MAC
        /// </summary>

        public string DeviceMAC { get; set; }

        /// <summary>
        /// 上传支付次数
        /// </summary>
        [Required]
        public int Num { get; set; }

        /// <summary>
        /// 医院编码
        /// </summary>

        public string HisCode { get; set; }

        /// <summary>
        /// PIN密码
        /// </summary> 
        public string PIN { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary> 
        public int? OptType { get; set; }

        /// <summary>
        /// 银行类型
        /// </summary> 
        public int? BankType { get; set; }

        /// <summary>
        /// 凭证号
        /// </summary> 
        public string TransSeq { get; set; }

        /// <summary>
        /// 就诊卡号
        /// </summary> 
        public string PatientCardNo { get; set; }

        /// <summary>
        /// 终端号
        /// </summary> 
        public string TerminalNo { get; set; }

        /// <summary>
        /// 发票号
        /// </summary> 
        public string InvoiceNo { get; set; }
    }
}