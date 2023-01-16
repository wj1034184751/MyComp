using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.Parts
{
    /// <summary>
    /// 读卡器
    /// </summary>
    public class STCardReader : PartBase<string>
    {  
        /// <summary>
        /// 吸入式
        /// </summary>
        public virtual bool Inhale { get; set; }
        /// <summary>
        /// 桥接
        /// </summary>
        public virtual bool IsBridge { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string CardType { get; set; }
    }
}