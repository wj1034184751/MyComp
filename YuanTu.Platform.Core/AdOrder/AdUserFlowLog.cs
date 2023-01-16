using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.AdOrder
{
    /// <summary>
    /// 用户操作日志表
    /// </summary>
    [Table("ad_user_flowlog")]
    public class AdUserFlowLog : Entity<string>
    {
        [StringLength(PlatformConsts.MaxLength255)]
        [Column("TraceId")]
        public virtual string TraceId { get; set; }
 
        [Column("BusinessType")]
        public virtual int BusinessType { get; set; }
 
        [Column("Status")]
        public virtual int Status { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("PatientId")]
        public virtual string PatientId { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("PatientName")]
        public virtual string PatientName { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("IptOptNo")]
        public virtual string IptOptNo { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("IptHospitalNo")]
        public virtual string IptHospitalNo { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("IdCardNo")]
        public virtual string IdCardNo { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("TerminalNo")]
        public virtual string TerminalNo { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("DeviceIp")]
        public virtual string DeviceIp { get; set; }

        [Column("OperateTime")]
        public virtual DateTime OperateTime { get; set; }
    }
}