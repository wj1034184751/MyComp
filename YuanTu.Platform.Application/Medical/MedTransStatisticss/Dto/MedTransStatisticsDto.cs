using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Medical.MedTransStatisticss.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(MedTransStatistics))]
    public class MedTransStatisticsDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 医保区域
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public string HospId { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        public string TerminalNo { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        public string MedicareType { get; set; }

        /// <summary>
        /// 成功交易笔数
        /// </summary>
        public int SuccessCount { get; set; }

        /// <summary>
        /// 失败交易笔数
        /// </summary>
        public int FailCount { get; set; }

        /// <summary>
        /// 成功交易总金额
        /// </summary>
        public decimal SuccessAmt { get; set; }

        /// <summary>
        /// 成功交易总金额
        /// </summary>
        public decimal FailAmt { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        public string Transdate { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 终端名称
        /// </summary>
        public string TerminalName { get; set; }
    }
}
