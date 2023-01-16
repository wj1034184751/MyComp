using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Health.Dto;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.Health
{
    [AbpAuthorize]
    public class HealthUserDataAppService : AsynPermissionAppService<HealthUserData, HealthUserDataDto, string, PagedHealthUserDataRequestDto, HealthUserDataDto, HealthUserDataDto>, IHealthUserDataAppService
    { 
        public HealthUserDataAppService(IRepository<HealthUserData, string> repository) : base(repository)
        { 
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<HealthUserDataDto>> GetAllAsync(PagedHealthUserDataRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            var list = await base.GetAllAsync(input);
            foreach (var info in list.Items)
                info.IdNo = info.IdNo.Mask(6, 8);
            return list;
        }

        protected override IQueryable<HealthUserData> CreateFilteredQuery(PagedHealthUserDataRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                    x => x.Name.Contains(input.Keyword) || x.IdNo.Contains(input.Keyword));
        }

        [AbpAllowAnonymous]
        public override async Task<HealthUserDataDto> CreateAsync([FromForm]HealthUserDataDto input)
        {
            if (!string.IsNullOrWhiteSpace(input.Id))
            {
               await Repository.UpdateAsync(MapToEntity(input));
               return input;
            }

            return await base.CreateAsync(input);
        }


        public async Task<HealthStatisticsDto> GetHealthStatisticsAsync(HealthStatisticsInputDto input)
        {
            var now = DateTime.Now;
            var startTime = now.AddDays(-30).ToShortDateString().ToDateTime();
            var endTime = now.AddDays(1).ToShortDateString().ToDateTime().AddSeconds(-1);
            if (input.StarTime.HasValue)
                startTime = input.StarTime.Value.ToShortDateString().ToDateTime();
            if (input.EndTime.HasValue)
                endTime = input.EndTime.Value.AddDays(1).ToShortDateString().ToDateTime().AddSeconds(-1);

            var list = await Repository.GetAllListAsync(s => s.CreationTime >= startTime && s.CreationTime <= endTime);
            var count = list.Count;
            var model = new HealthStatisticsDto();
            if (count > 0)
            {
                model.TestTotalCount = count;
                model.TestAvgTime = list.Average(s => s.BpTime + s.HtTime + s.TempTime + s.SaO2Time + s.FatTime + s.EcgTime).ToInt(); 
                model.TestSuccessRate = list.Count(s => s.IsComplete) / count * 100;
                model.BpTime = list.Average(s => s.BpTime).ToInt();
                model.HtTime = list.Average(s => s.HtTime).ToInt();
                model.TempTime = list.Average(s => s.TempTime).ToInt();
                model.SaO2Time = list.Average(s => s.SaO2Time).ToInt();
                model.FatTime = list.Average(s => s.FatTime).ToInt();
                model.EcgTime = list.Average(s => s.EcgTime).ToInt();
            };

            var groups = list.GroupBy(s => s.CreationTime.ToString("M.dd")).Select(s => new { s.Key, Count = s.Count() }).ToDictionary(s => s.Key, s => s.Count);

            var dic = new Dictionary<string, int>();
            var m = (endTime - startTime).TotalDays.ToInt();
            for (var i = 0; i < m; i++)
            {
                var b = startTime.AddDays(i);
                var key = b.ToString("M.dd");
                dic.Add(key, groups.ContainsKey(key) ? groups[key] : 0);
            }
            model.TestAvgCounts = dic;

            return model;
        }
    }
}