using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuanTu.Platform.Union
{
    public class UnionConfigDataAppService : AsynPermissionAppService<UnionConfigData, UnionConfigDto, string, UnionBaseRequestDto, UnionConfigDto, UnionConfigDto>,IUnionConfigDataAppService
    {
        private readonly IRepository<UnionConfigData, string> _repositoryUnionConfigData;
        public UnionConfigDataAppService(IRepository<UnionConfigData, string> repository)
            : base(repository)
        {
            _repositoryUnionConfigData = repository;
        }

        protected override IQueryable<UnionConfigData> CreateFilteredQuery(UnionBaseRequestDto input)
        {
            return _repositoryUnionConfigData.GetAll()
                .WhereIf(!input.CardReaderName.IsNullOrWhiteSpace(), x => x.CardReaderName == input.CardReaderName)
                .WhereIf(!input.MKeyboardName.IsNullOrWhiteSpace(), x => x.MKeyboardName == input.MKeyboardName);
        }


    }
}
