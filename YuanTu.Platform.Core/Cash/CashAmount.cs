using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Cash
{
    /// <summary>
    /// 钱箱金额
    /// </summary>
    public class CashAmount : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 批次号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string LotId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TerminalID { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string IP { get; set; }

        /// <summary>
        /// 判断是否已签退
        /// </summary>
        [Required]
        public virtual bool IsSignout { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        [Required]
        public virtual int TotalMoney { get; set; }

        /// <summary>
        /// 病区
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string InpatientWard { get; set; }

        /// <summary>
        /// 自助机位置
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Position { get; set; }
    }
}
