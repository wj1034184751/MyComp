using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.InhosBusinessOrder.Dto;
using YuanTu.Platform.RegBusinessOrder.Dto;

namespace YuanTu.Platform.AdOrder
{
    public interface IInhosBusinessOrderAppService : IAsynPermissionAppService<AdInhosBusinessOrder, InhosBusinessOrderDto, string, PagedInhosBusinessOrderRequestDto, InhosBusinessOrderDto, InhosBusinessOrderDto>
    {
    }
}