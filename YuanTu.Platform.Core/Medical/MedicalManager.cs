using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Medical
{
    public class MedicalManager : IDomainService
    {
        private readonly IRepository<MedTransData,string> _medTransDataRepository;

        public MedicalManager(IRepository<MedTransData,string> medTransDataRepository)
        {
            _medTransDataRepository = medTransDataRepository;
        }

        public virtual async Task<List<MedTransData>> GetEntityByParamAsync(string businessCode,string operCode, string pid)
        {
            Expression<Func<MedTransData, bool>> ExpWhere = PredicateBuilder.True<MedTransData>();

            if (!string.IsNullOrWhiteSpace(businessCode))
            {
                ExpWhere = ExpWhere.And(p => p.BusinessCode == businessCode);
            }
            if (!string.IsNullOrWhiteSpace(operCode))
            {
                ExpWhere = ExpWhere.And(p => p.OperCode == operCode);
            }
            if (!string.IsNullOrWhiteSpace(pid))
            {
                ExpWhere = ExpWhere.And(p => p.Pid.Contains(pid));
            }

            return await _medTransDataRepository.GetAllListAsync(ExpWhere);
        }
    }
}
