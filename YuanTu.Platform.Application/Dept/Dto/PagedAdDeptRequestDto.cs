using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Dept.Dto
{
    public class PagedAdDeptRequestDto : CustomPagedAndSortedDto
    {
        public long? CorpId { get; set; }
        public string CorpCode { get; set; }
    }
}