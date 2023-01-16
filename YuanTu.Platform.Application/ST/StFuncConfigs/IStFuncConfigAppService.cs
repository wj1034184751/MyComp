using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.StFuncConfigs
{
    public interface IStFuncConfigAppService : IAsynPermissionAppService<StFuncConfig, StFuncConfigDto, string, PagedStFuncConfigRequestDto, StFuncConfigDto, StFuncConfigDto>
    {
    }
}
