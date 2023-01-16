using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.POS.Dto
{
    public class PagedPosTradeRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string PatientId { get; set; }

        public string CardNo { get; set; }

        public string PlatformNo { get; set; }

        public string PatientName { get; set; }

        public string BankType { get; set; }

        public string Pid { get; set; }

        public string CardReaderName { get; set; }

        public string MKeyboardName { get; set; } 

        public string TerminalId { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}