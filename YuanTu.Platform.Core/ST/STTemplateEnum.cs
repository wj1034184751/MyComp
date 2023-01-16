using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    /// <summary>
    /// 终端自定义枚举模板
    /// </summary>
    public class STTemplateEnum : CustomCreationEntityWithOrg<string>
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
    }
}