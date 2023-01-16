using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.FuncConfigs
{
    public class FuncConfigAppService : AsynPermissionAppService<FuncConfig, FuncConfigDto, string, PagedFuncConfigRequestDto, FuncConfigDto, FuncConfigDto>, IFuncConfigAppService
    {
        public FuncConfigAppService(IRepository<FuncConfig, string> repository) : base(repository)
        {

        }
    }
}
