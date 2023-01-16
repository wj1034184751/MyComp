using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using YuanTu.Platform.Authorization;
using YuanTu.Platform.Authorization.Roles;
using YuanTu.Platform.Authorization.Users;
using YuanTu.Platform.Roles.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Authorization.Menus;

namespace YuanTu.Platform.Roles
{
    [AbpAuthorize(PermissionNames.Pages_Roles)]
    public class RoleAppService : AsyncCrudAppService<Role, RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>, IRoleAppService
    {
        private readonly RoleManager _roleManager;
        private readonly UserManager _userManager;
        private readonly IRepository<AbpMenuPermission, long> _repositoryMenuPermission;

        public RoleAppService(IRepository<Role> repository, RoleManager roleManager, UserManager userManager, IRepository<AbpMenuPermission, long> repositoryMenuPermission)
            : base(repository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _repositoryMenuPermission = repositoryMenuPermission;
        }

        public override async Task<RoleDto> CreateAsync(CreateRoleDto input)
        {
            CheckCreatePermission();

            var role = ObjectMapper.Map<Role>(input);
            role.SetNormalizedName();

            CheckErrors(await _roleManager.CreateAsync(role));

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            await AddMenuPermissions(role, input.MenuPermissions);

            return MapToEntityDto(role);
        }

        private async Task AddMenuPermissions(Role role, List<string> menuPermissions)
        {
            foreach (var menuId in menuPermissions)
            {
                await _repositoryMenuPermission.InsertAsync(new AbpMenuPermission
                {
                    MenuId = menuId,
                    RoleId = role.Id,
                    TenantId = AbpSession.TenantId
                });
            }
        }

        private async Task DeleteMenuPermissions(Role role)
        {
            await _repositoryMenuPermission.DeleteAsync(s => s.RoleId == role.Id);
        }

        public async Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input)
        {
            var roles = await _roleManager
                .Roles
                .WhereIf(
                    !input.Permission.IsNullOrWhiteSpace(),
                    r => r.Permissions.Any(rp => rp.Name == input.Permission && rp.IsGranted)
                )
                .ToListAsync();

            return new ListResultDto<RoleListDto>(ObjectMapper.Map<List<RoleListDto>>(roles));
        }

        public override async Task<RoleDto> UpdateAsync(RoleDto input)
        {
            CheckUpdatePermission();

            var role = await _roleManager.GetRoleByIdAsync(input.Id);

            ObjectMapper.Map(input, role);

            CheckErrors(await _roleManager.UpdateAsync(role));

            var grantedPermissions = PermissionManager
                .GetAllPermissions()
                .Where(p => input.GrantedPermissions.Contains(p.Name))
                .ToList();

            await _roleManager.SetGrantedPermissionsAsync(role, grantedPermissions);

            await DeleteMenuPermissions(role);
            await AddMenuPermissions(role, input.MenuPermissions);

            return MapToEntityDto(role);
        }

        public override async Task DeleteAsync(EntityDto<int> input)
        {
            CheckDeletePermission();

            var role = await _roleManager.FindByIdAsync(input.Id.ToString());
            var users = await _userManager.GetUsersInRoleAsync(role.NormalizedName);

            foreach (var user in users)
            {
                CheckErrors(await _userManager.RemoveFromRoleAsync(user, role.NormalizedName));
            }

            await DeleteMenuPermissions(role);

            CheckErrors(await _roleManager.DeleteAsync(role));
        }

        public Task<ListResultDto<PermissionDto>> GetAllPermissions()
        {
            var permissions = PermissionManager.GetAllPermissions();

            return Task.FromResult(new ListResultDto<PermissionDto>(
                ObjectMapper.Map<List<PermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList()
            ));
        }

        protected override IQueryable<Role> CreateFilteredQuery(PagedRoleResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Permissions)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Keyword)
                || x.DisplayName.Contains(input.Keyword)
                || x.Description.Contains(input.Keyword));
        }

        protected override async Task<Role> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAllIncluding(x => x.Permissions).FirstOrDefaultAsync(x => x.Id == id);
        }

        protected override IQueryable<Role> ApplySorting(IQueryable<Role> query, PagedRoleResultRequestDto input)
        {
            return query.OrderBy(r => r.DisplayName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public async Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input)
        {
            var permissions = PermissionManager.GetAllPermissions();
            var role = await _roleManager.GetRoleByIdAsync(input.Id);
            var grantedPermissions = (await _roleManager.GetGrantedPermissionsAsync(role)).ToArray();
            var roleEditDto = ObjectMapper.Map<RoleEditDto>(role);

            return new GetRoleForEditOutput
            {
                Role = roleEditDto,
                Permissions = ObjectMapper.Map<List<FlatPermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList(),
                GrantedPermissionNames = grantedPermissions.Select(p => p.Name).ToList()
            };
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<RoleDto>> GetAllAsync(PagedRoleResultRequestDto input)
        {
            var dto = await base.GetAllAsync(input);
            var ids = dto.Items.Select(s => s.Id);
            var permissions = await _repositoryMenuPermission.GetAllListAsync(s => ids.Contains(s.RoleId));
            foreach (var info in dto.Items)
                info.MenuPermissions = permissions.Where(s => s.RoleId == info.Id).Select(s => s.MenuId).ToList();
            return dto;
        }

        [ActionName("GetAll")]
        public async Task<ListResultDto<RoleDto>> GetAllListAsync()
        {
            var list = await Repository.GetAllListAsync();
            var items = ObjectMapper.Map<List<RoleDto>>(list);
            var ids = items.Select(s => s.Id);
            var permissions = await _repositoryMenuPermission.GetAllListAsync(s => ids.Contains(s.RoleId));
            foreach (var info in items)
                info.MenuPermissions = permissions.Where(s => s.RoleId == info.Id).Select(s => s.MenuId).ToList();
            return new ListResultDto<RoleDto>(items);
        }

        public Task<ListResultDto<RoleDto>> GetAllByKey(string key, long orgId = 0)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIds(dynamic data)
        {
            throw new System.NotImplementedException();
        }
    }
}

