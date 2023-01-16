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
using YuanTu.Platform.SetPatientBusinessOrder.Dto;

namespace YuanTu.Platform.AdOrder
{
    [AbpAuthorize]
    public class SetPatientBusinessOrderAppService : AsynPermissionAppService<AdSetPatientBusinessOrder, SetPatientBusinessOrderDto, string, PagedSetPatientBusinessOrderRequestDto, SetPatientBusinessOrderDto, SetPatientBusinessOrderDto>, ISetPatientBusinessOrderAppService
    {
        private readonly IRepository<AdUserAccount, string> _adUserAccountRepository;
        public SetPatientBusinessOrderAppService(IRepository<AdSetPatientBusinessOrder, string> repository, IRepository<AdUserAccount, string> adUserAccountRepository) : base(repository)
        {
            _adUserAccountRepository = adUserAccountRepository;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<SetPatientBusinessOrderDto>> GetAllAsync(PagedSetPatientBusinessOrderRequestDto input)
        {
            var query = this.Repository.GetAll().Where(c => !c.IsDelete)
               .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.GmtCreate >= Convert.ToDateTime(input.StartTime))
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.GmtCreate <= Convert.ToDateTime(input.EndTime).AddDays(1))
                .WhereIf(!input.DeviceNo.IsNullOrWhiteSpace(), x => x.DeviceNo.Contains(input.DeviceNo)).Join(
                _adUserAccountRepository.GetAll()
                .WhereIf(!input.PatientName.IsNullOrWhiteSpace(), x => x.PatientName.Contains(input.PatientName))
                .WhereIf(!input.IdNo.IsNullOrWhiteSpace(), x => x.IdNo.Contains(input.IdNo))
                .WhereIf(!input.Phone.IsNullOrWhiteSpace(), x => x.Phone.Contains(input.Phone)),
                x => x.UserAccountId, s => s.Id,
                (x, s) => new { x, s.PatientName, s.IdNo, s.Phone }
                )
                .OrderByDescending(c => c.x.GmtCreate);

            var result = new List<SetPatientBusinessOrderDto>();


            var totalCount = await query.CountAsync();
            var pagedList = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            foreach (var info in pagedList)
            {
                var m = MapToEntityDto(info.x);
                m.PatientName = info.PatientName;
                m.IdNo = info.IdNo;
                m.Phone = info.Phone;
                result.Add(m);
            }

            var dto = new PagedResultDto<SetPatientBusinessOrderDto>(totalCount, ObjectMapper.Map<List<SetPatientBusinessOrderDto>>(result));

            return dto;
        }
    }
}