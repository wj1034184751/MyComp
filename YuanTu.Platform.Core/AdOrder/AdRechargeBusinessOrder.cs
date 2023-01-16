using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.AdOrder
{
    /// <summary>
    /// 患者信息表
    /// </summary>
    [Table("ad_recharge_business_order")]
    public class AdRechargeBusinessOrder : Entity<string>
    {
        [StringLength(PlatformConsts.MaxLength64)]
        [Column("user_account_id")]
        public virtual string UserAccountId { get; set; }

        [Column("recharge_type")]
        public virtual int? RechargeType { get; set; }

        [Column("status")]
        public virtual int Status { get; set; }


        [StringLength(PlatformConsts.MaxLength64)]
        [Column("user_inhos_record_id")]
        public virtual string UserInhosRecordId { get; set; }

        [Column("corp_id")]
        public virtual long? CorpId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("corp_code")]
        public virtual string CorpCode { get; set; }


        [StringLength(PlatformConsts.MaxLength32)]
        [Column("trade_mode")]
        public virtual string TradeMode { get; set; }

        [Column("balance_before_recharge")]
        public virtual long? BalanceBeforeRecharge { get; set; }

        [Column("total_fee")]
        public virtual long? TotalFee { get; set; }

        [Column("self_fee")]
        public virtual long? SelfFee { get; set; }

        [Column("balance_after_recharge")]
        public virtual long? BalanceAfterRecharge { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("his_flow_id")]
        public virtual string HisFlowId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("device_no")]
        public virtual string DeviceNo { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("device_ip")]
        public virtual string DeviceIp { get; set; }

        [StringLength(PlatformConsts.MaxLength4000)]
        [Column("extend")]
        public virtual string Extend { get; set; }

        /// <summary>
        /// 删除标记 0-正常 1-删除
        /// </summary>
        [Column("is_delete")]
        public virtual bool IsDelete { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("gmt_create")]
        public virtual DateTime GmtCreate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Column("gmt_modify")]
        public virtual DateTime? GmtModify { get; set; }
    }
}