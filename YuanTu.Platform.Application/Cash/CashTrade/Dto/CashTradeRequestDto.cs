using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Cash.Dto
{
    public class CashTradeRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string LotId { get; set; }
        public string TerminalID { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
        public int RechargeStatus { get; set; }
        public int RefundStatus { get; set; }
    }
}
