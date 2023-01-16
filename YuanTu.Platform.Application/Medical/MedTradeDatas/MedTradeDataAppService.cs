using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Medical;
using YuanTu.Platform.Medical.MedTradeDatas.Dto;
using YuanTu.Platform.Sys.AbpColumns.Dto;

namespace YuanTu.Platform.Medical.MedTradeDatas
{
    public class MedTradeDataAppService : AsynPermissionAppService<MedTradeData, MedTradeDataDto, string, MedTradeDataRequestDto, MedTradeDataDto, MedTradeDataDto>, IMedTradeDataAppService
    {
        //private readonly IRepository<AbpTable, string> _repositoryAbpTable;
        private readonly IRepository<MedTradeData, string> _repositoryMedTradeData;
        public MedTradeDataAppService(IRepository<MedTradeData, string> repository)
            : base(repository)
        {
            _repositoryMedTradeData = repository;
        }

        protected override IQueryable<MedTradeData> CreateFilteredQuery(MedTradeDataRequestDto input)
        {
            return _repositoryMedTradeData.GetAll()
                .WhereIf(!input.PersonNo.IsNullOrWhiteSpace(), x => x.PersonNo == input.PersonNo)
                .WhereIf(!input.SendMsgId.IsNullOrWhiteSpace(), x => x.SendMsgId == input.SendMsgId)
                .WhereIf(!input.MdtrtId.IsNullOrWhiteSpace(), x => x.MdtrtId == input.MdtrtId)
                .WhereIf(!input.MedFeeSumamt.IsNullOrWhiteSpace(), x => x.MedFeeSumamt == Convert.ToDecimal(input.MedFeeSumamt))
                .WhereIf(!input.PsnCashPay.IsNullOrWhiteSpace(), x => x.PsnCashPay == Convert.ToDecimal(input.PsnCashPay))
                .WhereIf(!input.PsnAcctPay.IsNullOrWhiteSpace(), x => x.PsnAcctPay == Convert.ToDecimal(input.PsnAcctPay))
                .WhereIf(!input.FundPaySumamt.IsNullOrWhiteSpace(), x => x.FundPaySumamt == Convert.ToDecimal(input.FundPaySumamt));
        }

        [AbpAllowAnonymous]
        [HttpPost, HttpPut]
        public override Task<MedTradeDataDto> UpdateAsync([FromBody] MedTradeDataDto input)
        {
            return base.UpdateAsync(input);
        }
    }
}