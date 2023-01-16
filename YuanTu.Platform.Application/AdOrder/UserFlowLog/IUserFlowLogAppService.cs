using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.AdOrder;
using YuanTu.Platform.AdOrder.UserFlowLog.Dto;
using YuanTu.Platform.UserFlowLog.Dto;
 

namespace YuanTu.Platform.UserFlowLog
{
    public interface IUserFlowLogAppService : IAsynPermissionAppService<AdUserFlowLog, UserFlowLogDto, string, PagedUserFlowLogRequestDto, UserFlowLogDto, UserFlowLogDto>
    {
        Task<IActionResult> DownLoadFlowLog(string flowId);
    }
}