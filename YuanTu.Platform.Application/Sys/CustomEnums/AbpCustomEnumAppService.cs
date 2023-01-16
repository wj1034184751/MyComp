using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.Authorization.Users;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sessions.Dto;
using YuanTu.Platform.Sys.CustomEnums.Dto;

namespace YuanTu.Platform.Sys.CustomEnums
{
    [AbpAuthorize]
    public class AbpCustomEnumAppService : AsynPermissionAppService<AbpCustomEnum, AbpCustomEnumDto, string, CustomPagedAndSortedDto, CreateAbpCustomEnumDto, AbpCustomEnumDto>, IAbpCustomEnumAppService
    {
        IRepository<AbpTable, string> m_repTables = null;
        private readonly IRealTimeNotifier _notifier;
        private readonly UserManager _userManager;

        public AbpCustomEnumAppService(IRepository<AbpCustomEnum, string> repository, IRepository<AbpTable, string> repTables, IRealTimeNotifier notifier, UserManager userManager)
            : base(repository)
        {
            m_repTables = repTables;
            _notifier = notifier;
            _userManager = userManager;
        }

        public override async Task<AbpCustomEnumDto> CreateAsync(CreateAbpCustomEnumDto input)
        {
            var ret = await base.CreateAsync(input);

            await UpdateCache();

            return ret;
        }

        public override async Task<AbpCustomEnumDto> UpdateAsync(AbpCustomEnumDto input)
        {
            var ns = Repository.GetAll().FirstOrDefault(v => v.Code == "Namespace");

            foreach (var item in Repository.GetAll().Where(v => v.ParentId == input.Id))
            {
                item.ParentCode = input.Code;
            }

            // 判断是否命名空间数据
            if (ns != null && input.ParentId == ns.Id)
            {
                var tables = m_repTables.GetAll().Where(v => v.Namespace == Repository.GetAll().FirstOrDefault(c => c.Id == input.Id).Code);

                foreach (var table in tables)
                {
                    table.Namespace = input.Code;

                    m_repTables.Update(table);
                }
            }

            var ret = await base.UpdateAsync(input);

            await UpdateCache();

            return ret;
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            await base.DeleteAsync(input);
            await UpdateCache();
        }

        /// <summary>
        /// 更新缓存文件
        /// </summary>
        /// <returns></returns>
        private async Task UpdateCache()
        {
            var cache = await AppCacheHelper.UpdateCache(CacheType.Enum);
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
                Notification = new TenantNotification { NotificationName = "enums", Data = new MessageNotificationData(data) },
                UserId = s.Id
            }).ToArray();

            _notifier.SendNotificationsAsync(users);
        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<AbpCustomEnumDto>> GetAllAsync(CustomPagedAndSortedDto input)
        {
            input.MaxResultCount = int.MaxValue;
            input.Sorting = "Sort";

            return base.GetAllAsync(input);
        }

        [ActionName("GetAll"), AbpAllowAnonymous]
        public override async Task<ListResultDto<AbpCustomEnumDto>> GetAllListAsync()
        {
            var list = await base.GetAllListAsync();
            return new ListResultDto<AbpCustomEnumDto>(list.Items.OrderBy(s => s.Sort).ToList());
        }

        [AbpAllowAnonymous]
        public override Task<ListResultDto<AbpCustomEnumDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = this.Repository.GetAll().Where(v => v.ParentCode == key && v.OrgId == orgId).OrderBy(v => v.Sort).ToList();
            return Task.FromResult(new ListResultDto<AbpCustomEnumDto>(ObjectMapper.Map<List<AbpCustomEnumDto>>(list)));
        }

        [AbpAllowAnonymous]
        public Task<ListResultDto<AbpCustomEnumDto>> GetAllByParentId(string parentId)
        {
            var list = this.Repository.GetAll().Where(v => v.ParentId == parentId).OrderBy(v => v.Sort).ToList();
            return Task.FromResult(new ListResultDto<AbpCustomEnumDto>(ObjectMapper.Map<List<AbpCustomEnumDto>>(list)));
        }

        [AbpAllowAnonymous]
        public Task<AbpCustomEnumDto> GetRootByCode(string code)
        {
            var root = this.Repository.GetAll().Where(v => v.Code.ToLower() == code.ToLower() && string.IsNullOrEmpty(v.ParentId)).FirstOrDefault();

            if (root == null && code.ToLower() =="funcItems")
            {
                root = new AbpCustomEnum()
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Code = "funcItems",
                    Name = "功能项",
                    Sort = 99999,
                    ParentCode = "",
                    ParentId = "",
                    OrgId = 0
                };

                this.Repository.Insert(root);
            }

            return Task.FromResult(ObjectMapper.Map<AbpCustomEnumDto>(root));
        }
    }
}