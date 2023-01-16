using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST 
{
    /// <summary>
    /// 模板字典管理
    /// </summary>
    public class STTemplateCustomEnum : ParentCustomCreationEntityWithOrg<string>
    {
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ParentCode { get; set; }

        /// <summary>
        /// 模板编号
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TemplateId { get; set; }
         
        public virtual int Sort { get; set; }

        /// <summary>
        /// 规则描述
        /// </summary>
        public virtual string Rule { get; set; }
    }
}