using System.Collections.Generic;
using System.Threading.Tasks;
using YuanTu.Platform.AdOrder;
using YuanTu.Platform.Configs;
using YuanTu.Platform.Configs.Resource.Dto;

namespace YuanTu.Platform.Resource
{
    public interface IConfigResourceAppService : IAsynPermissionAppService<ConfigResource, ConfigResourceDto, string, PageConfigResourceRequestDto, ConfigResourceDto, ConfigResourceDto>
    {
    }
}
