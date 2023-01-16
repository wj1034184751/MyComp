using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STPluginDetail))]
    public class STPluginDetailDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 插件编号
        /// </summary> 
        public string PluginId { get; set; }

        /// <summary>
        /// 版本
        /// </summary> 
        public string Version { get; set; } 

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}