using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.SN.Dto
{
    public class PagedSTSerialNoRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string TerminalTypeId { get; set; }
        public bool? Status { get; set; }
    }

    public class PagedSTSerialNoExRequestDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// sn批次code
        /// </summary>
        public string Code { get; set; }
    }
}