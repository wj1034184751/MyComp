using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.StDisinfects;

namespace YuanTu.Platform.ST
{
    public interface IStDisinfectAppService : IAsynPermissionAppService<StDisinfect, StDisinfectDto, string, PagedStDisinfectRequestDto, StDisinfectDto, StDisinfectDto>
    {
    }
}
