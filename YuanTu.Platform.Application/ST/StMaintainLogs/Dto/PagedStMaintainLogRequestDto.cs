using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.ST
{
    public class PagedStMaintainLogRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public string Name { get; set; }
        public string OperateTypeId { get; set; }
    }
}