using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.FuncConfigs
{
    public interface IFuncItemConfigAppService : IAsynPermissionAppService<FuncItemConfig, FuncItemConfigDto, string, PagedFuncItemConfigRequestDto, FuncItemConfigDto, FuncItemConfigDto>
    {
    }
}
