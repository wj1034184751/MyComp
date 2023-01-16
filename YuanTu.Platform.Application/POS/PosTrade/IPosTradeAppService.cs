using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.POS.Dto; 

namespace YuanTu.Platform.POS
{
    public interface IPosTradeAppService : IAsynPermissionAppService<PosTrade, PosTradeDto, string, PagedPosTradeRequestDto, PosTradeDto, PosTradeDto>
    {
        /// <summary>
        /// 导出详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IActionResult> ExportAsync(dynamic data);
    }
}