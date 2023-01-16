using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Sys.AbpFolders.Dto;

namespace YuanTu.Platform.Sys.AbpFolders
{
    [AbpAuthorize]
    public class AbpFolderAppService : AsynPermissionAppService<AbpFolder, AbpFolderDto, string, PagedAbpFolderRequestDto, AbpFolderDto, AbpFolderDto>, IAbpFolderAppService
    {
        public AbpFolderAppService(IRepository<AbpFolder, string> repository)
            : base(repository)
        {
            
        }

        [ActionName("GetAll")]
        public override  Task<ListResultDto<AbpFolderDto>> GetAllListAsync()
        {
            var list = Repository.GetAll().OrderBy(s=>s.Sort);
            return Task.FromResult(new ListResultDto<AbpFolderDto>(ObjectMapper.Map<List<AbpFolderDto>>(list)));
        }
    }
}