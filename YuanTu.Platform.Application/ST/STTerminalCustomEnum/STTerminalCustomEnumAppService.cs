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
    public class STTerminalCustomEnumAppService : AsynPermissionAppService<STTerminalCustomEnum, STTerminalCustomEnumDto, string, CustomPagedAndSortedDto, STTerminalCustomEnumDto, STTerminalCustomEnumDto>, ISTTerminalCustomEnumAppService
    {
        public STTerminalCustomEnumAppService(IRepository<STTerminalCustomEnum, string> repository)
            : base(repository)
        {
        }
 
        [ActionName("GetPage")]
        public override Task<PagedResultDto<STTerminalCustomEnumDto>> GetAllAsync(CustomPagedAndSortedDto input)
        {
            input.MaxResultCount = int.MaxValue;
            input.Sorting = "Sort";

            return base.GetAllAsync(input);
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<STTerminalCustomEnumDto>> GetAllListAsync()
        {
            var list = await base.GetAllListAsync();
            return new ListResultDto<STTerminalCustomEnumDto>(list.Items.OrderBy(s => s.Sort).ToList());
        }

        public override Task<ListResultDto<STTerminalCustomEnumDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = this.Repository.GetAll().Where(v => v.TerminalId == key).OrderBy(v => v.Sort).ToList();
            return Task.FromResult(new ListResultDto<STTerminalCustomEnumDto>(ObjectMapper.Map<List<STTerminalCustomEnumDto>>(list)));
        }

        public override Task<STTerminalCustomEnumDto> UpdateAsync(STTerminalCustomEnumDto input)
        {
            foreach (var item in Repository.GetAll().Where(v => v.ParentId == input.Id))
            {
                item.ParentCode = input.Code;
            }

            return base.UpdateAsync(input);
        }
    }
}