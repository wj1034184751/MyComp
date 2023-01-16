using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTemplatePlugin))]
    public class STTemplatePluginDto : CustomCreationEntityWithOrgDto<string>
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
        /// 插件名称
        /// </summary> 
        public string PluginName { get; set; }
        /// <summary>
        /// 插件代码
        /// </summary> 
        public string PluginCode { get; set; }
        /// <summary>
        /// 版本编号
        /// </summary> 
        public string VersionId { get; set; }
        /// <summary>
        /// 版本名称
        /// </summary> 
        public string Version { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 程序路径
        /// </summary> 
        public string Path { get; set; }
        /// <summary>
        /// 网络请求集合
        /// </summary>
        public IList<STTemplatePluginNetDto> NetList { get; set; }
        /// <summary>
        /// 类型
        /// </summary> 
        public string Type { get; set; }

        /// <summary>
        /// 启动方式 1-延时启动 2-定时启动
        /// </summary>
        public int StartMode { get; set; }

        /// <summary>
        /// 延迟时间(秒)
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// 固定启动时间(HH:mm:ss,例如：9:00:00)
        /// </summary> 
        public string FixedTime { get; set; }

        /// <summary>
        /// 是否守护
        /// </summary>
        public bool Protectable { get; set; }

        /// <summary>
        /// 是否模拟测试
        /// </summary>
        public bool IsMock { get; set; }
    }
}