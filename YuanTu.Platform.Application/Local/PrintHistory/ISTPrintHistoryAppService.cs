using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YuanTu.Platform.Local
{
    public interface ISTPrintHistoryAppService : IAsynPermissionAppService<STPrintHistory, STPrintHistoryDto, string, PagedSTPrintHistoryDto, STPrintHistoryDto, STPrintHistoryDto>
    {
    }
}
