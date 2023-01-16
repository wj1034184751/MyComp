using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.ST
{
    public class STTerminalPlugin : PluginBase
    {
        /// <summary>
        /// 终端ID
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TermianlId { get; set; }
    }
}