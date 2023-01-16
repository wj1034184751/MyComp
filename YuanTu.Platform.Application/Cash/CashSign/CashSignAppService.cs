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
using System;

namespace YuanTu.Platform.Cash
{
    public class CashSignAppService : AsynPermissionAppService<CashSign, CashSignDto, string, CashSignRequestDto, CashSignDto, CashSignDto>, ICashSignAppService
    {
        #region
        private readonly IRepository<CashSign, string> _repositoryCashSign;
        public CashSignAppService(IRepository<CashSign, string> repository)
            : base(repository)
        {
            _repositoryCashSign = repository;
        }

        protected override IQueryable<CashSign> CreateFilteredQuery(CashSignRequestDto input)
        {
            input.Sorting = " CreationTime DESC";

            var res = _repositoryCashSign.GetAll()

                .WhereIf(!input.LotId.IsNullOrWhiteSpace(), x => x.LotId.Contains(input.LotId))

                .WhereIf(!input.TerminalID.IsNullOrWhiteSpace(), x => x.TerminalID.Contains(input.TerminalID))

                .WhereIf(!input.IP.IsNullOrWhiteSpace(), x => x.IP.Contains(input.IP))

                .WhereIf(!input.MAC.IsNullOrWhiteSpace(), x => x.MAC.Contains(input.MAC))

                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.CreationTime >= Convert.ToDateTime(input.StartTime))

                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.CreationTime <= Convert.ToDateTime(input.EndTime + " 23:59:59"))

                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);

            return res;
        }

        [AbpAllowAnonymous]
        [ActionName("GetAll")]
        public override Task<ListResultDto<CashSignDto>> GetAllListAsync()
        {
            return base.GetAllListAsync();
        }

        #endregion

        [AbpAllowAnonymous]
        [ActionName("GetPage")]
        public override Task<PagedResultDto<CashSignDto>> GetAllAsync(CashSignRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAllowAnonymous]
        [ActionName("GetExportData")]
        public Task<PagedResultDto<CashSignDto>> GetExportData(CashSignRequestDto input)
        {
            input.MaxResultCount = 99999999;
            return base.GetAllAsync(input);
        }

        [AbpAllowAnonymous]
        public override Task<CashSignDto> CreateAsync(CashSignDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAllowAnonymous]
        [HttpPost, HttpPut]
        public override async Task<CashSignDto> UpdateAsync([FromBody] CashSignDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Id)) throw new UserFriendlyException($"参数{nameof(input.Id)}为空");
            var model = await Repository.GetAsync(input.Id);
            if (model == null) throw new UserFriendlyException("数据异常，无此数据，无法执行更新");
            model.SignoutTime = input.SignoutTime;
            model.IsSignout = input.IsSignout;
            model.ReportedMoney = input.ReportedMoney;
            model.TotalMoney = input.TotalMoney;
            model.IsLocked = input.IsLocked;
            model.TotalCount = input.TotalCount;
            model.UnkownTotalCount = input.UnkownTotalCount;
            model.UnkownTotalMoney = input.UnkownTotalMoney;
            model.FailTotalCount = input.FailTotalCount;
            model.FailTotalMoney = input.FailTotalMoney;
            model.SuccessTotalCount = input.SuccessTotalCount;
            model.SuccessTotalMoney = input.SuccessTotalMoney;
            model.RefundTotalCount = input.RefundTotalCount;
            model.RefundTotalMoney = input.RefundTotalMoney;
            model.Operator = input.Operator;

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
