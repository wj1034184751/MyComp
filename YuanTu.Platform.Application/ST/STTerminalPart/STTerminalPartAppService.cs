using Abp.Authorization;
using Abp.Domain.Repositories;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTerminalPartAppService : AsynPermissionAppService<STTerminalPart, STTerminalPartDto, string, PagedSTTerminalPartRequestDto, STTerminalPartDto, STTerminalPartDto>, ISTTerminalPartAppService
    {
        public STTerminalPartAppService(IRepository<STTerminalPart, string> repository) : base(repository)
        {
        } 
    }
}