using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace YuanTu.Platform.ST
{
    [AutoMapTo(typeof(STTerminalPlugin))]
    public class STTemplatePlugin : PluginBase
    {
        /// <summary>
        /// 模板编号
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TemplateId { get; set; }
    }
}