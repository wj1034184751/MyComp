using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.SN.Dto;

namespace YuanTu.Platform.SN
{
    public interface ISTNameplateAppService : IAsynPermissionAppService<STNameplate, STNameplateDto, string, PagedSTNameplateRequestDto, STNameplateDto, STNameplateDto>
    {
        /// <summary>
        /// 导出详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IActionResult> ExportAsync(dynamic data);
        /// <summary>
        /// 获取铭牌信息，供运营组调用
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<STNameplateExDto>> GetSns(PagedSTNameplateExRequestDto input);
    }
}