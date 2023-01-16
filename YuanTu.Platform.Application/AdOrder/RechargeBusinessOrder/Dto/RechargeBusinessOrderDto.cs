using System;
using Abp.Application.Services.Dto;
using YuanTu.Platform.AdOrder;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.RechargeBusinessOrder.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AdRechargeBusinessOrder))]
    public class RechargeBusinessOrderDto : EntityDto<string>
    {
        public string UserAccountId { get; set; }

        public int RechargeType { get; set; }
        public string RechargeTypeStr
        {
            get
            {
                var result = RechargeType.ToString();
                switch (RechargeType)
                {
                    case 1:
                        result = "门诊";
                        break;
                    case 4:
                        result = "住院";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }

        public int Status { get; set; }

        public string UserInhosRecordId { get; set; }

        public long CorpId { get; set; }

        public string CorpCode { get; set; }

        public string TradeMode { get; set; }

        public string TradeModeStr
        {
            get
            {
                //支付类型CA：现金，DB：银行卡，MIC：医保卡，OC：银医通账户，ZFB：支付宝，WX: 微信不可空，
                var result = TradeMode.ToString();
                switch (TradeMode)
                {
                    case "CA":
                        result = "现金";
                        break;
                    case "DB":
                        result = "银行卡";
                        break;
                    case "MIC":
                        result = "医保卡";
                        break;
                    case "OC":
                        result = "银医通账户";
                        break;
                    case "ZFB":
                        result = "支付宝";
                        break;
                    case "WX":
                        result = "微信";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }

        public long BalanceBeforeRecharge { get; set; }

        public long TotalFee { get; set; }

        public long SelfFee { get; set; }

        public long BalanceAfterRecharge { get; set; }

        public string HisFlowId { get; set; }
        public string DeviceNo { get; set; }

        public string DeviceIp { get; set; }

        public string Extend { get; set; }

        public bool IsDelete { get; set; }

        public DateTime GmtCreate { get; set; }

        public DateTime? GmtModify { get; set; }

        public string PatientName { get; set; }

        public string IdNo { get; set; }
        public string Phone { get; set; }

        public string PatientId { get; set; }
    }
}