using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.FuncConfigs
{
    [Abp.AutoMapper.AutoMap(typeof(FuncItemConfig))]
    public class FuncItemConfigDto : ParentCustomEntityDto<string>
    {
    }
}
