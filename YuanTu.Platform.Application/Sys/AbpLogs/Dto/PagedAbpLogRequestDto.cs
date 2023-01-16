using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys.AbpLogs.Dto
{
    public class PagedAbpLogRequestDto : CustomPagedAndSortedDto
    {
        //public string Keyword { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string TraceId { get; set; }

        //public string Sorting { get; set; }
    }
}
