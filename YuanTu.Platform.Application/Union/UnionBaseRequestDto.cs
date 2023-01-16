using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Union
{
    public class UnionBaseRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string PatientId { get; set; }

        public string cardNo { get; set; }

        public string PlatformNo { get; set; }

        public string PatientName { get; set; }

        public string BankType { get; set; }

        public string Pid { get; set; }

        public string CardReaderName { get; set; }

        public string MKeyboardName { get; set; }

        public int MinAmount { get; set; }

        public int MaxAmount { get; set; }

        public string TerminalId { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }


    }
}
