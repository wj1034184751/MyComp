using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.SN.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STNameplate))]
    public class STNameplateDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 编号
        /// </summary> 
        public string Code { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// SN码区间
        /// </summary> 
        public string SnBlock { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 预发货时间
        /// </summary>
        public DateTime PreDeliveryDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 发货状态
        /// </summary>
        public byte DeliveryStatus { get; set; }

        /// <summary>
        /// 设备情况
        /// </summary>
        public string Situation { get; set; }

        /// <summary>
        /// 微信随机码
        /// </summary>  
        public string WeChatCode { get; set; }

        /// <summary>
        /// SN码
        /// </summary> 
        public List<STSerialNoDto> SerialNos { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }

    [Abp.AutoMapper.AutoMapFrom(typeof(STNameplate))]
    public class STNameplateExDto : EntityDto<string>
    {
        /// <summary>
        /// 编号
        /// </summary> 
        public string Code { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 预发货时间
        /// </summary>
        public DateTime PreDeliveryDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 发货状态
        /// </summary>
        public byte DeliveryStatus { get; set; }

        /// <summary>
        /// 设备情况
        /// </summary>
        public string Situation { get; set; }

        public string HospitalCode { get; set; }
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string UnionId { get; set; }

        /// <summary>
        /// SN码
        /// </summary> 
        public Dictionary<string, List<string>> SerialNos { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}