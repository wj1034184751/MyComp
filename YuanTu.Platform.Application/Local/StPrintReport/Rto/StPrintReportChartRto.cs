using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Local
{

    public class StPrintReportChartRto
    {
        /// <summary>
        /// 每日趋势图
        /// </summary>
        public List<StPrintReportDto> DailyView { get; set; }

        /// <summary>
        /// 每星期趋势图
        /// </summary>
        public List<StPrintReportDto> WeeklyView { get; set; }

        /// <summary>
        /// 每月趋势图
        /// </summary>
        public List<StPrintReportDto> MonthlyView { get; set; }

        /// <summary>
        /// 每年趋势图
        /// </summary>
        public List<StPrintReportDto> YearlyView { get; set; }

        /// <summary>
        /// 当天排名
        /// </summary>
        public List<StPrintReportDto> TodayRank { get; set; }

        /// <summary>
        /// 每周排名
        /// </summary>
        public List<StPrintReportDto> WeeklyRank { get; set; }

        /// <summary>
        /// 每月排名
        /// </summary>
        public List<StPrintReportDto> MonthlyRank { get; set; }

        /// <summary>
        /// 每年排名
        /// </summary>
        public List<StPrintReportDto> YearlyRank { get; set; }

        /// <summary>
        /// 汇总概要
        /// </summary>
        public StPrintReportSummary Summary { get; set; }
    }

    public class StPrintReportSummary
    {
        public long Total { get; set; }

        public long TotalInA4 { get; set; }

        public long TotalInA5 { get; set; }

        public long Average { get; set; }

        public long TotalInReceipt { get; set; }

        public long AverageInReceipt { get; set; }
    }
}
