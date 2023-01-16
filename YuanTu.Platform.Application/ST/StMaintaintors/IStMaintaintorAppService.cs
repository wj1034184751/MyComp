using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.StMaintains;

namespace YuanTu.Platform.ST
{
    public interface IStMaintaintorAppService : IAsynPermissionAppService<StMaintaintor, StMaintaintorDto, string, PagedStMaintaintorRequestDto, StMaintaintorDto, StMaintaintorDto>
    {
    }
}
