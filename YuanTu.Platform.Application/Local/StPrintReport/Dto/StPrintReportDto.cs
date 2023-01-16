using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Local
{
    [AutoMap(typeof(StPrintReport))]
    public class StPrintReportDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 打印机类型
        /// </summary>
        public string PrinterTypeId { get; set; }

        /// <summary>
        /// 打印总人次
        /// </summary>
        public long PersonTime { get; set; }

        /// <summary>
        /// 打印总页数
        /// </summary>
        public long TotalPages { get; set; }

        /// <summary>
        /// A4总页数
        /// </summary>
        public long TotalPagesInA4 { get; set; }

        /// <summary>
        /// A5总页数
        /// </summary>
        public long TotalPagesInA5 { get; set; }

        /// <summary>
        /// 凭条打印长度
        /// </summary>
        public long TotalPagesInReceipt { get; set; }

        /// <summary>
        /// 打印机名称
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// 终端设备
        /// </summary>
        public string StTerminalId { get; set; }

        /// <summary>
        /// 终端设备编号
        /// </summary>
        public string StTerminalCode { get; set; }

        /// <summary>
        /// 终端设备IP
        /// </summary>
        public string StTerminalIp { get; set; }

        /// <summary>
        /// 硬盘序列号
        /// </summary>
        public string StTerminalBid { get; set; }

        /// <summary>
        /// 时间分类
        /// </summary>
        public ReportTimelyType ReportTimelyType { get; set; }

        /// <summary>
        /// 业务类型 挂号/缴费/取号/预约/发票/住院一日清单/检验报告/病例报告
        /// </summary>
        public string BusinessTypeId { get; set; }

        public long TotalPagesCustom { get; set; }
       
    }
}
