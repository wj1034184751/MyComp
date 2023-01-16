using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace YuanTu.Platform.ST
{
    [AutoMapTo(typeof(STTerminalPluginNet))]
    public class STTemplatePluginNet : PluginNetBase
    {
        /// <summary>
        /// 模板编号
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TemplateId { get; set; }
    }
}