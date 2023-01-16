using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.UserFlowLog.Dto
{
    public class PagedUserFlowLogRequestDto : CustomPagedAndSortedDto
    {
        public long Id { get; set; }
        public int? BusinessType { get; set; }

        public int? Status { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
 
        public string CardNo { get; set; }
    
        public string TerminalNo { get; set; }
    }
}