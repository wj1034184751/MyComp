using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
using Abp.AutoMapper;

namespace YuanTu.Platform.Local
{
    [AutoMap(typeof(STPrintHistory))]
    public class STPrintHistoryCountDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 业务类型
        /// </summary>
        public string BusinessTypeId { get; set; }
 
        /// <summary>
        /// 报告ID
        /// </summary>
        public string ReportId { get; set; }

        /// <summary>
        /// 是否打印
        /// </summary>
        public string IsPrinted { get; set; }
        
        /// <summary>
        /// 业务Id
        /// </summary>
        public string BusinessId { get; set; }
    }
}
