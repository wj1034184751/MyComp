
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Cash.Dto;
using System.Collections.Generic;

namespace YuanTu.Platform.Cash
{
    public class CashTradeAppService : AsynPermissionAppService<CashTrade, CashTradeDto, string, CashTradeRequestDto, CashTradeDto, CashTradeDto>, ICashTradeAppService
    {
        private readonly IRepository<CashTrade, string> _repositoryCashTrade;
        public CashTradeAppService(IRepository<CashTrade, string> repository)
            : base(repository)
        {
            _repositoryCashTrade = repository;
        }

        protected override IQueryable<CashTrade> CreateFilteredQuery(CashTradeRequestDto input)
        {
            input.Sorting = " CreationTime DESC";
            var res = _repositoryCashTrade.GetAll()

                .WhereIf(!input.PatientId.IsNullOrWhiteSpace(), x => x.PatientId.Contains(input.PatientId))

                .WhereIf(!input.PatientName.IsNullOrWhiteSpace(), x => x.PatientName.Contains(input.PatientName))

                .WhereIf(!input.LotId.IsNullOrWhiteSpace(), x => x.LotId.Contains(input.LotId))

                .WhereIf(!input.TerminalID.IsNullOrWhiteSpace(), x => x.TerminalID.Contains(input.TerminalID))

                .WhereIf(!input.IP.IsNullOrWhiteSpace(), x => x.IP.Contains(input.IP))

                .WhereIf(!input.MAC.IsNullOrWhiteSpace(), x => x.MAC.Contains(input.MAC))

                .WhereIf(input.RechargeStatus != 999, x => x.RechargeStatus == input.RechargeStatus)

                .WhereIf(input.RefundStatus != 999, x => x.RefundStatus == input.RefundStatus)

                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.CreationTime >= Convert.ToDateTime(input.StartTime))

                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.CreationTime <= Convert.ToDateTime(input.EndTime + " 23:59:59"))

                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);

            return res;
        }

        [AbpAllowAnonymous]
        [ActionName("GetAll")]
        public override Task<ListResultDto<CashTradeDto>> GetAllListAsync()
        {
            return base.GetAllListAsync();
        }

        [AbpAllowAnonymous]
        [ActionName("GetPage")]
        public override Task<PagedResultDto<CashTradeDto>> GetAllAsync(CashTradeRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAllowAnonymous]
        [ActionName("GetExportData")]
        public Task<PagedResultDto<CashTradeDto>> GetExportData(CashTradeRequestDto input)
        {
            input.MaxResultCount = 99999999;
            return base.GetAllAsync(input);
        }

        [AbpAllowAnonymous]
        public override Task<CashTradeDto> CreateAsync(CashTradeDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAllowAnonymous]
        [HttpPost, HttpPut]
        public override Task<CashTradeDto> UpdateAsync([FromBody] CashTradeDto input)
        {
            return base.UpdateAsync(input);
        }

        [AbpAllowAnonymous]
        public override Task DeleteAsync(EntityDto<string> input)
        {
            return base.DeleteAsync(input);
        }

        public async Task<ListResultDto<CashTradeDto>> Query(CashTradeQueryDto dto)
        {
            return await Task.FromResult(new ListResultDto<CashTradeDto>(ObjectMapper.Map<List<CashTradeDto>>(
                Repository.GetAll().Where(v => v.BID == dto.Bid)
                .WhereIf(dto.From.HasValue, v => v.CreationTime > dto.From.Value)
                .WhereIf(dto.To.HasValue, v => v.CreationTime < dto.To.Value).OrderBy(v => v.CreationTime))));
        }
    }
}
