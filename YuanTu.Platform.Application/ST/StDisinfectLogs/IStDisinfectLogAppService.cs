using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.StDisinfects;

namespace YuanTu.Platform.ST
{
    public interface IStDisinfectLogAppService : IAsynPermissionAppService<StDisinfectLog, StDisinfectLogDto, string, PagedStDisinfectLogRequestDto, StDisinfectLogDto, StDisinfectLogDto>
    {
    }
}
