using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Sys.Dto
{
    public class PagedSTTemplateCustomEnumRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
