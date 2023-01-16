using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    /// <summary>
    /// 终端科室设置关联表
    /// </summary>
    public class STTerminalDeptMap: CustomCreationEntityWithOrg<string>
    {
        /// <summary>
        /// 终端ID
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string TerminalId { get; set; }

        /// <summary>
        /// 优先展示科室类型
        /// </summary>
        public virtual byte PriorityType { get; set; }

        /// <summary>
        /// 优先展示科室集合（JSON）
        /// </summary>
        [StringLength(PlatformConsts.MaxLength4000)]
        public virtual string PriorityTypeDept { get; set; }

        /// <summary>
        /// 限制展示科室类型
        /// </summary>
        public virtual byte RestrictionType { get; set; }

        /// <summary>
        /// 限制展示科室类型（JSON）
        /// </summary>
        [StringLength(PlatformConsts.MaxLength4000)]
        public virtual string RestrictionTypeDept { get; set; }
    }
}