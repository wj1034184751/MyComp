using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Roles.Dto;

namespace YuanTu.Platform.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedRoleResultRequestDto, CreateRoleDto, RoleDto>, IAsynAppService<RoleDto, int>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);

        Task<ListResultDto<RoleListDto>> GetRolesAsync(GetRolesInput input);
    }
}
