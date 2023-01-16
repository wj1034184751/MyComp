using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.AdOrder
{
    /// <summary>
    /// his日志详情表
    /// </summary>
    [Table("ad_user_flowdetaillog")]
    public class AdUserFlowDetailLog : Entity<string>
    {
        
        [Column("FlowId")]
        public virtual string FlowId { get; set; }

        [Column("TraceId")]
        public virtual string TraceId { get; set; }
 
        [Column("SourceType")]
        public virtual int SourceType { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("ServiceName")]
        public virtual string ServiceName { get; set; }

        [Column("Tick")]
        public virtual decimal Tick { get; set; }

        [Column("InputData")]
        public virtual string InputData { get; set; }

        [Column("OutputData")]
        public virtual string OutputData { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("ExtResult")]
        public virtual string ExtResult { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("PatientId")]
        public virtual string PatientId { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("PatientName")]
        public virtual string PatientName { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("IdCardNo")]
        public virtual string IdCardNo { get; set; }

        [Column("LogLevel")]
        public virtual int LogLevel { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("LogStep")]
        public virtual string LogStep { get; set; }

        [Column("Msg")]
        public virtual string Msg { get; set; }

        [Column("CreateTime")]
        public virtual DateTime CreateTime { get; set; }
    }
}