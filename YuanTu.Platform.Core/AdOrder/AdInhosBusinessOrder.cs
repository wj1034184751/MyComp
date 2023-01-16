using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.AdOrder
{
    /// <summary>
    /// 出院结算
    /// </summary>
    [Table("ad_inhos_business_order")]
    public class AdInhosBusinessOrder : Entity<string>
    {
        [Column("status")]
        public virtual int Status { get; set; }

        [Column("corp_id")]
        public virtual long? CorpId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("corp_code")]
        public virtual string CorpCode { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("trade_mode")]
        public virtual string TradeMode { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("fee_channel")]
        public virtual string FeeChannel { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("user_inhos_record_id")]
        public virtual string UserInhosRecordId { get; set; }



        [Column("total_fee")]
        public virtual long? TotalFee { get; set; }

        [Column("self_fee")]
        public virtual long? SelfFee { get; set; }

        [Column("discount_fee")]
        public virtual long? DiscountFee { get; set; }


        [Column("acc_balance")]
        public virtual long? AccBalance { get; set; }

        [Column("extra_amount")]
        public virtual long? ExtraAmount { get; set; }

        [Column("refund_amount")]
        public virtual long? RefundAmount { get; set; }


        [Column("insure_account_fee")]
        public virtual long? InsureAccountFee { get; set; }

        [Column("insure_overall_fee")]
        public virtual long? InsureOverallFee { get; set; }

        [Column("insure_total_fee")]
        public virtual long? InsureTotalFee { get; set; }

        [StringLength(PlatformConsts.MaxLength128)]
        [Column("his_pay_no")]
        public virtual string HisPayNo { get; set; }



        [StringLength(PlatformConsts.MaxLength1024)]
        [Column("insure_info")]
        public virtual string InsureInfo { get; set; }


        [Column("mic")]
        public virtual bool? Mic { get; set; }

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

        /// <summary>
        /// 手写签名图片  base64
        /// </summary>
        [StringLength(PlatformConsts.MaxLength4000)]
        [Column("sign_img")]
        public virtual string SignImg { get; set; }
    }
}