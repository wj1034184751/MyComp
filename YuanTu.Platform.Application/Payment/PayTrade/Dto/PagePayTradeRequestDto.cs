using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Payment.Dto
{
    public class PagePayTradeRequestDto : CustomPagedAndSortedWithOrgDto
    {
        //public string TraceId { get; set; }

        public string OutTradeNo { get; set; }

        //public string OutPayNo { get; set; } 

        //public  byte Business { get; set; }

        //public int Fee { get; set; }

        //public string PatientId { get; set; }

        //public string PatientName { get; set; }

        //public string CardNo { get; set; }

        public int? FeeChannel { get; set; }

        public string TradeMode { get; set; }

        //public int PayType { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        //public string Status { get; set; }

        //public string HisCode { get; set; }

        //public string DeviceIp { get; set; }
    }
}
