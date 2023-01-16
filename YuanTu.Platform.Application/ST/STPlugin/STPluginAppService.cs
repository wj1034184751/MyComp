using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Parts.Dto;
using YuanTu.Platform.ST.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STPluginAppService : AsynPermissionAppService<STPlugin, STPluginDto, string, PagedSTPluginRequestDto, STPluginDto, STPluginDto>, ISTPluginAppService
    {
        private readonly IRepository<AbpAttachment, string> _repositoryAttachment;
        public STPluginAppService(IRepository<STPlugin, string> repository, IRepository<AbpAttachment, string> repositoryAttachment) : base(repository)
        {
            _repositoryAttachment = repositoryAttachment;
        }

        protected override IQueryable<STPlugin> CreateFilteredQuery(PagedSTPluginRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Code.Contains(input.Keyword) || x.Name.Contains(input.Keyword) || x.PluginType.Contains(input.Keyword));
        }
        [ActionName("GetPage")]
        public override async Task<PagedResultDto<STPluginDto>> GetAllAsync(PagedSTPluginRequestDto input)
        {
            var m = await base.GetAllAsync(input);
            foreach (var s in m.Items)
                s.Attachments = ObjectMapper.Map<List<AbpAttachmentDto>>(_repositoryAttachment.GetAllList(t => t.ExtendId.Equals(s.Id)));
            return m;
        }

        public override Task<ListResultDto<STPluginDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = Repository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(key),s=>s.PluginType.Equals(key)).Where(s=>s.OrgId==orgId).ToList();
            return Task.FromResult(new ListResultDto<STPluginDto>(ObjectMapper.Map<List<STPluginDto>>(list)));
        }
    }
}