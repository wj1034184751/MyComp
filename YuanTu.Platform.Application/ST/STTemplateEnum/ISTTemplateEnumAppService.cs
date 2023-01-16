using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    public interface ISTTemplateEnumAppService : IAsynPermissionAppService<STTemplateEnum, STTemplateEnumDto, string, PagedSTTemplateEnumRequestDto, STTemplateEnumDto, STTemplateEnumDto>
    {

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