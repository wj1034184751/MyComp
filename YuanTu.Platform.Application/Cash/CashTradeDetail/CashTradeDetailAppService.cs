
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Linq;
using YuanTu.Platform.Cash.Dto;

namespace YuanTu.Platform.Cash
{
    public class CashTradeDetailAppService : AsynPermissionAppService<CashTradeDetail, CashTradeDetailDto, string, CashTradeDetailRequestDto, CashTradeDetailDto, CashTradeDetailDto>, ICashTradeDetailAppService
    {
        private readonly IRepository<CashTradeDetail, string> _repositoryCashTradeDetail;
        public CashTradeDetailAppService(IRepository<CashTradeDetail, string> repository)
            : base(repository)
        {
            _repositoryCashTradeDetail = repository;
        }

        protected override IQueryable<CashTradeDetail> CreateFilteredQuery(CashTradeDetailRequestDto input)
        {
            input.Sorting = " CreationTime DESC";

            return _repositoryCashTradeDetail.GetAll()

                .WhereIf(!input.LotId.IsNullOrWhiteSpace(), x => x.LotId == input.LotId)

                .WhereIf(!input.CashTradeId.IsNullOrWhiteSpace(), x => x.CashTradeId.Contains(input.CashTradeId))

                .WhereIf(!input.Money.IsNullOrWhiteSpace(), x => x.Money == Convert.ToInt32(input.Money))

                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
        }
    }
}
