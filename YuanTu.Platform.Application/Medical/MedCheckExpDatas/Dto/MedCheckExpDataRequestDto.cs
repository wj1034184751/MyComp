using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Medical.MedCheckExpDatas.Dto
{
    public class MedCheckExpDataRequestDto : CustomPagedAndSortedWithOrgDto
    {
        /// <summary>
        /// 业务周期号
        /// </summary>
        public string BusinessCode { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        /// 医保流水号
        /// </summary>
        public string MedicareLogno { get; set; }
    }
}
