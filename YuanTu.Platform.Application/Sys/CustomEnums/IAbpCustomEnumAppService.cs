using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sys.CustomEnums.Dto; 
namespace YuanTu.Platform.Sys.CustomEnums
{
    public interface IAbpCustomEnumAppService : IAsynPermissionAppService<AbpCustomEnum, AbpCustomEnumDto, string, CustomPagedAndSortedDto, CreateAbpCustomEnumDto, AbpCustomEnumDto>
    { 
    }
}