using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Local.Dto;

namespace YuanTu.Platform.Local
{
    public interface IPrintTemplateAppService : IAsynPermissionAppService<PrintTemplate, PrintTemplateDto, string, PagedPrintTemplateRequestDto, PrintTemplateDto, PrintTemplateDto>
    {
        /// <summary>
        /// 返回只有code和name的数据
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<PrintTemplateDto>> GetFilterListAsync(long? orgId);

        /// <summary>
        /// 导入
        /// </summary>
        /// <returns></returns>
        Task<bool> ImportTpl(long orgId);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IActionResult> ExportTpl(dynamic data);
    }
}
