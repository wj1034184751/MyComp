using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sys.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTemplateEnum))]
    public class STTemplateEnumDto : CustomCreationEntityWithOrgDto<string>
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
        /// 子集
        /// </summary>
        public object Details { get; set; }
    }
}