using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Medical.Base;

namespace YuanTu.Platform.Medical.MedTradeDatas.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(MedTradeData))]
    public class MedTradeDataDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 预结算追溯ID
        /// </summary>
        public string PrePayTraceId { get; set; }
        /// <summary>
        /// 结算追溯ID
        /// </summary>
        public string PayTraceId { get; set; }
        /// <summary>
        /// 退费追溯ID
        /// </summary>
        public string RefundTraceId { get; set; }
        /// <summary>
        /// 冲正追溯ID
        /// </summary>
        public string CorrectTraceId { get; set; }
        /// <summary>
        /// 人员编号（医保端）
        /// </summary>
        public string PersonNo { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string PersonId { get; set; }
        /// <summary>
        /// 病人id
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 就诊ID
        /// </summary>
        public string MdtrtId { get; set; }
        /// <summary>
        /// 住院/门诊号
        /// </summary>
        public string IptOptNo { get; set; }
        /// <summary>
        /// 发送方报文ID
        /// </summary>
        public string SendMsgId { get; set; }
        /// <summary>
        /// 结算ID
        /// </summary>
        public string SettleId { get; set; }
        /// <summary>
        /// 收费批次号
        /// </summary>
        public string ChrgBchNo { get; set; }
        /// <summary>
        /// 险种类型
        /// </summary>
        public string InsuType { get; set; }
        /// <summary>
        /// 人员类别
        /// </summary>
        public string PersonType { get; set; }
        /// <summary>
        /// 结算时间
        /// </summary>
        public DateTime SettleTime { get; set; }
        /// <summary>
        /// 就诊凭证类型
        /// </summary>
        public string MdtrtCertType { get; set; }
        /// <summary>
        /// 医疗类别
        /// </summary>
        public string MedType { get; set; }
        /// <summary>
        /// 医疗费总额
        /// </summary>
        public decimal MedFeeSumamt { get; set; }
        /// <summary>
        /// 个人现金支出
        /// </summary>
        public decimal PsnCashPay { get; set; }
        /// <summary>
        /// 个人账户支出
        /// </summary>
        public decimal PsnAcctPay { get; set; }
        /// <summary>
        /// 基金支付总额
        /// </summary>
        public decimal FundPaySumamt { get; set; }
        /// <summary>
        /// 交易类型 0：缴费  1：缴费撤销（退费） 2：冲正
        /// </summary>
        public string TradeType { get; set; }
        /// <summary>
        /// 交易状态 0：成功 1：失败  2：未知
        /// </summary>
        public string TradeStatus { get; set; }
        /// <summary>
        /// 挂号登记原始入参
        /// </summary>
        public string InData2201 { get; set; }
        /// <summary>
        /// 挂号登记原始出参
        /// </summary>
        public string OutData2201 { get; set; }
        /// <summary>
        /// 挂号撤销原始入参
        /// </summary>
        public string InData2202 { get; set; }
        /// <summary>
        /// 挂号撤销原始出参
        /// </summary>
        public string OutData2202 { get; set; }

        /// <summary>
        /// 就诊上传原始入参
        /// </summary>
        public string InData2203 { get; set; }
        /// <summary>
        /// 就诊上传原始出参
        /// </summary>
        public string OutData2203 { get; set; }
        /// <summary>
        /// 费用明细上传透传入参
        /// </summary>
        public string InData2204 { get; set; }
        /// <summary>
        /// 费用明细上传原始出参
        /// </summary>
        public string OutData2204 { get; set; }
        /// <summary>
        /// 费用明细撤销透传入参
        /// </summary>
        public string InData2205 { get; set; }
        /// <summary>
        /// 费用明细撤销原始出参
        /// </summary>
        public string OutData2205 { get; set; }
        /// <summary>
        /// 预结算原始入参
        /// </summary>
        public string InData2206 { get; set; }
        /// <summary>
        /// 预结算原始出参
        /// </summary>
        public string OutData2206 { get; set; }
        /// <summary>
        /// 结算原始入参
        /// </summary>
        public string InData2207 { get; set; }
        /// <summary>
        /// 结算原始出参
        /// </summary>
        public string OutData2207 { get; set; }
        /// <summary>
        /// 结算撤销原始入参
        /// </summary>
        public string InData2208 { get; set; }
        /// <summary>
        /// 结算撤销原始出参
        /// </summary>
        public string OutData2208 { get; set; }

        /// <summary>
        /// 冲正原始入参
        /// </summary>
        public string InData2601 { get; set; }
        /// <summary>
        /// 冲正原始出参
        /// </summary>
        public string OutData2601 { get; set; }
        /// <summary>
        /// 入院办理原始入参
        /// </summary>
        public string InData2401 { get; set; }
        /// <summary>
        /// 入院办理原始出参
        /// </summary>
        public string OutData2401 { get; set; }
        /// <summary>
        /// 出院办理原始入参
        /// </summary>
        public string InData2402 { get; set; }
        /// <summary>
        /// 出院办理原始出参
        /// </summary>
        public string OutData2402 { get; set; }
        /// <summary>
        /// 入院撤销原始入参
        /// </summary>
        public string InData2404 { get; set; }
        /// <summary>
        /// 入院撤销原始出参
        /// </summary>
        public string OutData2404 { get; set; }
        /// <summary>
        /// 出院撤销原始入参
        /// </summary>
        public string InData2405 { get; set; }
        /// <summary>
        /// 出院撤销原始出参
        /// </summary>
        public string OutData2405 { get; set; }
        /// <summary>
        /// 住院费用明细上传原始入参
        /// </summary>
        public string InData2301 { get; set; }
        /// <summary>
        /// 住院费用明细上传原始出参
        /// </summary>
        public string OutData2301 { get; set; }
        /// <summary>
        /// 住院费用明细撤销原始入参
        /// </summary>
        public string InData2302 { get; set; }
        /// <summary>
        /// 住院费用明细撤销原始出参
        /// </summary>
        public string OutData2302 { get; set; }
        /// <summary>
        /// 住院预结算原始入参
        /// </summary>
        public string InData2303 { get; set; }
        /// <summary>
        /// 住院预结算原始出参
        /// </summary>
        public string OutData2303 { get; set; }
        /// <summary>
        /// 住院结算原始入参
        /// </summary>
        public string InData2304 { get; set; }
        /// <summary>
        /// 住院结算原始出参
        /// </summary>
        public string OutData2304 { get; set; }
        /// <summary>
        /// 住院结算撤销原始入参
        /// </summary>
        public string InData2305 { get; set; }
        /// <summary>
        /// 住院结算撤销原始出参
        /// </summary>
        public string OutData2305 { get; set; }
    }
}
