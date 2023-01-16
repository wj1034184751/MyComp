using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.POS.Dto
{
    public class PagedPosConfigRequestDto : CustomPagedAndSortedWithOrgDto
    { 
        public string BankType { get; set; }
    }
}