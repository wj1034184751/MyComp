using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.ST
{
    public class PagedStDisinfectLogRequestDto : PagedAndSortedResultRequestDto
    {
        public string TerminalId { get; set; }

        public string Status { get; set; }
        
        public string PeriodFrequency { get; set; }
        
        public string StartTime { get; set; }
        
        public string EndTime { get; set; }
    }
}
