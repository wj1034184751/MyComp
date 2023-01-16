using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Medical.MedTransDatas.Dto
{
    public class MedTransDataRequestDto: CustomPagedAndSortedWithOrgDto
    {
        public string Keyword { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string MedicareType { get; set; }
        public string MedicareLogno { get; set; }
        public string TransResult { get; set; }
        public string TransType { get; set; }
    }
}
