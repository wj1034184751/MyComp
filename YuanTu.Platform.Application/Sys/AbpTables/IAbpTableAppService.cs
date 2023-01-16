using YuanTu.Platform.Sys.AbpTables.Dto; 

namespace YuanTu.Platform.Sys.AbpTables
{
    public interface IAbpTableAppService : IAsynPermissionAppService<AbpTable, AbpTableDto, string, PagedAbpTableRequestDto, AbpTableDto, AbpTableDto>
    {
    }
}