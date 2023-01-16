using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Jc
{
    /// <summary>
    /// 药品信息入参
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(Jc_UserEnum))]
    public class Jc_UserEnumDto : ParentCustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 枚举编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 编码前缀
        /// </summary>
        public string PrefixCode { get; set; }

        /// <summary>
        /// 枚举名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 枚举值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 拼音助记码
        /// </summary>
        public string PinYin { get; set; }

        /// <summary>
        /// 五笔助记码
        /// </summary>
        public string WuBi { get; set; }

        /// <summary>
        /// 通用助记码
        /// </summary>
        public string Tyzjm { get; set; }

        /// <summary>
        /// 完整编码
        /// </summary>
        public string FullCode
        {
            get
            {
                if (string.IsNullOrEmpty(this.PrefixCode))
                {
                    return this.Code;
                }
                else
                {
                    return this.PrefixCode + "." + this.Code;
                }
            }
        }
    }
}
