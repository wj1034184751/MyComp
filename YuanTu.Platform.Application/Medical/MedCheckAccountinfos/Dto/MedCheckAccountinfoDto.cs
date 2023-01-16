using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Medical.MedCheckAccountinfos.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(MedCheckAccountinfo))]
    public class MedCheckAccountinfoDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 签到表主键
        /// </summary>
        public string SignId { get; set; }
        /// <summary>
        /// 对账日期
        /// </summary>
        public string CheckAccDate { get; set; }
        /// <summary>
        /// 对账类型
        /// 1.平台数据和医保对账
        ///2.his数据和医保对账
        /// </summary>
        public string CheckAccType { get; set; }
        /// <summary>
        /// 医保类型
        /// </summary>
        public string MedicareType { get; set; }
        /// <summary>
        /// 业务周期号
        /// </summary>
        public string BusinessCode { get; set; }

        /// <summary>
        /// 医保端总金额
        /// </summary>
        public decimal MedAllAmount { get; set; }

        /// <summary>
        /// 医保端统筹总金额
        /// </summary>
        public decimal MedOverallAmount { get; set; }

        /// <summary>
        /// 医保端自费总金额
        /// </summary>
        public decimal MedSelfAmount { get; set; }

        /// <summary>
        /// His端总金额
        /// </summary>
        public decimal HisAllAmount { get; set; }

        /// <summary>
        /// His端统筹总金额
        /// </summary>
        public decimal HisOverallAmount { get; set; }

        /// <summary>
        /// His端自费总金额
        /// </summary>
        public decimal HisSelfAmount { get; set; }

        /// <summary>
        /// 插件端统筹总金额
        /// </summary>
        public decimal PluginAllAmount { get; set; }

        /// <summary>
        /// 插件端统筹总金额
        /// </summary>
        public decimal PluginOverallAmount { get; set; }

        /// <summary>
        /// 插件端自费总金额
        /// </summary>
        public decimal PluginSelfAmount { get; set; }

        /// <summary>
        /// 对账结果
        /// 0：对账成功
        ///1：对账失败（通讯等原因无法对账）
        ///2：对账不平
        /// </summary>
        public string CheckAccResult { get; set; }

        /// <summary>
        /// 渠道
        /// 0：自助机
        ///1：窗口
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 对账交易类型
        /// 0：正向交易（结算）
        ///1：反向交易（冲正）
        /// </summary>
        public string CheckTransType { get; set; }

        /// <summary>
        /// 总金额差额
        /// </summary>
        public decimal DiffAllAmount { get; set; }

        /// <summary>
        /// 统筹总金额差额
        /// </summary>
        public decimal DiffOverallAmount { get; set; }

        /// <summary>
        /// 自费总金额差额
        /// </summary>
        public decimal DiffSelfAmount { get; set; }

        /// <summary>
        /// 对账错误类型
        ///0：短款
        ///1：长款
        ///2：混合（短款、长款、未知原因）
        /// </summary>
        public string CheckErrorType { get; set; }

        /// <summary>
        /// 医保总笔数
        /// </summary>
        public int MedAllCount { get; set; }

        /// <summary>
        /// His总笔数
        /// </summary>
        public int HisAllCount { get; set; }

        /// <summary>
        /// 插件总笔数
        /// </summary>
        public int PluginAllCount { get; set; }
    }

    public class MedCheckAccountinfoByMonthDto 
    {
        /// <summary>
        /// 医保端总金额
        /// </summary>
        public decimal MedAllAmt { get; set; }

        /// <summary>
        /// 医保端总笔数
        /// </summary>
        public int MedAllCount { get; set; }

        /// <summary>
        /// HIS端总金额
        /// </summary>
        public decimal HisAllAmt { get; set; }

        /// <summary>
        /// HIS端总笔数
        /// </summary>
        public int HisAllCount { get; set; }

        /// <summary>
        /// 插件端总金额
        /// </summary>
        public decimal PluginAllAmt { get; set; }

        /// <summary>
        /// 插件端总笔数
        /// </summary>
        public int PluginAllCount { get; set; }

        /// <summary>
        /// 对账成功天数
        /// </summary>
        public int SuccessDays { get; set; }

        /// <summary>
        /// 对账失败天数
        /// </summary>
        public int FailDays { get; set; }

        /// <summary>
        /// 未对账天数
        /// </summary>
        public int NoCheckDays { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        public string MedicareType { get; set; }

        /// <summary>
        /// 对账交易类型
        /// 0：正向交易（结算）
        /// 1：反向交易（冲正）
        /// </summary>
        public string CheckTransType { get; set; }
    }

    public class MedCheckDateInfoDto
    {
        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 对账结果
        /// 0：正常
        /// 1：短款
        /// 2：长款
        /// 3：混合
        /// 4：未对账
        /// </summary>
        public string CheckResult { get; set; }


    }
}
