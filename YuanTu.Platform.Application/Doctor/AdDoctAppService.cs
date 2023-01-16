using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using YuanTu.Platform.Doctor.Dto;

namespace YuanTu.Platform.Doctor
{
    [AbpAuthorize]
    public class AdDoctAppService : AsynPermissionAppService<AdDoct, AdDoctDto, long, PagedAdDoctRequestDto, AdDoctDto, AdDoctDto>, IAdDoctAppService
    {
        private readonly IRepository<AdDoctExt, string> _repositoryAdDoctExt;
        public AdDoctAppService(IRepository<AdDoct, long> repository, IRepository<AdDoctExt, string> repositoryAdDoctExt) : base(repository)
        {
            _repositoryAdDoctExt = repositoryAdDoctExt;
        }

        protected override IQueryable<AdDoct> CreateFilteredQuery(PagedAdDoctRequestDto input)
        {
            return Repository.GetAll()
                .Where(s => !s.IsDelete)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), s => s.DoctName == input.Keyword)
                .WhereIf(!string.IsNullOrWhiteSpace(input.DeptCode), s => s.DeptCode == input.DeptCode)
                .WhereIf(!string.IsNullOrWhiteSpace(input.CorpCode), s => s.CorpCode == input.CorpCode)
                .WhereIf(input.CorpId.HasValue, s => s.CorpId == input.CorpId.Value);
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<AdDoctDto>> GetAllAsync(PagedAdDoctRequestDto input)
        {
            var list = await base.GetAllAsync(input);

            await GetDtos(list);

            return list;
        }

        private async Task GetDtos(PagedResultDto<AdDoctDto> list)
        {
            var ids = list.Items.Select(s => s.Id);
            var exts = await _repositoryAdDoctExt.GetAllListAsync(s => ids.Contains(s.DoctId));
            foreach (var info in list.Items)
            {
                var m = exts.Find(s => s.DoctId == info.Id);
                info.Sort = m?.Sort ?? 0;
            }
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<AdDoctDto>> GetAllListAsync()
        {
            var list = await Repository.GetAllListAsync(s => !s.IsDelete);
            var dtos = ObjectMapper.Map<List<AdDoctDto>>(list);
            return new ListResultDto<AdDoctDto>(dtos);
        }

        public override async Task<AdDoctDto> UpdateAsync(AdDoctDto input)
        {
            await AddAdDoctExt(input);

            var result = await base.UpdateAsync(input);

            result.Sort = input.Sort;

            return result;
        }

        private async Task AddAdDoctExt(AdDoctDto input)
        {
            var m = await _repositoryAdDoctExt.FirstOrDefaultAsync(s => s.DoctId == input.Id);
            if (m == null)
            {
                var ext = new AdDoctExt
                {
                    Id = CreateSequentialGuid(),
                    DoctId = input.Id,
                    Sort = input.Sort
                };
                await _repositoryAdDoctExt.InsertAsync(ext);
            }
            else
            {
                m.Sort = input.Sort;
                await _repositoryAdDoctExt.UpdateAsync(m);
            }
        }
    }
}