using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.ST.Dto; 

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTerminalFolderAppService : AsynPermissionAppService<STTerminalFolder, STTerminalFolderDto, string, PagedSTTerminalFolderRequestDto, STTerminalFolderDto, STTerminalFolderDto>, ISTTerminalFolderAppService
    {
        private readonly IRepository<STTerminal, string> _repositoryTerminal;
        public STTerminalFolderAppService(IRepository<STTerminalFolder, string> repository, IRepository<STTerminal, string> repositoryTerminal)
            : base(repository)
        {
            _repositoryTerminal = repositoryTerminal;
        }

        [ActionName("GetAll")]
        public override Task<ListResultDto<STTerminalFolderDto>> GetAllListAsync()
        {
            var list = Repository.GetAll().OrderBy(s => s.Sort);
            var dto = ObjectMapper.Map<List<STTerminalFolderDto>>(list);
            dto.ForEach(s=>
            {
                var infos = _repositoryTerminal.GetAll()
                    .Where(t => t.FolderId.Equals(s.Id));
                s.Children = ObjectMapper.Map<List<STTerminalDto>>(infos); 
            });
            return Task.FromResult(new ListResultDto<STTerminalFolderDto>(dto));
        }
    }
}