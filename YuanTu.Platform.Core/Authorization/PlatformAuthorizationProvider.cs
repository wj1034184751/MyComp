using System.Collections.Generic;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.MultiTenancy;
using YuanTu.Platform.Authorization.Menus;

namespace YuanTu.Platform.Authorization
{
    public class PlatformAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            IRepository<AbpMenu, string> rep = IocManager.Instance.Resolve<IRepository<AbpMenu, string>>();

            List<AbpMenu> menus = rep.GetAllList();

            // 遍历所有菜单
            foreach (var menu in menus)
            {
                var permission = context.CreatePermission(menu.Code, L(menu.Name));

                // 添加基础功能权限
                permission.CreateChildPermission(menu.Code + ".Get", L(menu.Name + "查询"));

                permission.CreateChildPermission(menu.Code + ".GetAll", L(menu.Name + "查询全部"));

                if (menu.IsAddEnabled)
                {
                    permission.CreateChildPermission(menu.Code + ".Create", L(menu.Name + "新增"));
                }

                if (menu.IsEditEnabled)
                {
                    permission.CreateChildPermission(menu.Code + ".Update", L(menu.Name + "修改"));
                }

                if (menu.IsDeleteEnabled)
                {
                    permission.CreateChildPermission(menu.Code + ".Delete", L(menu.Name+"删除"));
                }

                if (menu.MenuFuncs != null)
                {
                    // 添加其他功能权限
                    foreach (var func in menu.MenuFuncs)
                    {
                        permission.CreateChildPermission(menu.Code + $".{func.Code}", L(func.Name));
                    }
                }
            }

            context.CreatePermission(PermissionNames.Pages_Users, L("Users")); 
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles")); 
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_AbpMenus, L("AbpMenus"));
            context.CreatePermission(PermissionNames.Pages_AbpCustomEnums, L("AbpCustomEnums"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformConsts.LocalizationSourceName);
        }
    }
}
