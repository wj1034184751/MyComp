using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Medical
{
    public class MedTransStatistics : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 医保区域
        /// </summary>
        [StringLength(32)]
        public string AreaCode { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        [StringLength(64)]
        public string HospId { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        [StringLength(64)]
        public string TerminalNo { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        [StringLength(8)]
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
        [StringLength(20)]
        public string Transdate { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        [StringLength(200)]
        public string Memo { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [StringLength(200)]
        public string Extend { get; set; }
    }
}
