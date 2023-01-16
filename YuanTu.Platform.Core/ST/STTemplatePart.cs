using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace YuanTu.Platform.ST
{
    /// <summary>
    /// 配件
    /// </summary>
    [AutoMapTo(typeof(STTerminalPart))]
    public class STTemplatePart : PartBase
    {
        /// <summary>
        /// 模板编号
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TemplateId { get; set; }
    }
}