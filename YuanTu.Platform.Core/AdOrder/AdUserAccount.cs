using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.AdOrder
{
    /// <summary>
    /// 患者信息表
    /// </summary>
    [Table("ad_user_account")]
    public class AdUserAccount : Entity<string>
    {
        [StringLength(PlatformConsts.MaxLength200)]
        [Column("patient_name")]
        public virtual string PatientName { get; set; }

        [StringLength(PlatformConsts.MaxLength100)]
        [Column("patient_id")]
        public virtual string PatientId { get; set; }

        [StringLength(PlatformConsts.MaxLength100)]
        [Column("patient_his_id")]
        public virtual string PatientHisId { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("platform_user_id")]
        public virtual string PlatformUserId { get; set; }

        [StringLength(PlatformConsts.MaxLength16)]
        [Column("sex")]
        public virtual string Sex { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("phone")]
        public virtual string Phone { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("birth_day")]
        public virtual string BirthDay { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("address")]
        public virtual string Address { get; set; }


        [Column("id_type")]
        public virtual int? IdType { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("id_no")]
        public virtual string IdNo { get; set; }

        [StringLength(PlatformConsts.MaxLength512)]
        [Column("card_no")]
        public virtual string CardNo { get; set; }


        [Column("card_type")]
        public virtual int? CardType { get; set; }

        [StringLength(PlatformConsts.MaxLength512)]
        [Column("bar_code")]
        public virtual string BarCode { get; set; }

        [StringLength(PlatformConsts.MaxLength1024)]
        [Column("extend")]
        public virtual string Extend { get; set; }

        [StringLength(PlatformConsts.MaxLength64)]
        [Column("corp_id")]
        public virtual long CorpId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("corp_code")]
        public virtual string CorpCode { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("device_no")]
        public virtual string DeviceNo { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("device_ip")]
        public virtual string DeviceIp { get; set; }


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