using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Cash.Dto
{
    public class CashTradeDetailRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string Money { get; set; }
        public string LotId { get; set; }
        public string CashTradeId { get; set; }
    }
}
