using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Local
{
    [AutoMap(typeof(STPrintHistory))]
    public class STPrintHistoryAbbrDto : CustomEntityWithOrgDto<string>
    {

        /// <summary>
        /// 打印机类型
        /// </summary>
        public string PrinterTypeId { get; set; }

        /// <summary>
        /// 打印机名称
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// 终端设备
        /// </summary>
        public string StTerminalId { get; set; }

        /// <summary>
        /// 打印模板Id
        /// </summary>
        public string PrintTemplateId { get; set; }

        /// <summary>
        /// 打印文件
        /// </summary>
        public string PrintFile { get; set; }

        /// <summary>
        /// 纸张大小
        /// </summary>
        public string PaperSize { get; set; }

        /// <summary>
        /// 页数/mm
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 报告时间
        /// </summary>
        public DateTime ReportTime { get; set; }

        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime PrintTime { get; set; }

        /// <summary>
        /// 业务类型
        /// </summary>
        public string BusinessTypeId { get; set; }

        /// <summary>
        /// 追溯流水号
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 就诊号码
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdCardNo { get; set; }

        /// <summary>
        /// 社保卡号
        /// </summary>
        public string SsCardNo { get; set; }

        /// <summary>
        /// 已打印
        /// </summary>
        public bool IsPrinted { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string PrintFailMsg { get; set; }
    }
}
