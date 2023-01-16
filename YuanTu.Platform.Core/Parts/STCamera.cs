using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.Parts
{
    /// <summary>
    /// 摄像头
    /// </summary>
    public class STCamera : PartBase<string>
    {
        /// <summary>
        /// 摄像头索引
        /// </summary>
        public virtual int Index { get; set; }

        /// <summary>
        /// 驱动名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string MonikerString { get; set; }

        /// <summary>
        /// 摄像头类型
        /// </summary>
        public virtual byte CameraType { get; set; }
    }
}