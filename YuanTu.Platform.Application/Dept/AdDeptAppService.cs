using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Dept.Dto;

namespace YuanTu.Platform.Dept
{
    [AbpAuthorize]
    public class AdDeptAppService : AsynPermissionAppService<AdDept, AdDeptDto, long, PagedAdDeptRequestDto, AdDeptDto, AdDeptDto>, IAdDeptAppService
    {
        private readonly IRepository<AdDeptExt, string> _repositoryAdDeptExt;
        public AdDeptAppService(IRepository<AdDept, long> repository,
            IRepository<AdDeptExt, string> repositoryAdDeptExt) : base(repository)
        {
            _repositoryAdDeptExt = repositoryAdDeptExt;
        }

        protected override IQueryable<AdDept> CreateFilteredQuery(PagedAdDeptRequestDto input)
        {
            return Repository.GetAll()
                .Where(s => !s.IsDelete)
                .WhereIf(!string.IsNullOrWhiteSpace(input.CorpCode), s => s.CorpCode == input.CorpCode)
                .WhereIf(input.CorpId.HasValue, s => s.CorpId == input.CorpId.Value);
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<AdDeptDto>> GetAllAsync(PagedAdDeptRequestDto input)
        {
            var list = await base.GetAllAsync(input);

            await GetDtos(list.Items);

            return list;
        }

        private async Task GetDtos(IReadOnlyList<AdDeptDto> list)
        {
            var ids = list.Select(s => s.Id);
            var exts = await _repositoryAdDeptExt.GetAllListAsync(s => ids.Contains(s.DeptId));
            foreach (var info in list)
            {
                var m = exts.Find(s => s.DeptId == info.Id);
                if (m != null)
                {
                    info.GenderRestrictionType = m.GenderRestrictionType;
                    info.MinAge = m.MinAge;
                    info.MaxAge = m.MaxAge;
                    info.Sort = m.Sort;
                } 
            }
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<AdDeptDto>> GetAllListAsync()
        {
            var list = await Repository.GetAllListAsync(s => !s.IsDelete);
            var dtos = ObjectMapper.Map<List<AdDeptDto>>(list);

           await  GetDtos(dtos);

            return new ListResultDto<AdDeptDto>(dtos);
        }

        public override async Task<AdDeptDto> UpdateAsync(AdDeptDto input)
        {
            await AddOrUpdateAdDeptExt(input);

            var result= await base.UpdateAsync(input);

            result.GenderRestrictionType = input.GenderRestrictionType;
            result.MinAge = input.MinAge;
            result.MaxAge = input.MaxAge;
            result.Sort = input.Sort;

            return result;
        }

        private async Task AddOrUpdateAdDeptExt(AdDeptDto input)
        {
            var m = await _repositoryAdDeptExt.FirstOrDefaultAsync(s => s.DeptId == input.Id);
            if (m == null)
            {
                var ext = new AdDeptExt
                {
                    Id = CreateSequentialGuid(),
                    DeptId = input.Id,
                    GenderRestrictionType = input.GenderRestrictionType,
                    MinAge = input.MinAge,
                    MaxAge = input.MaxAge,
                    Sort = input.Sort
                };
                await _repositoryAdDeptExt.InsertAsync(ext);
            }
            else
            {
                m.GenderRestrictionType = input.GenderRestrictionType;
                m.MinAge = input.MinAge;
                m.MaxAge = input.MaxAge;
                m.Sort = input.Sort;
                await _repositoryAdDeptExt.UpdateAsync(m);
            }
        }
    }
}