using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;
namespace YuanTu.Platform.Local
{


    public class STReportRecord : CustomEntityWithOrg<string>
    {
        [StringLength(PlatformConsts.MaxLength255)]
        public string PrintHistoryId { get; set; }



        [StringLength(PlatformConsts.MaxLength100)]
        public string ReportId { get; set; }

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

        public string PrintStatusDesc { get; set; }

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
