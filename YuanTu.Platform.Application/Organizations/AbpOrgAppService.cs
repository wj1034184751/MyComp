using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Authorization.Roles;
using YuanTu.Platform.Authorization.Users;
using YuanTu.Platform.Organizations.Dto;


namespace YuanTu.Platform.Organizations
{
    [AbpAuthorize]
    public class AbpOrgAppService : AsynPermissionAppService<AbpOrg, AbpOrgDto, long, PagedAbpOrgResultRequestDto, AbpOrgDto, AbpOrgDto>, IAbpOrgAppService
    {
        private readonly IRepository<User, long> _repositoryUser;
        private readonly RoleManager _roleManager;
        public AbpOrgAppService(IRepository<AbpOrg, long> repository, IRepository<User, long> repositoryUser, RoleManager roleManager) : base(repository)
        {
            _repositoryUser = repositoryUser;
            _roleManager = roleManager;
        }

        [AbpAllowAnonymous]
        public async Task<ListResultDto<AbpOrgExDto>> GetOrgsAsync()
        {
            var list = ObjectMapper.Map<List<AbpOrgExDto>>(await Repository.GetAllListAsync());
            return new ListResultDto<AbpOrgExDto>(list);
        }

        [AbpAllowAnonymous]
        public async Task<ListResultDto<AbpOrgExDto>> GetOrgsByUidAsync(string u)
        {
            if (!string.IsNullOrWhiteSpace(u))
            {
                var user = await _repositoryUser.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(
                    s => s.UserName.Equals(u) || s.EmailAddress.Equals(u));

                if (user == null) return new ListResultDto<AbpOrgExDto>();

                var orgids = user.OrgIds;
                if (!string.IsNullOrWhiteSpace(orgids))
                {
                    var arr = orgids.Split(',');
                    var orgs = await Repository.GetAllListAsync(s => arr.Contains(s.Id.ToString()));
                    var list = ObjectMapper.Map<List<AbpOrgExDto>>(orgs);
                    return new ListResultDto<AbpOrgExDto>(list);
                }

                var roleIds = user.Roles.Select(x => x.RoleId).ToArray();
                var roles = _roleManager.Roles.Where(r => roleIds.Contains(r.Id)).Select(r => r.NormalizedName);

                if (roles.Contains("ADMIN") || roles.Contains("超级管理员"))
                {
                    var list = await GetOrgsAsync();
                    return list.Items.Count == 0
                        ? new ListResultDto<AbpOrgExDto>(new List<AbpOrgExDto>
                            {new AbpOrgExDto {Id = 0, DisplayName = "默认机构"}})
                        : list;
                }
            }
            return new ListResultDto<AbpOrgExDto>();
        }

        [AbpAllowAnonymous]
        public async Task<ListResultDto<AbpExtOrgDto>> GetExtOrgsAsync()
        {
            var list = (await Repository.GetAllListAsync()).Select(s => new AbpExtOrgDto
            {
                Id = s.Id,
                HospitalCode = s.Code,
                HospitalName = s.DisplayName,
                HospitalId = s.HospitalId,
                UnionId = s.UnionId
            }).ToList();
            return new ListResultDto<AbpExtOrgDto>(list);
        }

        protected override IQueryable<AbpOrg> CreateFilteredQuery(PagedAbpOrgResultRequestDto input)
        {
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Code.Contains(input.Keyword) || x.DisplayName.Contains(input.Keyword));
        }

        public override async Task<AbpOrgDto> CreateAsync(AbpOrgDto input)
        {
            CheckCreatePermission();

            var entity = MapToEntity(input);
            entity.Parent = null;
            entity.ParentId = null;
            await Repository.InsertAsync(entity);

            return MapToEntityDto(entity);
        }

        public override async Task<AbpOrgDto> UpdateAsync(AbpOrgDto input)
        {
            CheckUpdatePermission();

            var entity = await GetEntityByIdAsync(input.Id);
            MapToEntity(input, entity);
            entity.Parent = null;
            entity.ParentId = null;
            await Repository.UpdateAsync(entity);

            return MapToEntityDto(entity);
        }

        public override async Task DeleteByIds(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");

            var arr = ids.Split(',');
            if (arr.Length == 0) return;

            var d = arr.Select(s =>
            {
                if (long.TryParse(s, out var id))
                    return id;
                return -1;
            }).Where(s => s > -1);

            await Repository.DeleteAsync(s => d.Contains(s.Id));
        }
    }
}