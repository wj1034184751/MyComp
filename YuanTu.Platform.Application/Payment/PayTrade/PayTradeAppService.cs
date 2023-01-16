using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Payment.Dto;

namespace YuanTu.Platform.Payment
{
    [AbpAuthorize]
    public class PayTradeAppService : AsynPermissionAppService<PayTrade, PayTradeDto, string, PagePayTradeRequestDto, PayTradeDto, PayTradeDto>, IPayTradeAppService
    {
        public PayTradeAppService(IRepository<PayTrade, string> repository) : base(repository)
        {
        }

        protected override IQueryable<PayTrade> CreateFilteredQuery(PagePayTradeRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.OutTradeNo.IsNullOrWhiteSpace(), t => t.OutPayNo.Equals(input.OutTradeNo) || t.OutTradeNo.Equals(input.OutTradeNo))
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), t => t.PatientName.Equals(input.Keyword) || t.CardNo.Equals(input.Keyword) || t.DeviceInfo.Equals(input.Keyword))
                .WhereIf(!input.TradeMode.IsNullOrWhiteSpace(), t => t.TradeMode.Equals(input.TradeMode))
                .WhereIf(input.FeeChannel.HasValue && input.FeeChannel.Value != 0, t => t.FeeChannel == input.FeeChannel.Value)
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), t => t.PayTime <= Convert.ToDateTime(input.EndTime))
                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), t => t.PayTime >= Convert.ToDateTime(input.StartTime));

        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<PayTradeDto>> GetAllAsync(PagePayTradeRequestDto input)
        {
            return base.GetAllAsync(input);
        }

        [AbpAllowAnonymous]
        public override Task<PayTradeDto> CreateAsync(PayTradeDto input)
        {
            return base.CreateAsync(input);
        }
    }
}
