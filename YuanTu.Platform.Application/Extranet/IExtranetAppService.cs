using System.Threading.Tasks;
using Abp.Application.Services;

namespace YuanTu.Platform.Extranet
{
    public interface IExtranetAppService : IApplicationService
    {
        /// <summary>
        /// 根据终端编号获取科室设置列表
        /// </summary>
        /// <param name="code">终端编号</param>
        /// <returns></returns>
        Task<ExtranetResult<object>> GetTerminalDepts(string code);

        /// <summary>
        /// 根据支付交易流水号更新发票号
        /// </summary>
        /// <param name="data">platformNo-支付交易流水号  invoiceNo-发票号</param>
        /// <returns></returns>
        Task<ExtranetResult<object>> UpdateInvoiceNo(dynamic data);
    }
}
