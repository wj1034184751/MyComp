using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.Dept
{
    /// <summary>
    /// 科室表
    /// </summary>
    [Table("ad_dept")]
    public class AdDept : Entity<long>
    {
        ///// <summary>
        ///// 编号
        ///// </summary>
        //[Column("id")]
        //public new virtual long Id { get; set; }

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
        /// 科室简介
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength5000)]
        [Column("dept_intro")]
        public virtual string DeptIntro { get; set; }

        /// <summary>
        /// 科室电话
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength50)]
        [Column("phone")]
        public virtual string Phone { get; set; }

        /// <summary>
        /// 科室地址
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength200)]
        [Column("address")]
        public virtual string Address { get; set; }

        /// <summary>
        /// 科室类别
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength200)]
        [Column("dept_type")]
        public virtual string DeptType { get; set; }

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