using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YuanTu.Platform.Medical.MedCheckExpDatas.Dto;

namespace YuanTu.Platform.Medical.MedCheckExpDatas
{
    public class MedCheckExpDataAppService : AsynPermissionAppService<MedCheckExpData, MedCheckExpDataDto, string, MedCheckExpDataRequestDto, MedCheckExpDataDto, MedCheckExpDataDto>, IMedCheckExpDataAppService
    {
        private readonly IRepository<MedCheckExpData, string> _repositoryMedCheckExpdata;
        public MedCheckExpDataAppService(IRepository<MedCheckExpData, string> repository)
            : base(repository)
        {
            _repositoryMedCheckExpdata = repository;
        }

        protected override IQueryable<MedCheckExpData> CreateFilteredQuery(MedCheckExpDataRequestDto input)
        {
            return _repositoryMedCheckExpdata.GetAll()
                .WhereIf(!input.BusinessCode.IsNullOrWhiteSpace(), x => x.BusinessCode == input.BusinessCode)
                .WhereIf(!input.Pid.IsNullOrWhiteSpace(), x => x.Pid.Contains(input.Pid))
                .WhereIf(!input.MedicareLogno.IsNullOrWhiteSpace(), x => x.MedicareLogno == input.MedicareLogno)
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
        }
    }
}
