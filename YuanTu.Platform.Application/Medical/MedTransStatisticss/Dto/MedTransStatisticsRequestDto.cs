using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Medical.MedTransStatisticss.Dto
{
    public class MedTransStatisticsRequestDto : PagedResultRequestDto
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string EndDate { get; set; }
    }
}
