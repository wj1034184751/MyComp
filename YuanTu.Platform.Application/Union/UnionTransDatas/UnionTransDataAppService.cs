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

namespace YuanTu.Platform.Union
{
    [AbpAuthorize]
    public class UnionTransDataAppService : AsynPermissionAppService<UnionTransData, UnionDataDto, string, UnionBaseRequestDto, UnionDataDto, UnionDataDto>, IUnionTransDataAppService
    {
        private readonly IRepository<UnionTransData, string> _repositoryUnionTransData;
        public UnionTransDataAppService(IRepository<UnionTransData, string> repository)
            : base(repository)
        {
            _repositoryUnionTransData = repository;
        }

        protected override IQueryable<UnionTransData> CreateFilteredQuery(UnionBaseRequestDto input)
        {
            var res = _repositoryUnionTransData.GetAll()

                .WhereIf(!input.PatientId.IsNullOrWhiteSpace(), x => x.PatientId == input.PatientId)

                .WhereIf(!input.cardNo.IsNullOrWhiteSpace(), x => x.IdNo == input.Pid)

                .WhereIf(!input.PlatformNo.IsNullOrWhiteSpace(), x => x.PlatformNo == input.PlatformNo)

                .WhereIf(!input.PatientName.IsNullOrWhiteSpace(), x => x.PatientName == input.PatientName)

                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.FinishTime >= Convert.ToDateTime(input.StartTime))

                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.FinishTime <= Convert.ToDateTime(input.EndTime))

                .WhereIf(input.MaxAmount != 0 && input.MinAmount != 0, x => x.Amount >= input.MinAmount && x.Amount <= input.MaxAmount)
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);

            return res;
        }
    }
}
