using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.StMaintains;

namespace YuanTu.Platform.ST
{
    public interface IStMaintainLogAppService : IAsynPermissionAppService<StMaintainLog, StMaintainLogDto, string, PagedStMaintainLogRequestDto, StMaintainLogDto, StMaintainLogDto>
    {
    }
}
