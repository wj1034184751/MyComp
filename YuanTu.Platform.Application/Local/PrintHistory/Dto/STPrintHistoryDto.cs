using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Local
{
    [AutoMap(typeof(STPrintHistory))]
    public class STPrintHistoryDto : PrintHistoryBase
    {
        /// <summary>
        /// 报告类型
        /// </summary>
        public int? ReportType { get; set; }


        public string InspecDoctCode { get; set; }

        public string CheckGuide { get; set; }

        public string ReportName { get; set; }

        public string InspecDoctName { get; set; }

        public string InspecDeptName { get; set; }

        public string InspecTime { get; set; }

        public string CheckDate { get; set; }

        public string AuditDoctCode { get; set; }

        public string AuditDoctName { get; set; }

        public string AuditDoctPhone { get; set; }

        public string AuditDeptName { get; set; }
        /// <summary>
        /// 检查状态
        /// </summary>

        public int? CheckStatus { get; set; }
        /// <summary>
        /// 报告状态
        /// </summary>

        public int? ReportStatus { get; set; }

        public string CheckDesc { get; set; }

        public string CheckResult { get; set; }

        public string AuditDate { get; set; }

        public string Sex { get; set; }

        public string Age { get; set; }

        public string Phone { get; set; }


        public string IdNo { get; set; }

        public string Diagnosis { get; set; }

        public string Suggestion { get; set; }


        public string ReportUrl { get; set; }

        public string ReportIntranetUrl { get; set; }

        /// <summary>
        /// 打印次数
        /// </summary>
        public int PrintCount { get; set; }
        
        public string PrintTypeDesc { get; set; }
        public string CheckStatusDesc { get; set; }
        public string ReportStatusDesc { get; set; }


        public STPrintHistoryDto(PrinterType printType, int? checkStatus, int? reportStatus)
        {
            switch (printType)
            {
                case PrinterType.Receipt:
                    PrintTypeDesc = "凭条打印";
                    break;
                case PrinterType.Invoice:
                    PrintTypeDesc = "发票打印";
                    break;
                case PrinterType.Report:
                    PrintTypeDesc = "报告打印";
                    break;
                case PrinterType.Stickers:
                    PrintTypeDesc = "不干胶打印";
                    break;
                case PrinterType.Medical:
                    PrintTypeDesc = "病例打印";
                    break;
                case PrinterType.ColorReport:
                    PrintTypeDesc = "图片打印";
                    break;
                case PrinterType.PhotoReport:
                    PrintTypeDesc = "相片打印";
                    break;
                default:
                    break;
            }
            switch (checkStatus)
            {
                case 1:
                    this.CheckStatusDesc = "未检查";
                    break;
                case 2:
                    this.CheckStatusDesc = "已检查";
                    break;
                case 3:
                    this.CheckStatusDesc = "已登记";
                    break;
                default:
                    this.CheckStatusDesc = "";
                    break;
            }

            switch (reportStatus)
            {
                case 0:
                    this.ReportStatusDesc = "未出报告";
                    break;
                case 1:
                    this.ReportStatusDesc = "审核中";
                    break;
                case 2:
                    this.ReportStatusDesc = "检验完成";
                    break;
                case 3:
                    this.ReportStatusDesc = "已打印";
                    break;
                default:
                    this.ReportStatusDesc = "";
                    break;
            }
        }


    }
    public class PrintHistoryBase : CustomEntityWithOrgDto<string>
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
        /// 打印入参
        /// </summary>
        public string Input { get; set; }

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
        public DateTime? ReportTime { get; set; }

        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime? PrintTime { get; set; }

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


        /// <summary>
        /// 业务单号
        /// </summary>
        public string BusinessId { get; set; }

        /// <summary>
        /// 报告ID
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// 科室编号
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }
    }

}
