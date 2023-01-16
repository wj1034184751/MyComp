using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.StDisinfects;

namespace YuanTu.Platform.ST
{
    public class StDisinfectAppService : AsynPermissionAppService<StDisinfect, StDisinfectDto, string, PagedStDisinfectRequestDto, StDisinfectDto, StDisinfectDto>, IStDisinfectAppService
    {
        private readonly IRepository<StDisinfect, string> _repositoryDisinfect;
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;
        public StDisinfectAppService(IRepository<StDisinfect, string> repository, IRepository<STTerminal, string> repositorySTTerminal) : base(repository)
        {
            _repositoryDisinfect = repository;
            _repositorySTTerminal = repositorySTTerminal;
        }

        protected override IQueryable<StDisinfect> CreateFilteredQuery(PagedStDisinfectRequestDto input)
        {
            var res = _repositoryDisinfect.GetAll()
                .WhereIf(!input.Id.IsNullOrWhiteSpace(), x => x.Id.Contains(input.Id));
            return res;
        }

        [AbpAllowAnonymous]
        [ActionName("GetPage")]
        public override async Task<PagedResultDto<StDisinfectDto>> GetAllAsync(PagedStDisinfectRequestDto input)
        {
            if (!string.IsNullOrEmpty(input.TerminalId))
            {
                var terminalList = await  _repositorySTTerminal.GetAllListAsync(s => s.Code == input.TerminalId);
                if (terminalList.Count == 0)
                    return null;
                else
                    input.Id = terminalList[0].DisinfectId;
            }

            var list = await base.GetAllAsync(input);

            await GetTerminalList(list.Items);
            return list;
        }

        public override Task<StDisinfectDto> UpdateAsync(StDisinfectDto input)
        {
            input.TerminalId = "";
            return base.UpdateAsync(input);
        }

        // 根据终端编号获取终端列表数据
        private async Task GetTerminalList(IEnumerable<StDisinfectDto> infos)
        {
            var disinfectIds = infos.Where(s => !string.IsNullOrWhiteSpace(s.Id)).Select(s => s.Id);

            foreach (var info in infos)
            {
                var terminalList = await _repositorySTTerminal.GetAllListAsync(s => s.DisinfectId == info.Id);

                for (int i = 0; i < terminalList.Count; i++)
                {
                    if (i == terminalList.Count - 1)
                    {
                        info.TerminalId += terminalList[i].Code;
                    }
                    else
                    {
                        info.TerminalId += terminalList[i].Code + ",";
                    }
                }
            }
        }

    }
}