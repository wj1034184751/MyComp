using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Cash.Dto;
using System.Collections.Generic;
using YuanTu.Platform.Sys;
using YuanTu.Platform.ST;
using YuanTu.Platform.Sys.Dto;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.Cash
{
    public class CashAmountAppService : AsynPermissionAppService<CashAmount, CashAmountDto, string, CashAmountRequestDto, CashAmountDto, CashAmountDto>, ICashAmountAppService
    {
        private readonly IRepository<CashAmount, string> _repositoryCashAmount;
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;
        private readonly IRepository<AbpWardArea, string> _repositoryAbpWardArea;

        public CashAmountAppService(IRepository<CashAmount, string> repository, IRepository<STTerminal, string> repositorySTTerminal, IRepository<AbpWardArea, string> repositoryAbpWardArea)
            : base(repository)
        {
            _repositoryCashAmount = repository;
            _repositorySTTerminal = repositorySTTerminal;
            _repositoryAbpWardArea = repositoryAbpWardArea;
        }

        protected override IQueryable<CashAmount> CreateFilteredQuery(CashAmountRequestDto input)
        {
            input.Sorting = " CreationTime DESC";

            var res = _repositoryCashAmount.GetAll()
                .WhereIf(!input.TerminalID.IsNullOrWhiteSpace(), x => x.TerminalID.Contains(input.TerminalID))
                .WhereIf(!input.IP.IsNullOrWhiteSpace(), x => x.IP.Contains(input.IP))
                .WhereIf(true, x => x.IsSignout == false)
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
            return res;
        }

        [AbpAllowAnonymous]
        [ActionName("GetAll")]
        public override Task<ListResultDto<CashAmountDto>> GetAllListAsync()
        {
            return base.GetAllListAsync();
        }

        [AbpAllowAnonymous]
        [ActionName("GetPage")]
        public override async Task<PagedResultDto<CashAmountDto>> GetAllAsync(CashAmountRequestDto input)
        {
            input.Sorting = "CreationTime,Sort";
            var list = await base.GetAllAsync(input);

            await GetTerminalList(list.Items);
            await GetWardAreaList(list.Items);
            return list;
        }

        // 根据终端编号获取终端列表数据
        private async Task GetTerminalList(IEnumerable<CashAmountDto> infos)
        {
            var terminalIDs = infos.Where(s => !string.IsNullOrWhiteSpace(s.TerminalID)).Select(s => s.TerminalID);
            var terminalList = await _repositorySTTerminal.GetAllListAsync(s => terminalIDs.Contains(s.Code));
            foreach (var info in infos)
            {
                info.Position = terminalList.Find(s => s.Code.Equals(info.TerminalID))?.Position;
                info.WardAreaId = terminalList.Find(s => s.Code.Equals(info.TerminalID))?.WardAreaId;
            }
        }

        // 根据病区ID获取病区列表数据
        private async Task GetWardAreaList(IEnumerable<CashAmountDto> infos)
        {
            var wardAreaIds = infos.Where(s => !string.IsNullOrWhiteSpace(s.WardAreaId)).Select(s => s.WardAreaId);
            var wardAreaList = await _repositoryAbpWardArea.GetAllListAsync(s => wardAreaIds.Contains(s.Id));
            foreach (var info in infos)
            {
                info.WardArea = ObjectMapper.Map<AbpWardAreaDto>(wardAreaList.Find(s => s.Id.Equals(info.WardAreaId)));
            }
        }

        [AbpAllowAnonymous]
        public override Task<CashAmountDto> CreateAsync(CashAmountDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAllowAnonymous]
        [HttpPost, HttpPut]
        public override async Task<CashAmountDto> UpdateAsync([FromBody] CashAmountDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Id))
                throw new UserFriendlyException($"参数{nameof(input.Id)}为空");
            var model = await Repository.GetAsync(input.Id);
            if (model == null)
                throw new UserFriendlyException("数据异常，无此数据，无法执行更新");
            model.IsSignout = input.IsSignout;
            model.TotalMoney = input.TotalMoney;

            var m = await Repository.UpdateAsync(model);
            return MapToEntityDto(m);
        }

        [AbpAllowAnonymous]
        public override Task DeleteAsync(EntityDto<string> input)
        {
            return base.DeleteAsync(input);
        }
    }
}
