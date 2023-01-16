using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Local
{
    public class STPrintHistory : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 打印机类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string PrinterTypeId { get; set; }

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
        /// 打印入参
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// 打印模板Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string PrintTemplateId { get; set; }

        /// <summary>
        /// 打印文件
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string PrintFile { get; set; }

        /// <summary>
        /// 页数/mm
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 纸张大小
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string PaperSize { get; set; }

        /// <summary>
        /// 报告时间
        /// </summary>
        public DateTime? ReportTime { get; set; }

        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime? PrintTime { get; set; }

        /// <summary>
        /// 业务类型(挂号/缴费)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string BusinessTypeId { get; set; }

        /// <summary>
        /// 追溯流水号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public string TraceId { get; set; }

        /// <summary>
        /// 就诊号码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public string PatientId { get; set; }

        /// <summary>
        /// 病人姓名
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public string PatientName { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string IdCardNo { get; set; }

        /// <summary>
        /// 社保卡号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string SsCardNo { get; set; }

        /// <summary>
        /// 已打印
        /// </summary>
        public bool IsPrinted { get; set; }

        /// <summary>
        /// 科室Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public string DeptId { get; set; }

        /// <summary>
        /// 打印失败原因
        /// </summary>
        [StringLength(PlatformConsts.MaxLength2048)]
        public string PrintFailMsg { get; set; }

        /// <summary>
        /// 业务单号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public string BusinessId { get; set; }

        /// <summary>
        /// 报告ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength100)]
        public string ReportId { get; set; }


        /// <summary>
        /// 打印类型
        /// </summary>
        public PrinterType PrintType { get; set; }

        /// <summary>
        /// 报告类型
        /// </summary>
        public int? ReportType { get; set; }

        /// <summary>
        /// 送检医生工号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string InspecDoctCode { get; set; }
        /// <summary>
        /// 检查指引
        /// </summary>
        [StringLength(PlatformConsts.MaxLength100)]
        public string CheckGuide { get; set; }
        /// <summary>
        /// 报告名称(检查项)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string ReportName { get; set; }
        /// <summary>
        /// 送检医生名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string InspecDoctName { get; set; }
        /// <summary>
        /// 送检科室名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string InspecDeptName { get; set; }
        /// <summary>
        /// 送检时间
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string InspecTime { get; set; }
        /// <summary>
        /// 检查日期
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string CheckDate { get; set; }
        /// <summary>
        /// 审核医生工号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string AuditDoctCode { get; set; }
        /// <summary>
        /// 审核医生姓名
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string AuditDoctName { get; set; }
        /// <summary>
        /// 审核医生手机
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string AuditDoctPhone { get; set; }
        /// <summary>
        /// 审核科室名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string AuditDeptName { get; set; }
        /// <summary>
        /// 检查状态
        /// </summary>

        public int? CheckStatus { get; set; }
        /// <summary>
        /// 报告状态
        /// </summary>

        public int? ReportStatus { get; set; }
        /// <summary>
        /// 检查描述
        /// </summary>
        [StringLength(PlatformConsts.MaxLength100)]
        public string CheckDesc { get; set; }
        /// <summary>
        /// 检查结果
        /// </summary>
        [StringLength(PlatformConsts.MaxLength100)]
        public string CheckResult { get; set; }
        /// <summary>
        /// 审核日期
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string AuditDate { get; set; }
        /// <summary>
        /// 病人性别
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string Sex { get; set; }
        /// <summary>
        /// 病人年龄
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string Age { get; set; }
        /// <summary>
        /// 患者手机号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string Phone { get; set; }

        /// <summary>
        /// 身份证号IdCardNo
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string IdNo { get; set; }
        /// <summary>
        /// 检查诊断
        /// </summary>
        [StringLength(PlatformConsts.MaxLength2048)]
        public string Diagnosis { get; set; }
        /// <summary>
        /// 检查建议
        /// </summary>
        [StringLength(PlatformConsts.MaxLength100)]
        public string Suggestion { get; set; }

        /// <summary>
        /// 报告公网链接
        /// </summary>
        [StringLength(PlatformConsts.MaxLength100)]
        public string ReportUrl { get; set; }
        /// <summary>
        /// 报告内网链接 PrintFile
        /// </summary>
        [StringLength(PlatformConsts.MaxLength100)]
        public string ReportIntranetUrl { get; set; }

        /// <summary>
        /// 打印次数
        /// </summary>
        public int PrintCount { get; set; }
        /// <summary>
        /// 0(打印完成/下次可查询打印)1(打印中/下次不可查询打印)
        /// </summary>
        public int PrintStatus { get; set; }

        /// <summary>
        /// 科室编号
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string DeptName { get; set; }
    }

    public enum PrinterType
    {
        Receipt = 0,
        Invoice = 1,
        Report = 2,
        Stickers = 3,
        Medical = 4,
        ColorReport = 5,
        PhotoReport=6,
    }
}
