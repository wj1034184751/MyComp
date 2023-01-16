
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Local
{
    /// <summary>
    /// 报告打印查询
    /// 作者: 系统用户
    /// 生成时间: 2022年08月04日 08:17:16
    /// </summary>
    public class STReportHistory : CustomEntityWithOrg<string>
    {


        public string ReportId { get; set; }

        public int? ReportType { get; set; }

        public string ReportName { get; set; }

        public string PatientName { get; set; }

        public string IdCardNo { get; set; }

        public bool IsPrinted { get; set; }

        public DateTime PrintTime { get; set; }

        public string PrinterName { get; set; }

        public string StTerminalId { get; set; }

        public string TraceId { get; set; }

        public string PaperSize { get; set; }

        public int PageCount { get; set; }
    }
}
