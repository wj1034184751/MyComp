using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Health.Dto; 

namespace YuanTu.Platform.Health
{
    [AbpAuthorize]
    public class HealthConfigAppService : AsynPermissionAppService<HealthConfig, HealthConfigDto, string, PagedHealthConfigRequestDto, HealthConfigDto, HealthConfigDto>, IHealthConfigAppService
    { 
        public HealthConfigAppService(IRepository<HealthConfig, string> repository) : base(repository)
        { 
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<HealthConfigDto>> GetAllAsync(PagedHealthConfigRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            var list = await base.GetAllAsync(input); 
            return list;
        }

        protected override IQueryable<HealthConfig> CreateFilteredQuery(PagedHealthConfigRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        }

        public async Task<bool> BatchActiveAsync(dynamic data)
        {
            string ids = data.ids;
            string status = data.status;
            if (string.IsNullOrWhiteSpace(ids)) return false;
            var arr = ids.Split(',');
            foreach (var id in arr)
            {
                var model = await Repository.GetAsync(id);
                model.IsActive = "1".Equals(status);
                await Repository.UpdateAsync(model);
            }

            return true;
        }
    }
}