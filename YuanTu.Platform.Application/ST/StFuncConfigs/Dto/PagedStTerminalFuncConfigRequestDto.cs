using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.StFuncConfigs
{
    public class PagedStTerminalFuncConfigRequestDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }

        public bool IsUnique { get; set; }
    }
}
