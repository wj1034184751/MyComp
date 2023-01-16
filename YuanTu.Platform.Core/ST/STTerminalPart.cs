using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.ST
{
    public class STTerminalPart : PartBase
    {
        /// <summary>
        /// 终端编号
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TermianlId { get; set; }

        /// <summary>
        /// 状态
        /// </summary> 
        public virtual int Status { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        [StringLength(PlatformConsts.MaxLength1024)]
        public virtual string Message { get; set; }
    }
}