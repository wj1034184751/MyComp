using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.ST;
using YuanTu.Platform.Sys.Dto;

namespace YuanTu.Platform.Sys
{
    [AbpAuthorize]
    public class AbpWardAreaAppService : AsynPermissionAppService<AbpWardArea, AbpWardAreaDto, string, PagedAbpWardAreaRequestDto, AbpWardAreaDto, AbpWardAreaDto>, IAbpWardAreaAppService
    {
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;

        public AbpWardAreaAppService(IRepository<AbpWardArea, string> repository, IRepository<STTerminal, string> repositorySTTerminal) : base(repository)
        {
            _repositorySTTerminal = repositorySTTerminal;
        }

        protected override IQueryable<AbpWardArea> CreateFilteredQuery(PagedAbpWardAreaRequestDto input)
        {
            var list =  Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Code.Contains(input.Keyword) || x.Name.Contains(input.Keyword))
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);

            //存在诊区数据
            if (list.Count() > 0)
            {
                //查询诊区对应的终端数
                List<TerminalStatisticsDto> tempTerminalList = _repositorySTTerminal.GetAll().WhereIf(input.OrgId.HasValue, s => s.OrgId == input.OrgId).ToList().GroupBy(t => new { t.WardAreaId }).Select(e => new TerminalStatisticsDto { WardAreaId = e.Key.WardAreaId, DevQuantity = e.Count() }).ToList();

                foreach (AbpWardArea abpWardArea in list)
                {
                    TerminalStatisticsDto terminalStatisticsDto = tempTerminalList.FirstOrDefault(p => p.WardAreaId == abpWardArea.Id);

                    if (terminalStatisticsDto != null)
                    {
                        abpWardArea.DevQuantity = terminalStatisticsDto.DevQuantity;
                    }
                    else
                    {
                        abpWardArea.DevQuantity = 0;
                    }
                }
            }

            return list;
        }

        [ActionName("GetAll")]
        public override Task<ListResultDto<AbpWardAreaDto>> GetAllListAsync()
        {
            var list = Repository.GetAll().OrderBy(s => s.Sort);
            return Task.FromResult(new ListResultDto<AbpWardAreaDto>(ObjectMapper.Map<List<AbpWardAreaDto>>(list)));
        }

        [AbpAllowAnonymous]
        public Task<ListResultDto<AbpWardAreaDto>> GetAllByOrgIdAsync(long orgId)
        {
            List<AbpWardAreaDto> list = new List<AbpWardAreaDto>();
            var templist = Repository.GetAll().WhereIf(orgId != 0, s => s.OrgId == orgId).OrderBy(s => s.Sort).ToList();

            //存在诊区数据
            if (templist.Count() > 0)
            {
                //查询诊区对应的终端数
                List<TerminalStatisticsDto> tempTerminalList = _repositorySTTerminal.GetAll().WhereIf(orgId != 0, s => s.OrgId == orgId).ToList().GroupBy(t => new { t.WardAreaId }).Select(e => new TerminalStatisticsDto {WardAreaId = e.Key.WardAreaId, DevQuantity= e.Count() }).ToList();

                list = ObjectMapper.Map<List<AbpWardAreaDto>>(templist);

                foreach (AbpWardAreaDto abpWardAreaDto in list)
                {
                    TerminalStatisticsDto terminalStatisticsDto = tempTerminalList.FirstOrDefault(p => p.WardAreaId == abpWardAreaDto.Id);

                    if (terminalStatisticsDto != null)
                    {
                        abpWardAreaDto.DevQuantity = terminalStatisticsDto.DevQuantity;
                    }
                    else
                    {
                        abpWardAreaDto.DevQuantity = 0;
                    }
                }
            }
            return Task.FromResult(new ListResultDto<AbpWardAreaDto>(list));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public override async Task DeleteByIds(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");

            var arr = ids.Split(',');
            if (arr.Length == 0) return;

            await Repository.DeleteAsync(s => arr.Contains(s.Id));
        }
    }
}