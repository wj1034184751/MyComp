using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.RechargeBusinessOrder.Dto;
using YuanTu.Platform.RegBusinessOrder.Dto;

namespace YuanTu.Platform.AdOrder
{
    public interface IRechargeBusinessOrderAppService : IAsynPermissionAppService<AdRechargeBusinessOrder, RechargeBusinessOrderDto, string, PagedRechargeBusinessOrderRequestDto, RechargeBusinessOrderDto, RechargeBusinessOrderDto>
    {
    }
}