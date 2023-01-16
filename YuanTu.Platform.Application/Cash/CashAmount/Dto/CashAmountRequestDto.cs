using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Cash.Dto
{
    public class CashAmountRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string TerminalID { get; set; }

        public string IP { get; set; }
    }
}
