using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Sys.AbpAttachment.Dto;

namespace YuanTu.Platform.Sys.AbpAttachment
{
    /// <summary>
    /// 附件管理
    /// </summary>
    public interface IAbpAttachmentAppService : IAsynPermissionAppService<Platform.AbpAttachment, AbpAttachmentDto, string, PagedAbpAttachmentDto, AbpAttachmentDto, AbpAttachmentDto>
    {
        Task<ListResultDto<AbpAttachmentDto>> UploadFile();
        Task<ListResultDto<AbpAttachmentDto>> UploadFileById(string fid, string rid);

        Task<IActionResult> DownloadFile(AbpAttachmentDto input);

        Task<List<string>> DownloadZipFile(List<string> ids);
        Task<List<AbpAttachmentExDto>> Download(List<string> ids);
    }
}
