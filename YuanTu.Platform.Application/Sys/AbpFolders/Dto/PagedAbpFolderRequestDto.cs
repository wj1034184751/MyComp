using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Sys.AbpFolders.Dto
{
    public class PagedAbpFolderRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
