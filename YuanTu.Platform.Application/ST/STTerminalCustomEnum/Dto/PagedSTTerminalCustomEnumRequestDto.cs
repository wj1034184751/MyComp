using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Sys.Dto
{
    public class PagedSTTerminalCustomEnumRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
