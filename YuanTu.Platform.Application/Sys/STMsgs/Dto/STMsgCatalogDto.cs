using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 消息文案目录
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(STMsgCatalog))]
    public class STMsgCatalogDto : ParentCustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// 层级码
        /// </summary>
        public string LevelCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
