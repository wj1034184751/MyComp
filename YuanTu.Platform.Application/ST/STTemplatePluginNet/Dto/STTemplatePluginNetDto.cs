using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTemplatePluginNet))]
    public class STTemplatePluginNetDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 模板编号
        /// </summary>  
        public string TemplateId { get; set; }
        /// <summary>
        /// 插件编号
        /// </summary>  
        public string PluginId { get; set; }
        /// <summary>
        /// 端口
        /// </summary> 
        public int Port { get; set; }
        /// <summary>
        /// 网络类型：TCP /UDP /HTTP
        /// </summary> 
        public string NetType { get; set; }
    }
}