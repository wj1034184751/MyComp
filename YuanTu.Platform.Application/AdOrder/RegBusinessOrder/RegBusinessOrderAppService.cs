using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.RegBusinessOrder.Dto;

namespace YuanTu.Platform.AdOrder
{
    [AbpAuthorize]
    public class RegBusinessOrderAppService : AsynPermissionAppService<AdRegBusinessOrder, RegBusinessOrderDto, string, PagedRegBusinessOrderRequestDto, RegBusinessOrderDto, RegBusinessOrderDto>, IRegBusinessOrderAppService
    {
        private readonly IRepository<AdUserAccount, string> _adUserAccountRepository;
        public RegBusinessOrderAppService(IRepository<AdRegBusinessOrder, string> repository, IRepository<AdUserAccount, string> adUserAccountRepository) : base(repository)
        {
            _adUserAccountRepository = adUserAccountRepository;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<RegBusinessOrderDto>> GetAllAsync(PagedRegBusinessOrderRequestDto input)
        {
            if (input.OptType == 0) input.OptType = 3;
            var query = this.Repository.GetAll().Where(c => !c.IsDelete && c.OptType == input.OptType)
               .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.GmtCreate >= Convert.ToDateTime(input.StartTime))
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.GmtCreate <= Convert.ToDateTime(input.EndTime).AddDays(1))
                .WhereIf(!input.DeviceNo.IsNullOrWhiteSpace(), x => x.DeviceNo.Contains(input.DeviceNo)).Join(
                _adUserAccountRepository.GetAll()
                .WhereIf(!input.PatientName.IsNullOrWhiteSpace(), x => x.PatientName.Contains(input.PatientName))
                .WhereIf(!input.IdNo.IsNullOrWhiteSpace(), x => x.IdNo.Contains(input.IdNo))
                .WhereIf(!input.Phone.IsNullOrWhiteSpace(), x => x.Phone.Contains(input.Phone)),
                x => x.UserAccountId, s => s.Id,
                (x, s) => new { x, s.PatientName, s.IdNo, s.Phone,s.PatientId }
                )
                .OrderByDescending(c => c.x.GmtCreate);

            var result = new List<RegBusinessOrderDto>();


            var totalCount = await query.CountAsync();
            var pagedList = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            foreach (var info in pagedList)
            {
                var m = MapToEntityDto(info.x);
                m.PatientName = info.PatientName;
                m.IdNo = info.IdNo;
                m.Phone = info.Phone;
                m.PatientId = info.PatientId;
                result.Add(m);
            }

            var dto = new PagedResultDto<RegBusinessOrderDto>(totalCount, ObjectMapper.Map<List<RegBusinessOrderDto>>(result));

            return dto;
        }
    }
}