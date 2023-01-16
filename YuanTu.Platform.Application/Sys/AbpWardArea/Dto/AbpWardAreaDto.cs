using YuanTu.Platform.Common.Dto; 

namespace YuanTu.Platform.Sys.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AbpWardArea))]
    public class AbpWardAreaDto : CustomCreationEntityWithOrgDto<string>
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
        /// 建筑Id
        /// </summary>
        public string BuildingId { get; set; }

        /// <summary>
        /// 所在楼层
        /// </summary>
        public string FloorId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 配置code
        /// </summary> 
        public string ConfigCode { get; set; }

        /// <summary>
        /// 设备数量
        /// </summary>
        public int DevQuantity { get; set; }
    }

    public class TerminalStatisticsDto
    {
        /// <summary>
        /// 诊区编号
        /// </summary>
        public string WardAreaId { get; set; }

        /// <summary>
        /// 设备数量
        /// </summary>
        public int DevQuantity { get; set; }
    }
}