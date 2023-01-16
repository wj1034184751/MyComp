using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
namespace YuanTu.Platform.Local.StReportRecord.Dto
{
    public class PagedSTReportRecordRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public string Reportid { get; set; }
        public string PrinterName { get; set; }
        public string Patientname { get; set; }
        public string IdCardNo { get; set; }
        public string traceId { get; set; }
        public string stTerminalId { get; set; }
        public string ReportType { get; set; }
    }
}
