using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Medical.Base
{
    public class TransDataDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 医院编号
        /// </summary>
        public string HospId { get; set; }

        /// <summary>
        /// 终端编号
        /// </summary>
        public string TerminalNo { get; set; }

        /// <summary>
        /// 自助机流水号
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 医保类型
        /// </summary>
        public string MedicareType { get; set; }
        /// <summary>
        /// 第三方流水号
        /// </summary>
        public string SendLogno { get; set; }
        /// <summary>
        /// 医保流水号
        /// </summary>
        public string MedicareLogno { get; set; }
        /// <summary>
        /// 业务周期号
        /// </summary>
        public string BusinessCode { get; set; }
        /// <summary>
        /// 医保卡号
        /// </summary>
        public string MedicareCardId { get; set; }
        /// <summary>
        /// 卡内号
        /// </summary>
        public string CardSafeNo { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Pid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime TransDate { get; set; }
        /// <summary>
        /// 操作员号
        /// </summary>
        public string OperCode { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalAmt { get; set; }
        /// <summary>
        /// 统筹金额
        /// </summary>
        public decimal PubAmt { get; set; }
        /// <summary>
        /// 自费金额
        /// </summary>
        public decimal OwnAmt { get; set; }
        /// <summary>
        /// 交易类型
        /// </summary>
        public int TransType { get; set; }
        /// <summary>
        /// 交易结果
        /// </summary>
        public int TransResult { get; set; }
        /// <summary>
        /// 备注说明
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 交易名称
        /// </summary>
        public string TransName { get; set; }

        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientId { get; set; }

        /// <summary>
        /// 数据渠道(0：自助机 1：窗口)
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 是否已上送--0：未上送 1：已上送（本地表需要）
        /// </summary>
        public string UploadFlag { get; set; }
    }
}
