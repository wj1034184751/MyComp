using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.Health.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(HealthConfig))]
    public class HealthConfigDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 配置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 医院编号
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary> 
        public string DeviceType { get; set; }

        /// <summary>
        /// 启用/停用
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 配置JSON文本
        /// </summary> 
        public string JsonText { get; set; }
    }

    public class HealthContentDto
    {
        /// <summary>
        /// 配置名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 是否开启
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; } 
}
}