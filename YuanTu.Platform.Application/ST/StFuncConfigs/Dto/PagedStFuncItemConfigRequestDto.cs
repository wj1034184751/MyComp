using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.StFuncConfigs
{
    public class PagedStFuncItemConfigRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
