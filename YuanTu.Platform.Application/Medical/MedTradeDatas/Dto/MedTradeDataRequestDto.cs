using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Medical.MedTradeDatas.Dto
{
    public class MedTradeDataRequestDto: CustomPagedAndSortedWithOrgDto
    {
        public string PersonNo { get; set; }  //个人编号
        public string SendMsgId { get; set; }  //发送消息ID
        public string MdtrtId { get; set; }  //就诊ID

        public string MedFeeSumamt { get; set; } //总金额
        public string PsnCashPay { get; set; } //个人现金支付
        public string PsnAcctPay { get; set; } //个人账户支付
        public string FundPaySumamt { get; set; } //报销总金额
    }
}
