using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTerminalPart))]
    public class STTerminalPartDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 终端编号
        /// </summary>  
        public string TermianlId { get; set; }
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
        public  string JsonText { get; set; }
    }
}