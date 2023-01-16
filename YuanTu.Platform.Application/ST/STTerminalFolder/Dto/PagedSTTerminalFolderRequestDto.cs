using Abp.Application.Services.Dto;

namespace YuanTu.Platform.ST.Dto
{
    public class PagedSTTerminalFolderRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
