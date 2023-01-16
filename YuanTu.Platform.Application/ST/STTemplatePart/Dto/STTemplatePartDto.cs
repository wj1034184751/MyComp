using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTemplatePart))]
    public class STTemplatePartDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 模板编号
        /// </summary>  
        public string TemplateId { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 配件编号
        /// </summary>
        public string PartId { get; set; }
        /// <summary>
        /// 配件名称
        /// </summary>
        public string PartName { get; set; }
        /// <summary>
        /// 配件类型
        /// </summary> 
        public string PartType { get; set; }
        /// <summary>
        /// JSON文本
        /// </summary> 
        public string JsonText { get; set; }
    }
}