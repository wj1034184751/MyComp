using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 病区表
    /// </summary>
    public class AbpWardArea : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 编号
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 病区名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 建筑Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string BuildingId { get; set; }

        /// <summary>
        /// 所在楼层
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string FloorId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }

        /// <summary>
        /// 配置code
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string ConfigCode { get; set; }

        public virtual int DevQuantity { get; set; }
    }
}