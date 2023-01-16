using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using YuanTu.Platform.POS.Dto;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.POS
{
    [AbpAuthorize]
    public class PosConfigAppService : AsynPermissionAppService<PosConfig, PosConfigDto, string, PagedPosConfigRequestDto, PosConfigDto, PosConfigDto>, IPosConfigAppService
    {
        private IRepository<STTerminal, string> _repositorySTTerminal;
        public PosConfigAppService(IRepository<PosConfig, string> repository, IRepository<STTerminal, string> repositorySTTerminal) : base(repository)
        {
            _repositorySTTerminal = repositorySTTerminal;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<PosConfigDto>> GetAllAsync(PagedPosConfigRequestDto input)
        { 
            var totalCount = 0;
            var result = new List<PosConfigDto>();
            if (string.IsNullOrWhiteSpace(input.Keyword))
            {
                totalCount = await LeftJoin(input, result);
            }
            else
            {
                totalCount = await InnerJoin(input, result);
            }

            var dto = new PagedResultDto<PosConfigDto>(totalCount, ObjectMapper.Map<List<PosConfigDto>>(result));

            return dto;
        }

        private async Task<int> InnerJoin(PagedPosConfigRequestDto input, List<PosConfigDto> result)
        {
            var list = Repository.GetAll()
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.BankType), x => x.BankType == byte.Parse(input.BankType))
                .OrderByDescending(s => s.CreationTime)
                .Join(
                    _repositorySTTerminal.GetAll().WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                        s => s.Code.Contains(input.Keyword) || s.IP.Contains(input.Keyword)), x => x.TerminalIds,
                    s => s.Id,
                    (x, s) => new {x, s});
            var totalCount = await list.CountAsync();
            var pagedList = list.Skip(input.SkipCount).Take(input.MaxResultCount);
            foreach (var info in pagedList)
            {
                var m = MapToEntityDto(info.x);
                m.BindTerminal = info.s != null ? $"{info.s.Code}({info.s.IP})" : string.Empty;
                result.Add(m);
            }

            return totalCount;
        }

        private async Task<int> LeftJoin(PagedPosConfigRequestDto input, List<PosConfigDto> result)
        {
            var list = Repository.GetAll()
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId)
                .WhereIf(!string.IsNullOrWhiteSpace(input.BankType), x => x.BankType == byte.Parse(input.BankType))
                .OrderByDescending(s => s.CreationTime)
                .GroupJoin(_repositorySTTerminal.GetAll(), x => x.TerminalIds, s => s.Id, (x, s) => new {x, s})
                .SelectMany(t => t.s.DefaultIfEmpty(), (a, b) => new {a.x, b});
            var totalCount = await list.CountAsync();
            var pagedList = list.Skip(input.SkipCount).Take(input.MaxResultCount);
            foreach (var info in pagedList)
            {
                var m = MapToEntityDto(info.x);
                m.BindTerminal = info.b != null ? $"{info.b.Code}({info.b.IP})" : string.Empty;
                result.Add(m);
            }

            return totalCount;
        }
    }
}