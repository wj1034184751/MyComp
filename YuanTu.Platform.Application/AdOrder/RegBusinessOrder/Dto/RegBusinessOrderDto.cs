using System;
using Abp.Application.Services.Dto;
using YuanTu.Platform.AdOrder;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.RegBusinessOrder.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AdRegBusinessOrder))]
    public class RegBusinessOrderDto : EntityDto<string>
    {
        public string UserAccountId { get; set; }


        public string DeptCode { get; set; }


        public string DeptName { get; set; }


        public string DoctCode { get; set; }


        public string DoctName { get; set; }


        public int RegMode { get; set; }


        public string RegType { get; set; }

        public string RegTypeStr { get {
                var result = RegType;
                switch (RegType)
                {
                    case "1":
                        result = "普通";
                        break;
                    case "2":
                        result = "专家";
                        break;
                    case "3":
                        result = "名医";
                        break;
                    default:
                        break;
                }
                return result;
            } }


        public int Status { get; set; }


        public string CorpId { get; set; }

        public string CorpName { get; set; }

        public string CorpCode { get; set; }

        public string CorpCodeName { get; set; }

        public string CorpArea { get; set; }

        public string CorpAreaName { get; set; }

        public string HisBusinessNo { get; set; }

        public string HisRegId { get; set; }

        public string ScheduleId { get; set; }

        public string LockId { get; set; }

        public string AppoNo { get; set; }

        public string MedDate { get; set; }

        public string MedBegTime { get; set; }

        public string MedEndTime { get; set; }

        public int? MedAmPm { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public int OptType { get; set; }

        public string OptTypeStr
        {
            get
            {
                var result = OptType.ToString();
                switch (OptType)
                {
                    case 3:
                        result = "挂号";
                        break;
                    case 6:
                        result = "预约";
                        break;
                    case 7:
                        result = "取号";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }

        public long? TotalFee { get; set; }

        public long? SelfFee { get; set; }

        public long? DiscountFee { get; set; }

        public string TradeMode { get; set; }

        public string TradeTime { get; set; }

        public string FeeChannel { get; set; }

        public long? InsureAccountFee { get; set; }

        public long? InsureOverallFee { get; set; }

        public long? InsureTotalFee { get; set; }

        public string InsureInfo { get; set; }

        public bool? Mic { get; set; }

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