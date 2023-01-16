using System.ComponentModel.DataAnnotations;

namespace YuanTu.Platform.Parts
{
    /// <summary>
    /// 钱箱
    /// </summary>
    public class STCashBox : PartBase<string>
    {
        /// <summary>
        /// 现金类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string CashType { get; set; }
    }
}