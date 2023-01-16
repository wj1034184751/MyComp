﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.Extensions;

namespace YuanTu.Platform.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public virtual long OrgId { get; set; }

        [StringLength(PlatformConsts.MaxLength2048)]
        public virtual string OrgIds { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
