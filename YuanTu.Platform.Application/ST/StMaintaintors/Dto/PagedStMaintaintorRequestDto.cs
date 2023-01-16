using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.ST
{
    public class PagedStMaintaintorRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
