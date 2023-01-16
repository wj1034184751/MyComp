using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.Parts
{
    /// <summary>
    /// 打印机
    /// </summary>
    public class STPrinter : PartBase<string>
    {
        /// <summary>
        /// 双纸盒
        /// </summary>
        public virtual bool IsDoubleTray { get; set; }
        /// <summary>
        /// 打印机类型
        /// </summary>
        public virtual string IsPrinterType { get; set; }
        /// <summary>
        /// 纸张大小
        /// </summary>
        public virtual string IsPrintPaperSize { get; set; }
        /// <summary>
        /// 打印机名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PrinterName { get; set; }
        /// <summary>
        /// 是否彩色
        /// </summary>
        public virtual bool IsColor { get; set; }
        /// <summary>
        /// 打印机IP
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string PrinterIP { get; set; }
    }
}