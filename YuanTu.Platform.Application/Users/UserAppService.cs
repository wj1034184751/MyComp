using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.UI;
using YuanTu.Platform.Authorization;
using YuanTu.Platform.Authorization.Accounts;
using YuanTu.Platform.Authorization.Roles;
using YuanTu.Platform.Authorization.Users;
using YuanTu.Platform.Roles.Dto;
using YuanTu.Platform.Users.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Authorization.Menus;

namespace YuanTu.Platform.Users
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly IRepository<Role> _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IAbpSession _abpSession;
        private readonly LogInManager _logInManager;
        private readonly IRepository<User, long> _repository;
        private readonly IRepository<UserLoginAttempt, long> _userLoginAttemptRepository;
        private readonly IRepository<AbpMenuPermission, long> _repositoryMenuPermission;

        public UserAppService(
            IRepository<User, long> repository,
            UserManager userManager,
            RoleManager roleManager,
            IRepository<Role> roleRepository,
            IPasswordHasher<User> passwordHasher,
            IAbpSession abpSession,
            LogInManager logInManager,
            IRepository<UserLoginAttempt, long> userLoginAttemptRepository,
            IRepository<AbpMenuPermission, long> repositoryMenuPermission)
            : base(repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
            _abpSession = abpSession;
            _logInManager = logInManager;
            _repository = repository;
            _userLoginAttemptRepository = userLoginAttemptRepository;
            _repositoryMenuPermission = repositoryMenuPermission;
        }

        public override async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.IsEmailConfirmed = true;

            await _userManager.InitializeOptionsAsync(AbpSession.TenantId);

            CheckErrors(await _userManager.CreateAsync(user, input.Password));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }

            CurrentUnitOfWork.SaveChanges();

            await AddMenuPermissions(user, input.MenuPermissions);

            return MapToEntityDto(user);
        }

        public override async Task<UserDto> UpdateAsync(UserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);
            user.ConcurrencyStamp = Guid.NewGuid().ToString();

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.RoleNames != null)
            {
                CheckErrors(await _userManager.SetRolesAsync(user, input.RoleNames));
            }

            await DeleteMenuPermissions(user);
            await AddMenuPermissions(user, input.MenuPermissions);

            return await GetAsync(input);
        }

        private async Task AddMenuPermissions(User user, List<string> menuPermissions)
        {
            foreach (var menuId in menuPermissions)
            {
                await _repositoryMenuPermission.InsertAsync(new AbpMenuPermission
                {
                    MenuId = menuId,
                    UserId = user.Id,
                    TenantId = AbpSession.TenantId
                });
            }
        }

        private async Task DeleteMenuPermissions(User user)
        {
            await _repositoryMenuPermission.DeleteAsync(s => s.UserId == user.Id);
        }

        public override async Task DeleteAsync(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);

            await DeleteMenuPermissions(user);
        }

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }

        public async Task ChangeLanguage(ChangeUserLanguageDto input)
        {
            await SettingManager.ChangeSettingForUserAsync(
                AbpSession.ToUserIdentifier(),
                LocalizationSettingNames.DefaultLanguage,
                input.LanguageName
            );
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<UserDto>> GetAllAsync(PagedUserResultRequestDto input)
        {
            var dtos = await base.GetAllAsync(input);
            var ids = dtos.Items.Select(s => s.Id).ToList();
            var list = _userLoginAttemptRepository.GetAll(); 
            var infos = list
                .Where(s => s.UserId > 0 && s.Result == AbpLoginResultType.Success && s.CreationTime ==
                    list.Where(t =>
                            t.UserId > 0 && t.UserId == s.UserId && t.Result == AbpLoginResultType.Success &&
                            ids.Contains((long)t.UserId))
                        .Max(t => t.CreationTime)).Select(s => new { s.UserId, s.CreationTime, s.ClientIpAddress })
                .ToList();
            foreach (var dto in dtos.Items)
            {
                var login = infos.Find(s => s.UserId == dto.Id);
                dto.LastLoginTime = login?.CreationTime;
                dto.ClientIpAddress = login?.ClientIpAddress;
            }

            await GetDtos(dtos);

            return dtos;
        }

        private async Task GetDtos(PagedResultDto<UserDto> dto)
        {
            var menus = await _repositoryMenuPermission.GetAllListAsync(s => s.UserId > 0);
            foreach (var item in dto.Items)
            {
                item.MenuPermissions = menus.Where(s => s.UserId == item.Id).Select(s => s.MenuId).ToList();
            }
        }

        [ActionName("GetAll")]
        public async Task<ListResultDto<UserDto>> GetAllListAsync()
        {
            var list = await _repository.GetAllListAsync();
            return new ListResultDto<UserDto>(ObjectMapper.Map<List<UserDto>>(list));
        }

        public Task<ListResultDto<UserDto>> GetAllByKey(string key, long orgId = 0)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIds(dynamic ids)
        {
            throw new System.NotImplementedException();
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            user.SetNormalizedNames();
            return user;
        }

        protected override void MapToEntity(UserDto input, User user)
        {
            ObjectMapper.Map(input, user);
            user.SetNormalizedNames();
        }

        protected override UserDto MapToEntityDto(User user)
        {
            var roleIds = user.Roles.Select(x => x.RoleId).ToArray();

            var roles = _roleManager.Roles.Where(r => roleIds.Contains(r.Id)).Select(r => r.NormalizedName);

            var userDto = base.MapToEntityDto(user);
            userDto.RoleNames = roles.ToArray();

            return userDto;
        }

        protected override IQueryable<User> CreateFilteredQuery(PagedUserResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Roles)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.UserName.Contains(input.Keyword) || x.Name.Contains(input.Keyword) || x.EmailAddress.Contains(input.Keyword))
                .WhereIf(input.IsActive.HasValue, x => x.IsActive == input.IsActive);
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            var user = await Repository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User), id);
            }

            return user;
        }

        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedUserResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        public async Task<bool> ChangePassword(ChangePasswordDto input)
        {
            if (_abpSession.UserId == null)
            {
                throw new UserFriendlyException("请先登录，然后再尝试更改密码。");
            }
            long userId = _abpSession.UserId.Value;
            var user = await _userManager.GetUserByIdAsync(userId);
            var loginAsync = await _logInManager.LoginAsync(user.UserName, input.CurrentPassword, shouldLockout: false);
            if (loginAsync.Result != AbpLoginResultType.Success)
            {
                throw new UserFriendlyException("您的“现有密码”与记录中的密码不匹配。请重试或与管理员联系以获得重置密码的帮助。");
            }
            if (!new Regex(AccountAppService.PasswordRegex).IsMatch(input.NewPassword))
            {
                throw new UserFriendlyException("密码必须至少包含8个字符，包含小写、大写和数字。");
            }
            user.Password = _passwordHasher.HashPassword(user, input.NewPassword);
            CurrentUnitOfWork.SaveChanges();
            return true;
        }

        public async Task<bool> ResetPassword(ResetPasswordDto input)
        {
            if (_abpSession.UserId == null)
            {
                throw new UserFriendlyException("请在尝试重置密码之前登录。");
            }
            long currentUserId = _abpSession.UserId.Value;
            var currentUser = await _userManager.GetUserByIdAsync(currentUserId);
            var loginAsync = await _logInManager.LoginAsync(currentUser.UserName, input.AdminPassword, shouldLockout: false);
            if (loginAsync.Result != AbpLoginResultType.Success)
            {
                throw new UserFriendlyException("您的“管理员密码”与记录中的密码不匹配。请再试一次。");
            }
            if (currentUser.IsDeleted || !currentUser.IsActive)
            {
                return false;
            }
            var roles = await _userManager.GetRolesAsync(currentUser);
            if (!roles.Contains(StaticRoleNames.Tenants.Admin))
            {
                throw new UserFriendlyException("只有管理员可以重置密码。");
            }

            var user = await _userManager.GetUserByIdAsync(input.UserId);
            if (user != null)
            {
                user.Password = _passwordHasher.HashPassword(user, input.NewPassword);
                CurrentUnitOfWork.SaveChanges();
            }

            return true;
        }
    }
}

