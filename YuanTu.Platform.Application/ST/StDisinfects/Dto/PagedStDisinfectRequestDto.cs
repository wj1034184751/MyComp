using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.ST
{
    public class PagedStDisinfectRequestDto : PagedAndSortedResultRequestDto
    {
        public string TerminalId { get; set; }

        public string Id { get; set; }
    }
}
