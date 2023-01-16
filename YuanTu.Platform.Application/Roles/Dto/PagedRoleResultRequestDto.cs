using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

