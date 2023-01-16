using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTemplate))]
    public class STTemplateDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 模板编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 模板类型
        /// </summary>
        public int TemplateType { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 配件列表
        /// </summary>
        public IList<STTemplatePartDto> Parts { get; set; }

        /// <summary>
        /// 插件件列表
        /// </summary>
        public IList<STTemplatePluginDto> Plugins { get; set; }
    }
}