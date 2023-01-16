using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.AdOrder
{
    /// <summary>
    /// 患者信息表
    /// </summary>
    [Table("ad_reg_business_order")]
    public class AdRegBusinessOrder : Entity<string>
    {
        [StringLength(PlatformConsts.MaxLength64)]
        [Column("user_account_id")]
        public virtual string UserAccountId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("dept_code")]
        public virtual string DeptCode { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("dept_name")]
        public virtual string DeptName { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("doct_code")]
        public virtual string DoctCode { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("doct_name")]
        public virtual string DoctName { get; set; }


        [Column("reg_mode")]
        public virtual int RegMode { get; set; }

        [StringLength(PlatformConsts.MaxLength16)]
        [Column("reg_type")]
        public virtual string RegType { get; set; }


        [Column("status")]
        public virtual int Status { get; set; }



        [StringLength(PlatformConsts.MaxLength20)]
        [Column("corp_id")]
        public virtual string CorpId { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("corp_name")]
        public virtual string CorpName { get; set; }



        [StringLength(PlatformConsts.MaxLength32)]
        [Column("corp_code")]
        public virtual string CorpCode { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("corp_code_name")]
        public virtual string CorpCodeName { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("corp_area")]
        public virtual string CorpArea { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("corp_area_name")]
        public virtual string CorpAreaName { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("his_business_no")]
        public virtual string HisBusinessNo { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("his_reg_id")]
        public virtual string HisRegId { get; set; }


        [StringLength(PlatformConsts.MaxLength32)]
        [Column("schedule_id")]
        public virtual string ScheduleId { get; set; }


        [StringLength(PlatformConsts.MaxLength100)]
        [Column("lock_id")]
        public virtual string LockId { get; set; }


        [StringLength(PlatformConsts.MaxLength128)]
        [Column("appo_no")]
        public virtual string AppoNo { get; set; }


        [StringLength(PlatformConsts.MaxLength16)]
        [Column("med_date")]
        public virtual string MedDate { get; set; }


        [StringLength(PlatformConsts.MaxLength16)]
        [Column("med_beg_time")]
        public virtual string MedBegTime { get; set; }


        [StringLength(PlatformConsts.MaxLength16)]
        [Column("med_end_time")]
        public virtual string MedEndTime { get; set; }


        [Column("med_am_pm")]
        public virtual int? MedAmPm { get; set; }


        [StringLength(PlatformConsts.MaxLength255)]
        [Column("address")]
        public virtual string Address { get; set; }


        [StringLength(PlatformConsts.MaxLength100)]
        [Column("password")]
        public virtual string Password { get; set; }


        [Column("opt_type")]
        public virtual int OptType { get; set; }


        [Column("total_fee")]
        public virtual long? TotalFee { get; set; }

        [Column("self_fee")]
        public virtual long? SelfFee { get; set; }

        [Column("discount_fee")]
        public virtual long? DiscountFee { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("trade_mode")]
        public virtual string TradeMode { get; set; }

        [StringLength(PlatformConsts.MaxLength20)]
        [Column("trade_time")]
        public virtual string TradeTime { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("fee_channel")]
        public virtual string FeeChannel { get; set; }

        [Column("insure_account_fee")]
        public virtual long? InsureAccountFee { get; set; }

        [Column("insure_overall_fee")]
        public virtual long? InsureOverallFee { get; set; }

        [Column("insure_total_fee")]
        public virtual long? InsureTotalFee { get; set; }

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
    }
}