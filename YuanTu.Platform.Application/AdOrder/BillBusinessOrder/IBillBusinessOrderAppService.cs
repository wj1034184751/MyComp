using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.BillBusinessOrder.Dto;
using YuanTu.Platform.RegBusinessOrder.Dto;

namespace YuanTu.Platform.AdOrder
{
    public interface IBillBusinessOrderAppService : IAsynPermissionAppService<AdBillBusinessOrder, BillBusinessOrderDto, string, PagedBillBusinessOrderRequestDto, BillBusinessOrderDto, BillBusinessOrderDto>
    {
    }
}