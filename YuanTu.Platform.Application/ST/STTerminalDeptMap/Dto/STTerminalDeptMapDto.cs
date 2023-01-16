using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTerminalDeptMap))]
    public class STTerminalDeptMapDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 终端ID
        /// </summary> 
        public string TerminalId { get; set; }

        /// <summary>
        /// 优先展示科室类型
        /// </summary>
        public byte PriorityType { get; set; }

        /// <summary>
        /// 优先展示科室集合（JSON）
        /// </summary> 
        public string PriorityTypeDept { get; set; }

        /// <summary>
        /// 限制展示科室类型
        /// </summary>
        public byte RestrictionType { get; set; }

        /// <summary>
        /// 限制展示科室类型（JSON）
        /// </summary> 
        public string RestrictionTypeDept { get; set; }
    }
}