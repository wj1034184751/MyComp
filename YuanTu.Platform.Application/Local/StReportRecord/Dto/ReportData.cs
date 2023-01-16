using System;
using YuanTu.Platform.Common.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;

namespace YuanTu.Platform.Local
{


    public class ReportData
    {
        public int code { get; set; }
        public string msg { get; set; }
        public string success { get; set; }
        public string traceid { get; set; }
        public List<ReportRecord> data { get; set; }

    }


    [AutoMap(typeof(STReportRecord))]
    public class STReportRecordDto : ReportRecord
    {

        public string PrintHistoryId { get; set; }
        public string ReportId { get; set; }
        public string PrinterTypeId { get; set; }
        public string PrinterName { get; set; }
        public string StTerminalId { get; set; }
        public string Input { get; set; }
        public string PrintTemplateId { get; set; }
        public string PrintFile { get; set; }
        public int PageCount { get; set; }
        public string PaperSize { get; set; }
        public DateTime? PrintTime { get; set; }
        public string BusinessTypeId { get; set; }
        public string TraceId { get; set; }
        public string IdCardNo { get; set; }
        public string SsCardNo { get; set; }
        public string DeptId { get; set; }
        public string PrintFailMsg { get; set; }
        public string BusinessId { get; set; }
        public string PrintStatusDesc { get; set; }
        public string ReportDesc { get; set; }

        public STReportRecordDto(string BusinessTypeId)
        {
            switch (BusinessTypeId)
            {
                case "5300":
                    ReportDesc = "检验报告";
                    break;
                case "5301":
                    ReportDesc = "新冠报告";
                    break;
                case "5302":
                    ReportDesc = "血常规报告";
                    break;
                case "5303":
                    ReportDesc = "尿常规报告";
                    break;
                case "5400":
                    ReportDesc = "检查报告";
                    break;
                case "5401":
                    ReportDesc = "超声报告";
                    break;
                case "5402":
                    ReportDesc = "内镜报告";
                    break;
                case "5403":
                    ReportDesc = "心电报告";
                    break;
                case "5404":
                    ReportDesc = "放射报告";
                    break;
                case "5500":
                    ReportDesc = "病理报告";
                    break;
                case "5600":
                    ReportDesc = "电子报告";
                    break;
               default:
                    ReportDesc = "其他";
                    break;
            }
        }

    }


    public class ReportRecord : CustomEntityWithOrgDto<string>
    {
        public PrinterType PrintType { get; set; }
        /// <summary>
        /// 报告Id
        /// </summary>
        public string CheckNo { get; set; }

        /// <summary>
        /// 患者病历号
        /// </summary>
        public string PatientId { get; set; }
        /// <summary>
        /// 送检医生工号
        /// </summary>
        public string InspecDoctCode { get; set; }
        /// <summary>
        /// 检查指引
        /// </summary>
        public string CheckGuide { get; set; }
        /// <summary>
        /// 报告名称(检查项)
        /// </summary>
        public string ReportName { get; set; }
        /// <summary>
        /// 送检医生名称
        /// </summary>
        public string InspecDoctName { get; set; }
        /// <summary>
        /// 送检科室名称
        /// </summary>
        public string InspecDeptName { get; set; }
        /// <summary>
        /// 送检时间
        /// </summary>
        public string InspecTime { get; set; }
        /// <summary>
        /// 检查日期
        /// </summary>
        public string CheckDate { get; set; }
        /// <summary>
        /// 审核医生工号
        /// </summary>
        public string AuditDoctCode { get; set; }
        /// <summary>
        /// 审核医生姓名
        /// </summary>
        public string AuditDoctName { get; set; }
        /// <summary>
        /// 审核医生手机
        /// </summary>
        public string AuditDoctPhone { get; set; }
        /// <summary>
        /// 审核科室名称
        /// </summary>
        public string AuditDeptName { get; set; }
        /// <summary>
        /// 检查状态
        /// </summary>
        public int? CheckStatus { get; set; }

        /// <summary>
        /// 检查描述
        /// </summary>
        public string CheckDesc { get; set; }
        /// <summary>
        /// 检查结果
        /// </summary>
        public string CheckResult { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        public string AuditDate { get; set; }
        /// <summary>
        /// 病人性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 病人年龄
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNo { get; set; }
        /// <summary>
        /// 检查诊断
        /// </summary>
        public string Diagnosis { get; set; }
        /// <summary>
        /// 检查建议
        /// </summary>
        public string Suggestion { get; set; }
        /// <summary>
        /// 报告时间
        /// </summary>
        public DateTime? ReportTime { get; set; }
        /// <summary>
        /// 报告公网链接
        /// </summary>
        public string ReportUrl { get; set; }
        /// <summary>
        /// 报告内网链接
        /// </summary>
        public string ReportIntranetUrl { get; set; }
        public string CheckItem { get; set; }
        public bool IsPrinted { get; set; }
        public ExtendMap ExtendMap { get; set; }
    }


    public class ExtendMap
    {
        public int? ReportType { get; set; }

        public string Phone { get; set; }
        public int? ReportStatus { get; set; }
    }
}
