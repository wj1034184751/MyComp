using YuanTu.Platform.Sys.AbpLogs.Dto; 

namespace YuanTu.Platform.Sys.AbpLogs
{
    public interface IAbpLogAppService : IAsynPermissionAppService<AbpLog, AbpLogDto, string, PagedAbpLogRequestDto, AbpLogDto, AbpLogDto>
    {
    }
}