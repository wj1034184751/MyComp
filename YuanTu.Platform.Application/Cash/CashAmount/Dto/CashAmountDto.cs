using System;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sys.Dto;

namespace YuanTu.Platform.Cash.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(CashAmount))]
    public class CashAmountDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotId { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string TerminalID { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 判断是否已签退
        /// </summary>
        public bool IsSignout { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public int TotalMoney { get; set; }

        /// <summary>
        /// 病区
        /// </summary>
        public string InpatientWard { get; set; }

        /// <summary>
        /// 自助机位置
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 病区ID
        /// </summary> 
        public string WardAreaId { get; set; }

        /// <summary>
        /// 病区
        /// </summary>
        public AbpWardAreaDto WardArea { get; set; }
    }
}
