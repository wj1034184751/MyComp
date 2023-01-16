using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.Doctor
{
    /// <summary>
    /// 医生表
    /// </summary>
    [Table("ad_doct")]
    public class AdDoct : Entity<long>
    {
        ///// <summary>
        ///// 编号
        ///// </summary>
        //[Column("id")]
        //public new virtual long Id { get; set; }

        /// <summary>
        /// 医生编号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        [Column("doct_code")]
        public virtual string DoctCode { get; set; }

        /// <summary>
        /// 医生名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength200)]
        [Column("doct_name")]
        public virtual string DoctName { get; set; }

        /// <summary>
        /// 科室编号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        [Column("dept_code")]
        public virtual string DeptCode { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength200)]
        [Column("dept_name")]
        public virtual string DeptName { get; set; }

        /// <summary>
        /// 医院ID
        /// </summary>
        [Column("corp_id")]
        public virtual long CorpId { get; set; }

        /// <summary>
        /// 院区代码 可空 可空，包含多个分院的情况需传入
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength32)]
        [Column("corp_code")]
        public virtual string CorpCode { get; set; }

        /// <summary>
        /// 医生职称
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength100)]
        [Column("doct_profe")]
        public virtual string DoctProfe { get; set; }

        /// <summary>
        /// 医生简介
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength5000)]
        [Column("doct_intro")]
        public virtual string DoctIntro { get; set; }

        /// <summary>
        /// 医生特长
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength5000)]
        [Column("doct_spec")]
        public virtual string DoctSpec { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength200)]
        [Column("doct_picture_url")]
        public virtual string DoctPictureUrl { get; set; }

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