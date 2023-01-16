using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys.Dto
{
    public class PagedAbpWardAreaRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public override string Sorting { get; set; } = "Sort";
    }
}