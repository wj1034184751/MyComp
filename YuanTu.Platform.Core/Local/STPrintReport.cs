using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Local
{
    public class StPrintReport : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 打印机类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string PrinterTypeId { get; set; }

        /// <summary>
        /// 打印人次
        /// </summary>
        public long PersonTime { get; set; }

        /// <summary>
        /// 打印总页数
        /// </summary>
        public long TotalPages { get; set; }
        /// <summary>
        /// 自定义打印总页数(同仁相片为PagesSize为Custom)
        /// </summary>
        public long TotalPagesCustom { get; set; }
        /// <summary>
        /// A4打印总页数
        /// </summary>
        public long TotalPagesInA4 { get; set; }

        /// <summary>
        /// A5打印总页数
        /// </summary>
        public long TotalPagesInA5 { get; set; }

        /// <summary>
        /// A5打印总页数
        /// </summary>
        public long TotalPagesInReceipt { get; set; }

        /// <summary>
        /// 打印机名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public string PrinterName { get; set; }

        /// <summary>
        /// 终端设备
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string StTerminalId { get; set; }

        /// <summary>
        /// 时间分类
        /// </summary>
        public ReportTimelyType ReportTimelyType { get; set; }

        /// <summary>
        /// 业务类型 挂号/缴费/取号/预约/发票/住院一日清单/检验报告/病例报告
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string BusinessTypeId { get; set; }
        /// <summary>
        /// 科室编号
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }
    }

    public enum ReportTimelyType
    {
        Daily, Weekly, Monthly, Yearly, All
    }
}
