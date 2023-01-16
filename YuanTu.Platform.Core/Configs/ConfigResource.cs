using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace YuanTu.Platform.Configs
{
    /// <summary>
    /// 配置资源表
    /// </summary>
    [Table("config_resource")]
    public class ConfigResource : Entity<string>
    {
        [StringLength(PlatformConsts.MaxLength1024)]
        [Column("TerminalTypeId")]
        public virtual string TerminalTypeId { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("ResourceCode")]
        public virtual string ResourceCode { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("TypeCode")]
        public virtual string TypeCode { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("TypeName")]
        public virtual string TypeName { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("HashCode")]
        public virtual string HashCode { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        [Column("ResourceUrl")]
        public virtual string ResourceUrl { get; set; }

        [Column("Status")]
        public virtual int Status { get; set; }

        [Column("CteateTime")]
        public virtual DateTime CteateTime { get; set; }

        [Column("ModifyTime")]
        public virtual DateTime ModifyTime { get; set; }

        [Column("IsDeleted")]
        public virtual bool IsDeleted { get; set; }

    }
}