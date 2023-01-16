namespace YuanTu.Platform.Parts
{
    /// <summary>
    /// 发卡机
    /// </summary>
        public class STCardDispenser : PartBase<string>
    {
        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 打印
        /// </summary>
        public bool Print { get; set; }
    }
}
