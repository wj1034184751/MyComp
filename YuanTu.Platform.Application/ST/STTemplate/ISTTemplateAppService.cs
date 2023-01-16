using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    public interface ISTTemplateAppService : IAsynPermissionAppService<STTemplate, STTemplateDto, string, PagedSTTemplateRequestDto, STTemplateDto, STTemplateDto>
    {
        Task<ListResultDto<STTemplateDto>> GetAllByTypeAsync(int type, long orgId, string pluginCode);
        Task<bool> ExistCode(string code);
        Task<ListResultDto<STTemplateDto>> GetAllByOrgIdAsync(long orgId);
    }
}