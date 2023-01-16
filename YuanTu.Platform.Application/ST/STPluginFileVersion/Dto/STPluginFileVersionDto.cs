using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    /// <summary>
    /// 附件管理
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(STPluginFileVersion))]
    public sealed class STPluginFileVersionDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 文件夹ID
        /// </summary> 
        public string FolderId { get; set; }

        /// <summary>
        /// 版本号
        /// </summary> 
        public string Version { get; set; }

        /// <summary>
        /// 插件代码（字典中插件类型代码）
        /// </summary> 
        public string PluginCode { get; set; }

        /// <summary>
        /// 插件名称
        /// </summary> 
        public string PluginName { get; set; }

        /// <summary>
        /// 文件结构JSON内容
        /// </summary>
        public string JsonText { get; set; }

        /// <summary>
        /// 程序路径
        /// </summary> 
        public string Path { get; set; }

        /// <summary>
        /// exe传入参数
        /// </summary> 
        public string Args { get; set; }

        /// <summary>
        /// 类型
        /// </summary> 
        public string PluginType { get; set; }

        /// <summary>
        /// 文件绝对路径
        /// </summary> 
        public string AbsolutePath { get; set; }

        /// <summary>
        /// 要应用该版本的终端集合
        /// </summary>
        public string[] TerminalIds { get; set; }

        /// <summary>
        /// 插件端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 要应用该版本的插件模板集合
        /// </summary>
        public string[] TemplateIds { get; set; }
    }
}
