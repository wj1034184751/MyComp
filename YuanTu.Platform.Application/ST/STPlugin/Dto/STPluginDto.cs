using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STPlugin))]
    public class STPluginDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 编号
        /// </summary> 
        public string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// 插件类型
        /// </summary> 
        public string PluginType { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 附件
        /// </summary> 
        public ICollection<AbpAttachmentDto> Attachments { get; set; } 
    }
}