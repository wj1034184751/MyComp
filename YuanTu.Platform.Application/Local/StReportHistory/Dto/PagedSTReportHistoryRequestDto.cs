using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Local.StReportHistory.Dto
{
    public class PagedSTReportHistoryRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? Reporttype { get; set; }
        public string Reportid { get; set; }
        public string ReportName { get; set; }
        public string Patientname { get; set; }
        public string IdNo { get; set; }
        public int? PrintStatus { get; set; }
    }
}
