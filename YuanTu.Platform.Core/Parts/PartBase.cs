using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Parts
{
    public abstract class PartBase<T> : CustomEntityWithOrg<T>
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string BrandId { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Model { get; set; }
        /// <summary>
        /// 通讯类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string CommunicationType { get; set; }
        /// <summary>
        /// 串口
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Port { get; set; }
        /// <summary>
        /// 支持U转串
        /// </summary>
        public virtual bool IsUsbToPort { get; set; }
        /// <summary>
        /// 波特率
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Baud { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Version { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; } 
    }
}