using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STPluginDetailAppService : AsynPermissionAppService<STPluginDetail, STPluginDetailDto, string, PagedSTPluginDetailRequestDto, STPluginDetailDto, STPluginDetailDto>, ISTPluginDetailAppService
    {
        public STPluginDetailAppService(IRepository<STPluginDetail, string> repository) : base(repository)
        {
        }

        protected override IQueryable<STPluginDetail> CreateFilteredQuery(PagedSTPluginDetailRequestDto input)
        {
            input.Sorting = "Sort";
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.PluginId.Contains(input.Keyword));
        }

        public override Task<ListResultDto<STPluginDetailDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = Repository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(key), s => s.PluginId.Equals(key)).Where(s => s.OrgId == orgId).ToList();
            return Task.FromResult(new ListResultDto<STPluginDetailDto>(ObjectMapper.Map<List<STPluginDetailDto>>(list)));
        }
    }
}