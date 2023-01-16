using System.Linq;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTemplatePartAppService : AsynPermissionAppService<STTemplatePart, STTemplatePartDto, string, PagedSTTemplatePartRequestDto, STTemplatePartDto, STTemplatePartDto>, ISTTemplatePartAppService
    {
        public STTemplatePartAppService(IRepository<STTemplatePart, string> repository) : base(repository)
        {
        }

        protected override IQueryable<STTemplatePart> CreateFilteredQuery(PagedSTTemplatePartRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.PartName.Contains(input.Keyword));
        }
    }
}