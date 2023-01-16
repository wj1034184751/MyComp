using YuanTu.Platform.UC.Dto;

namespace YuanTu.Platform.UC
{
    public interface IUCBlogAppService : IAsynPermissionAppService<UCBlog, UCBlogDto, string, PagedUCBlogRequestDto, UCBlogDto, UCBlogDto>
    { 
    }
}