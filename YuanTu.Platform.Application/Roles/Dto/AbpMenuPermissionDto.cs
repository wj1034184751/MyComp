using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using YuanTu.Platform.Authorization.Menus; 

namespace YuanTu.Platform.Roles.Dto
{
    /// <summary>
    /// 菜单权限
    /// </summary>
    [AutoMapFrom(typeof(AbpMenuPermission))]
    public class AbpMenuPermissionDto : EntityDto<long>
    {
        /// <summary>
        /// 菜单ID
        /// </summary> 
        public string MenuId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary> 
        public int RoleId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long? UserId { get; set; }
    }
}