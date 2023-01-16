using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.ST
{
    public class STTerminalPluginNet : PluginNetBase
    {
        /// <summary>
        /// 终端编号
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TermianlId { get; set; }
    }
}