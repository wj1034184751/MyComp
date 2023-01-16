using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.RegBusinessOrder.Dto;
using YuanTu.Platform.SN.Dto;

namespace YuanTu.Platform.AdOrder
{
    public interface IRegBusinessOrderAppService : IAsynPermissionAppService<AdRegBusinessOrder, RegBusinessOrderDto, string, PagedRegBusinessOrderRequestDto, RegBusinessOrderDto, RegBusinessOrderDto>
    {
    }
}