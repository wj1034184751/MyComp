using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.FuncConfigs
{
    public class FuncItemConfigAppService : AsynPermissionAppService<FuncItemConfig, FuncItemConfigDto, string, PagedFuncItemConfigRequestDto, FuncItemConfigDto, FuncItemConfigDto>, IFuncItemConfigAppService
    {
        public FuncItemConfigAppService(IRepository<FuncItemConfig, string> repository) : base(repository)
        {
            
        }
    }
}