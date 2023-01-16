using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Roles.Dto;
using YuanTu.Platform.Users.Dto;

namespace YuanTu.Platform.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>,IAsynAppService<UserDto,long>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input); 
    }
}
