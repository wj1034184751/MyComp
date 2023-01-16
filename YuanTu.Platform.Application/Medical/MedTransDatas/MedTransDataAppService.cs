using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Http;
using YuanTu.Platform.Medical;
using YuanTu.Platform.Medical.MedTransDatas.Dto;
using YuanTu.Platform.Sys.AbpColumns.Dto;

namespace YuanTu.Platform.Medical.MedTransDatas
{
    public class MedTransDataAppService : AsynPermissionAppService<MedTransData, MedTransDataDto, string, MedTransDataRequestDto, MedTransDataDto, MedTransDataDto>, IMedTransDataAppService
    {
        //private readonly IRepository<AbpTable, string> _repositoryAbpTable;
        private readonly IRepository<MedTransData, string> _repositoryMedTransData;
        public MedTransDataAppService(IRepository<MedTransData, string> repository)
            : base(repository)
        {
            _repositoryMedTransData = repository;
        }

        #region 同步
        //public ListResultDto<MedTransDataDto> GetEntityByParamAsync(MedicalDataRequestDto input)
        //{
        //    Expression<Func<MedTransData, bool>> ExpWhere = PredicateBuilder.True<MedTransData>();

        //    if (!string.IsNullOrWhiteSpace(input.BusinessCode))
        //    {
        //        ExpWhere = ExpWhere.And(p => p.BusinessCode == input.BusinessCode);
        //    }
        //    if (!string.IsNullOrWhiteSpace(input.OperCode))
        //    {
        //        ExpWhere = ExpWhere.And(p => p.OperCode == input.OperCode);
        //    }
        //    if (!string.IsNullOrWhiteSpace(input.Pid))
        //    {
        //        ExpWhere = ExpWhere.And(p => p.Pid.Contains(input.Pid));
        //    }

        //    return  new ListResultDto<MedTransDataDto>(ObjectMapper.Map<List<MedTransDataDto>>(_repositoryMedTransData.GetAllList(ExpWhere).ToList()));
        //}
        #endregion

        protected override IQueryable<MedTransData> CreateFilteredQuery(MedTransDataRequestDto input)
        {
            return _repositoryMedTransData.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Name.Contains(input.Keyword) || x.Pid.Contains(input.Keyword) || x.PatientId.Contains(input.Keyword))
                .WhereIf(!input.MedicareLogno.IsNullOrWhiteSpace(), x => x.MedicareLogno == input.MedicareLogno)
                .WhereIf(!input.StartDate.IsNullOrWhiteSpace(), x => x.TransDate >= Convert.ToDateTime(input.StartDate))
                .WhereIf(!input.EndDate.IsNullOrWhiteSpace(), x => x.TransDate <= Convert.ToDateTime(input.EndDate))
                .WhereIf(!input.TransResult.IsNullOrWhiteSpace(), x => x.TransResult == Convert.ToInt32(input.TransResult))
                .WhereIf(!input.TransType.IsNullOrWhiteSpace(), x => x.TransType == Convert.ToInt32(input.TransType))
                 .WhereIf(!input.MedicareType.IsNullOrWhiteSpace(), x => x.MedicareType == input.MedicareType)
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
        }

        #region 异步
        //public async Task<ListResultDto<MedTransDataDto>> GetEntityByParamAsync(MedTransDataRequestDto input)
        //{
        //    Expression<Func<MedTransData, bool>> ExpWhere = PredicateBuilder.True<MedTransData>();

        //    if (!string.IsNullOrWhiteSpace(input.BusinessCode))
        //    {
        //        ExpWhere = ExpWhere.And(p => p.BusinessCode == input.BusinessCode);
        //    }
        //    if (!string.IsNullOrWhiteSpace(input.OperCode))
        //    {
        //        ExpWhere = ExpWhere.And(p => p.OperCode == input.OperCode);
        //    }
        //    if (!string.IsNullOrWhiteSpace(input.Pid))
        //    {
        //        ExpWhere = ExpWhere.And(p => p.Pid.Contains(input.Pid));
        //    }
        //    var list = await _repositoryMedTransData.GetAllListAsync(ExpWhere);

        //    return new ListResultDto<MedTransDataDto>(ObjectMapper.Map<List<MedTransDataDto>>(list));
        //}
        #endregion
    }
}