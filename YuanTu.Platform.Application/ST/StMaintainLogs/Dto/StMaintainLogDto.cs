using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.StMaintains;

namespace YuanTu.Platform.ST
{
    [Abp.AutoMapper.AutoMap(typeof(StMaintainLog))]
    public class StMaintainLogDto : CustomEntityDto<string>
    {
        /// <summary>
        /// 终端ID
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        public string TerminalCode { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperateTime { get; set; }

        /// <summary>
        /// 运维人员Id
        /// </summary>
        public string StMaintaintorId { get; set; }

        /// <summary>
        /// 运维人员姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 射频卡
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNo { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 就诊号
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 来源类型
        /// </summary>
        public string SourceTypeId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperateTypeId { get; set; }
    }

    public class StMaintainLogExportDto
    {
        /// <summary>
        /// 操作时间
        /// </summary>
        public string OperateTime { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        public string TerminalCode { get; set; }

        /// <summary>
        /// 运维人员姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 就诊号
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNo { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperateTypeId { get; set; }
    }
}