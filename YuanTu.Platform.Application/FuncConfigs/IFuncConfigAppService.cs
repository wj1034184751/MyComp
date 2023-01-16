using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.FuncConfigs
{
    public interface IFuncConfigAppService : IAsynPermissionAppService<FuncConfig, FuncConfigDto, string, PagedFuncConfigRequestDto, FuncConfigDto, FuncConfigDto>
    {
    }
}
