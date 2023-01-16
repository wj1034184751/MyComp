using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Local.StReportRecord.Dto
{
    public class StQueryReportRecordDto
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ReportId { get; set; }

        public int? ReportType { get; set; }

        public string PatientId { get; set; }
    }
}
