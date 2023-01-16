using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Sys.CustomEnums.Dto
{
    public class PagedAbpCustomEnumRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
