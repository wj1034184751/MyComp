using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.FuncConfigs
{
    public class PagedFuncItemConfigRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
