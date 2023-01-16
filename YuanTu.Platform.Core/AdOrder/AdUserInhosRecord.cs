using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.AdOrder
{
    /// <summary>
    /// 住院用户表
    /// </summary>
    [Table("ad_user_inhos_record")]
    public class AdUserInhosRecord : Entity<string>
    {
        [StringLength(PlatformConsts.MaxLength64)]
        [Column("user_account_id")]
        public virtual string UserAccountId { get; set; }

        [StringLength(PlatformConsts.MaxLength100)]
        [Column("patient_id")]
        public virtual string PatientId { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("patient_inhos_id")]
        public virtual string PatientInhosId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("his_visit_id")]
        public virtual string HisVisitId { get; set; }


        [StringLength(PlatformConsts.MaxLength200)]
        [Column("patient_name")]
        public virtual string PatientName { get; set; }

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





        [StringLength(PlatformConsts.MaxLength100)]
        [Column("status")]
        public virtual string Status { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("patient_type")]
        public virtual string PatientType { get; set; }



        [StringLength(PlatformConsts.MaxLength200)]
        [Column("dept_code")]
        public virtual string DeptCode { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("dept_name")]
        public virtual string DeptName { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("out_dept_code")]
        public virtual string OutDeptCode { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("out_dept_name")]
        public virtual string OutDeptName { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("in_date")]
        public virtual string InDate { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("out_date")]
        public virtual string OutDate { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("area")]
        public virtual string Area { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("bed_no")]
        public virtual string BedNo { get; set; }


        [Column("total_fee")]
        public virtual long? TotalFee { get; set; }

        [StringLength(PlatformConsts.MaxLength200)]
        [Column("wristband_pay_code")]
        public virtual string WristbandPayCode { get; set; }


        [StringLength(PlatformConsts.MaxLength64)]
        [Column("corp_id")]
        public virtual long CorpId { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("corp_code")]
        public virtual string CorpCode { get; set; }

        [StringLength(PlatformConsts.MaxLength32)]
        [Column("device_no")]
        public virtual string DeviceNo { get; set; }

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