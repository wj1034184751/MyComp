using System;
using Abp.Application.Services.Dto;
using YuanTu.Platform.AdOrder;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.SetPatientBusinessOrder.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AdSetPatientBusinessOrder))]
    public class SetPatientBusinessOrderDto : EntityDto<string>
    {
        public string UserAccountId { get; set; }

        public int Status { get; set; }

        public string PatientId { get; set; }

        public string OutpatientNo { get; set; }

        public string CardNo { get; set; }

        public int CardType { get; set; }

        public string CardTypeStr
        {
            get
            {
                //证件类型: 1 身份证, 2 军人证, 3 护照, 4 学生证, 5 回乡证, 6 驾驶证, 7 台胞证, 9 其它
                var result = CardType.ToString();
                switch (CardType)
                {
                    case 1:
                        result = "身份证";
                        break;
                    case 2:
                        result = "军人证";
                        break;
                    case 3:
                        result = "护照";
                        break;
                    case 4:
                        result = "学生证";
                        break;
                    case 5:
                        result = "回乡证";
                        break;
                    case 6:
                        result = "驾驶证";
                        break;
                    case 7:
                        result = "台胞证";
                        break;
                    case 9:
                        result = "其它";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }

        public string PatientName { get; set; }

        public string IdNo { get; set; }

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

        public long? TotalFee { get; set; }

        public long? SelfFee { get; set; }
        public string DeviceNo { get; set; }

        public string DeviceIp { get; set; }

        public string Extend { get; set; }

        public bool IsDelete { get; set; }

        public DateTime GmtCreate { get; set; }

        public DateTime? GmtModify { get; set; }
        public string Phone { get; set; }
    }
}