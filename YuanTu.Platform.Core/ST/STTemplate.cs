using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    /// <summary>
    /// 模板
    /// </summary>
    public class STTemplate : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 模板编码
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 模板类型
        /// </summary>
        public virtual int TemplateType { get; set; }
    }
}