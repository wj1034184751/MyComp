using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Medical
{
    public class MedCheckExpData : CustomEntityWithOrg<string>
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
        /// 第三方流水号
        /// </summary>
        [StringLength(64)]
        public string SendLogno { get; set; }
        /// <summary>
        /// 医保流水号
        /// </summary>
        [StringLength(64)]
        public string MedicareLogno { get; set; }
        /// <summary>
        /// 业务周期号
        /// </summary>
        [StringLength(64)]
        public string BusinessCode { get; set; }
        /// <summary>
        /// 操作员号
        /// </summary>
        [StringLength(32)]
        public string OperCode { get; set; }
        /// <summary>
        /// 医保卡号
        /// </summary>
        [StringLength(64)]
        public string MedicareCardId { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        [StringLength(64)]
        public string Pid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [StringLength(64)]
        public string Name { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime TransDate { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalAmt { get; set; }

        /// <summary>
        /// 异常类型
        /// 0：医保端多数据
        ///1：HIS端多数据
        /// </summary>
        public int ExpType { get; set; }

        /// <summary>
        /// 备注说明
        /// </summary>
        [StringLength(512)]
        public string Memo { get; set; }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 交易名称 
        /// </summary>
        [StringLength(32)]
        public string TransName { get; set; }

        /// <summary>
        /// 数据渠道(0：自助机 1：窗口)
        /// </summary>
        [StringLength(8)]
        public string Channel { get; set; }

        /// <summary>
        /// 异常处理方式
        /// 0：医保端手动冲正
        /// 1：系统补录交易记录
        /// 2：短款-手动标记不参与对账
        /// 3：其他原因-手动标记不参与对账
        /// 4：金额差异
        /// </summary>
        [StringLength(8)]
        public string OptExpType { get; set; }

        /// <summary>
        /// 异常数据是否已经处理(0：未处理 1：已处理)
        /// </summary>
        [StringLength(8)]
        public string IsOpt { get; set; }
    }
}
