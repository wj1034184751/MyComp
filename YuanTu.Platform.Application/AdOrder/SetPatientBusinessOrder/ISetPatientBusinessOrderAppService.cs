using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.SetPatientBusinessOrder.Dto;
using YuanTu.Platform.RegBusinessOrder.Dto;

namespace YuanTu.Platform.AdOrder
{
    public interface ISetPatientBusinessOrderAppService : IAsynPermissionAppService<AdSetPatientBusinessOrder, SetPatientBusinessOrderDto, string, PagedSetPatientBusinessOrderRequestDto, SetPatientBusinessOrderDto, SetPatientBusinessOrderDto>
    {
    }
}