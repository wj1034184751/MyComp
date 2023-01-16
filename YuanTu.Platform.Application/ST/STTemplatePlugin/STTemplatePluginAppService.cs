using Abp.Authorization;
using Abp.Domain.Repositories;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTemplatePluginAppService : AsynPermissionAppService<STTemplatePlugin, STTemplatePluginDto, string, PagedSTTemplatePluginRequestDto, STTemplatePluginDto, STTemplatePluginDto>, ISTTemplatePluginAppService
    {
        public STTemplatePluginAppService(IRepository<STTemplatePlugin, string> repository) : base(repository)
        {
        } 
    }
}