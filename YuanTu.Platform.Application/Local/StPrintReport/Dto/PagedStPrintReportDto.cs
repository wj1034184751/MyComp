using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Local
{
    public class PagedStPrintReportDto : CustomPagedAndSortedWithOrgDto
    {
        public string Key { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
        /// <summary>
        /// 自助机单独统计/自助机累加统计
        /// </summary>
        public string IsALl { get; set; }
        /// <summary>
        /// 报告类型 检查/检验/病理/电子
        /// </summary>
        public string ReportType { get; set; }
        public ReportTimelyType Timely { get; set; } = ReportTimelyType.Daily;
    }
}
