using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.StFuncConfigs
{
    public class PagedStTerminalFuncItemConfigRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
