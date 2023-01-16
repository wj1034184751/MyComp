using Abp.Application.Services.Dto;

namespace YuanTu.Platform.ST.Dto
{
    public class PagedSTPluginFolderRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
