using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Jc.Advertising.Dto
{
    public class PagedAdvertisingRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public string CatalogCode { get; set; }

        public string TerminalCode { get; set; }
    }
}
