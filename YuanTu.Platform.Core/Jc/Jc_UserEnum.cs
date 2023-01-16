using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Jc
{
    /// <summary>
    /// 用户枚举信息表
    /// </summary>
    public class Jc_UserEnum : ParentCustomEditEntityWithOrg<string>
    {
        /// <summary>
        /// 枚举编码
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string Code { get; set; }

        /// <summary>
        /// 编码前缀
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string PrefixCode { get; set; }

        /// <summary>
        /// 枚举名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength128)]
        public string Name { get; set; }

        /// <summary>
        /// 枚举值
        /// </summary>
        [StringLength(PlatformConsts.MaxLength2048)]
        public string Value { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 拼音助记码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public string PinYin { get; set; }

        /// <summary>
        /// 五笔助记码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public string WuBi { get; set; }

        /// <summary>
        /// 通用助记码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public string Tyzjm { get; set; }
    }
}
