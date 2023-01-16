using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Sys.AbpColumns.Dto;

namespace YuanTu.Platform.Sys.AbpColumns
{
    public interface IAbpColumnAppService : IAsynPermissionAppService<AbpColumn, AbpColumnDto, string, PagedAbpColumnRequestDto, AbpColumnDto, AbpColumnDto>
    { 
    }
}