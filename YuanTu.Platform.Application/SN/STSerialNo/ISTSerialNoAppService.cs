using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.SN.Dto;

namespace YuanTu.Platform.SN
{
    public interface ISTSerialNoAppService : IAsynPermissionAppService<STSerialNo, STSerialNoDto, string, PagedSTSerialNoRequestDto, STSerialNoDto, STSerialNoDto>
    {
        /// <summary>
        /// 修改状态 
        /// </summary> 
        /// <param name="data">
        ///包含以下字段：ids-id集合  status-状态 1-正常 0-作废
        /// </param>
        /// <returns></returns>
        Task<bool> UpdateStatus(dynamic data);

        /// <summary>
        /// 修改发货状态 
        /// </summary> 
        /// <param name="data">
        ///包含以下字段：type-设备类型  pid-铭牌项目编号  status-状态 1-已发货 0-未发货 sync-是否同步更新项目状态 1-更新
        /// </param>
        /// <returns></returns>
        Task<bool> UpdateDeliveryStatus(dynamic data);

        /// <summary>
        /// 修改机构 
        /// </summary> 
        /// <param name="data">
        ///包含以下字段：ids-铭牌项目编号集合  namepalteId-项目ID
        /// </param>
        /// <returns></returns>
        Task<bool> UpdateOrgId(dynamic data);
        /// <summary>
        /// 获取起始编号
        /// </summary>
        /// <returns></returns>
        Task<int> GetStartNum();

        /// <summary>
        /// 获取铭牌明细，供运营组调用
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<STSerialNoExDto>> GetSnDetails(PagedSTSerialNoExRequestDto input);
    }
}