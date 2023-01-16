using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.ST; 
using YuanTu.Platform.Sys.Dto;

namespace YuanTu.Platform.Sys
{
    [AbpAuthorize]
    public class STTemplateCustomEnumAppService : AsynPermissionAppService<STTemplateCustomEnum, STTemplateCustomEnumDto, string, CustomPagedAndSortedDto, STTemplateCustomEnumDto, STTemplateCustomEnumDto>, ISTTemplateCustomEnumAppService
    {
        public STTemplateCustomEnumAppService(IRepository<STTemplateCustomEnum, string> repository)
            : base(repository)
        {
        }
 
        [ActionName("GetPage")]
        public override Task<PagedResultDto<STTemplateCustomEnumDto>> GetAllAsync(CustomPagedAndSortedDto input)
        {
            input.MaxResultCount = int.MaxValue;
            input.Sorting = "Sort";

            return base.GetAllAsync(input);
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<STTemplateCustomEnumDto>> GetAllListAsync()
        {
            var list = await base.GetAllListAsync();
            return new ListResultDto<STTemplateCustomEnumDto>(list.Items.OrderBy(s => s.Sort).ToList());
        }

        public override Task<ListResultDto<STTemplateCustomEnumDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = this.Repository.GetAll().Where(v => v.TemplateId == key).OrderBy(v => v.Sort).ToList();
            return Task.FromResult(new ListResultDto<STTemplateCustomEnumDto>(ObjectMapper.Map<List<STTemplateCustomEnumDto>>(list)));
        }

        public override Task<STTemplateCustomEnumDto> UpdateAsync(STTemplateCustomEnumDto input)
        {
            foreach (var item in Repository.GetAll().Where(v => v.ParentId == input.Id))
            {
                item.ParentCode = input.Code;
            }

            return base.UpdateAsync(input);
        }
    }
}