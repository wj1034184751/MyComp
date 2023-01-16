using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Notifications;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YuanTu.Platform.Authorization.Menus.Dto;
using YuanTu.Platform.Authorization.Users;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Extentions;
using YuanTu.Platform.Sessions.Dto;

namespace YuanTu.Platform.Authorization.Menus
{
    public class AbpMenuAppService : AsynPermissionAppService<AbpMenu, AbpMenuDto, string, CustomPagedAndSortedDto, AbpMenuDto, AbpMenuDto>, IAbpMenuAppService
    {
        private readonly IRealTimeNotifier _notifier;
        private readonly UserManager _userManager;
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IRepository<AbpMenuPermission, long> _mpRepository;

        public AbpMenuAppService(IRepository<AbpMenu, string> repository, IRealTimeNotifier notifier, UserManager userManager, IRepository<UserRole, long> userRoleRepository, IRepository<AbpMenuPermission, long> mpRepository)
            : base(repository)
        {
            _notifier = notifier;
            _userManager = userManager;
            _userRoleRepository = userRoleRepository;
            _mpRepository = mpRepository;
        }

        public override async Task<AbpMenuDto> CreateAsync(AbpMenuDto input)
        {
            var ret = await base.CreateAsync(input);

            await UpdateCache();

            return ret;
        }

        public override async Task<AbpMenuDto> UpdateAsync(AbpMenuDto input)
        {
            var ret = await base.UpdateAsync(input);

            await UpdateCache();

            return ret;
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            await _mpRepository.DeleteAsync(s => s.MenuId.Equals(input.Id));
            await base.DeleteAsync(input);
            await UpdateCache();
        }

        /// <summary>
        /// 更新缓存文件
        /// </summary>
        /// <returns></returns>
        private async Task UpdateCache()
        {
            var cache = await AppCacheHelper.UpdateCache(CacheType.Menu);
            // 发送实时通知，通知前端更新缓存
            SendNotifications(cache);
        }

        /// <summary>
        /// 发送实时通知，通知前端更新缓存
        /// </summary>
        private void SendNotifications(string data)
        {
            var users = _userManager.Users.Select(s => new UserNotification()
            {
                Id = Guid.NewGuid(),
                Notification = new TenantNotification { NotificationName = "menus", Data = new MessageNotificationData(data) },
                UserId = s.Id
            }).ToArray();

            _notifier.SendNotificationsAsync(users);
        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<AbpMenuDto>> GetAllAsync(CustomPagedAndSortedDto input)
        {
            input.MaxResultCount = int.MaxValue;
            input.Sorting = "Sort";

            return base.GetAllAsync(input);
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<AbpMenuDto>> GetAllListAsync()
        {
            var list = await base.GetAllListAsync();
            return new ListResultDto<AbpMenuDto>(list.Items.OrderBy(s => s.Sort).ToList());
        }

        public async Task<ListResultDto<AbpMenuDto>> GetAllByUserIdAsync(int uid)
        {
            /*var ids = _mpRepository.GetAll().Where(s => s.UserId == uid).Select(s => s.MenuId).ToList();
       var result = await GetListResult(ids);
       if (result != null) return result;

       var roles =  _userRoleRepository.GetAll().Where(s => s.UserId == uid).Select(s => s.RoleId).ToList();
       if (!roles.Any()) return new ListResultDto<AbpMenuDto>();

       ids =  _mpRepository.GetAll().Where(s => roles.Contains(s.RoleId)).Select(s => s.MenuId).ToList();
       result = await GetListResult(ids);

         return result ?? await GetAllListAsync();
        */

            var roles = _userRoleRepository.GetAll().Where(s => s.UserId == uid).Select(s => s.RoleId).ToList();
            var ids = _mpRepository.GetAll().Where(s => s.UserId == uid || roles.Contains(s.RoleId)).Select(s => s.MenuId).Distinct().ToList();
            var result = await GetListResult(ids);

            return result ?? new ListResultDto<AbpMenuDto>();
        }

        private async Task<ListResultDto<AbpMenuDto>> GetListResult(IEnumerable<string> ids)
        {
            if (!ids.Any()) return null;

            var result = new List<AbpMenu>();
            var all = await Repository.GetAllListAsync();
            GetParent(all, result, ids);

            return new ListResultDto<AbpMenuDto>(ObjectMapper.Map<List<AbpMenuDto>>(result.Distinct().OrderBy(s => s.Sort)));
        }

        private void GetParent(IEnumerable<AbpMenu> all, List<AbpMenu> result, IEnumerable<string> ids)
        {
            if (!ids.Any()) return;
            var items = all.Where(s => ids.Contains(s.Id)).OrderBy(s => s.Sort);
            result.AddRange(items);
            if (items.Count() == all.Count()) return;
            var p = items.Where(s => !string.IsNullOrWhiteSpace(s.ParentId)).DistinctBy(s => s.ParentId).Select(s => s.ParentId);
            GetParent(all, result, p);
        }
    }
}
