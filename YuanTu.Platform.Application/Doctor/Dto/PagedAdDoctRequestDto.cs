using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Doctor.Dto
{
    public class PagedAdDoctRequestDto : CustomPagedAndSortedDto
    {
        public string DeptCode { get; set; }
        public long? CorpId { get; set; }
        public string CorpCode { get; set; }
    }
}