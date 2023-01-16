using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Local.StReportRecord.Rto
{
    public class StQueryReportRecordRto
    {
        public int? ReportType { get; set; }
        public string Phone { get; set; }

        public string ReportId { get; set; }

        public DateTime ReportTime { get; set; }

        public int? ReportStatus { get; set; }

        public string PatientId { get; set; }
    }
}
