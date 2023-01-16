using System;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.SN.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STSerialNo))]
    public class STSerialNoDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 设备型号
        /// </summary> 
        public string TerminalTypeId { get; set; }

        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime OrderDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 设备颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 设备数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 起始编号
        /// </summary>
        public string StartNum { get; set; }

        /// <summary>
        /// 钣金厂家
        /// </summary>
        public string Factory { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; } = true;

        /// <summary>
        /// 铭牌项目编号
        /// </summary>
        public string NameplateId { get; set; }

        /// <summary>
        /// 铭牌项目编号
        /// </summary> 
        public string NameplateCode { get; set; }

        /// <summary>
        /// 铭牌项目名称
        /// </summary> 
        public string NameplateName { get; set; }

        /// <summary>
        /// SN码
        /// </summary> 
        public string SerialNo { get; set; }

        /// <summary>
        /// 下单型号
        /// </summary>
        public string OrderModel { get; set; }

        /// <summary>
        /// 发货型号
        /// </summary>
        public string DeliveryModel { get; set; }

        /// <summary>
        /// 发货状态
        /// </summary>
        public byte DeliveryStatus { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public byte TerminalModel { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }

    [Abp.AutoMapper.AutoMapFrom(typeof(STSerialNo))]
    public class STSerialNoExDto : EntityDto<string>
    {
        /// <summary>
        /// 设备型号
        /// </summary> 
        public string TerminalTypeId { get; set; }

        /// <summary>
        /// 下单日期
        /// </summary>
        public DateTime OrderDate { get; set; } = DateTime.Now;

        /// <summary>
        /// 设备颜色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 起始编号
        /// </summary>
        public string StartNum { get; set; }

        /// <summary>
        /// 钣金厂家
        /// </summary>
        public string Factory { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; } = true;

        /// <summary>
        /// 铭牌项目编号
        /// </summary> 
        public string NameplateCode { get; set; }

        /// <summary>
        /// 铭牌项目名称
        /// </summary> 
        public string NameplateName { get; set; }

        /// <summary>
        /// SN码
        /// </summary> 
        public string SerialNo { get; set; }

        /// <summary>
        /// 下单型号
        /// </summary>
        public string OrderModel { get; set; }

        /// <summary>
        /// 发货型号
        /// </summary>
        public string DeliveryModel { get; set; }

        /// <summary>
        /// 发货状态
        /// </summary>
        public byte DeliveryStatus { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}