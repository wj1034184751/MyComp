using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Cash.Dto
{
    public class CashSignRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string LotId { get; set; }
        public string TerminalID { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
