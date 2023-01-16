using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Health.Dto
{
    public class PagedHealthConfigRequestDto : CustomPagedAndSortedDto
    {
        public bool? IsActive { get; set; }
    }
}