using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.AdOrder
{
    /// <summary>
    /// 建档信息表
    /// </summary>
    [Table("ad_set_patient_business_order")]
    public class AdSetPatientBusinessOrder : Entity<string>
    {
        [StringLength(PlatformConsts.MaxLength64)]
        [Column("user_account_id")]
        public virtual string UserAccountId { get; set; }
               

        [Column("status")]
        public virtual int Status { get; set; }


        [StringLength(PlatformConsts.MaxLength32)]
        [Column("patient_id")]
        public virtual string PatientId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("outpatient_no")]
        public virtual string OutpatientNo { get; set; }

        [StringLength(PlatformConsts.MaxLength128)]
        [Column("card_no")]
        public virtual string CardNo { get; set; }


        [Column("card_type")]
        public virtual int CardType { get; set; }


        [StringLength(PlatformConsts.MaxLength200)]
        [Column("patient_name")]
        public virtual string PatientName { get; set; }


        [StringLength(PlatformConsts.MaxLength64)]
        [Column("id_no")]
        public virtual string IdNo { get; set; }

        [Column("corp_id")]
        public virtual long CorpId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("corp_code")]
        public virtual string CorpCode { get; set; }


        [StringLength(PlatformConsts.MaxLength32)]
        [Column("trade_mode")]
        public virtual string TradeMode { get; set; }


        [Column("total_fee")]
        public virtual long? TotalFee { get; set; }

        [Column("self_fee")]
        public virtual long? SelfFee { get; set; }

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