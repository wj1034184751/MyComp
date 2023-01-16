using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Medical.MedCheckAccountinfos.Dto
{
    public class MedCheckAccountinfoRequestDto : CustomPagedAndSortedWithOrgDto
    {
        /// <summary>
        /// 对账日期--开始
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 对账日期--结束
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 对账结果(0：对账成功 1：对账失败（通讯等原因无法对账）2：对账不平)
        /// </summary>
        public string CheckAccResult { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        public string MedicareType { get; set; }

        /// <summary>
        /// 对账年/月
        /// </summary>
        public string YearMonth { get; set; }

        /// <summary>
        /// 对账日期
        /// </summary>
        public string Date { get; set; }
    }
}
