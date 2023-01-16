using Abp.Authorization;
using Abp.Domain.Repositories;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTerminalPluginAppService : AsynPermissionAppService<STTerminalPlugin, STTerminalPluginDto, string, PagedSTTerminalPluginRequestDto, STTerminalPluginDto, STTerminalPluginDto>, ISTTerminalPluginAppService
    {
        public STTerminalPluginAppService(IRepository<STTerminalPlugin, string> repository) : base(repository)
        {
        } 
    }
}