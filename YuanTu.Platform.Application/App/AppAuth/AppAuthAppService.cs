using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.App.Dto;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.App
{
    [AbpAuthorize]
    public class AppAuthAppService : AsynPermissionAppService<AppAuth, AppAuthDto, string, PagedAppAuthRequestDto, AppAuthDto, AppAuthDto>, IAppAuthAppService
    {
        public AppAuthAppService(IRepository<AppAuth, string> repository) : base(repository)
        {
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<AppAuthDto>> GetAllAsync(PagedAppAuthRequestDto input)
        {
            input.Sorting = "CreationTime,Enabled desc";
            var dto = await base.GetAllAsync(input);
            foreach (var info in dto.Items)
                info.Token = Encoding.UTF8.GetBytes($"{info.AppId}{info.AppSecret}").ComputeMD5(true); 
            return dto;
        }

        protected override IQueryable<AppAuth> CreateFilteredQuery(PagedAppAuthRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.AppId.Contains(input.Keyword));
        }

        [AbpAllowAnonymous]
        public async Task<AppAuthDto> GetByAppIdAsync(string appId)
        {
            if (string.IsNullOrWhiteSpace(appId)) return null;
            var m = await Repository.FirstOrDefaultAsync(s => s.AppId.Equals(appId));
            var dto = MapToEntityDto(m);
            dto.Token = Encoding.UTF8.GetBytes($"{dto.AppId}{dto.AppSecret}").ComputeMD5(true);
            return dto;
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
                model.Enabled = "1".Equals(status);
                await Repository.UpdateAsync(model);
            }

            return true;
        }
    }
}