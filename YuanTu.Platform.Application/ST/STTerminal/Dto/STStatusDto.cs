namespace YuanTu.Platform.ST.Dto
{
    public class StatusBaseDto
    {
        /// <summary>
        /// 主板序列号
        /// </summary>  
        public string BID { get; set; }
    }

    /// <summary>
    /// 更新设备在线/离线状态 请求实体类
    /// </summary>
    public class STStatusDto : StatusBaseDto
    {
        /// <summary>
        /// 是否在线
        /// </summary>
        public int IsPowerOn { get; set; }
    }

    /// <summary>
    ///  是否更新
    /// </summary>
    public class STUpdateStatusDto : StatusBaseDto
    {
        /// <summary>
        /// 是否更新
        /// </summary>
        public int IsUpdated { get; set; }
    }
}