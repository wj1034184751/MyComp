using YuanTu.Platform.Dept.Dto;

namespace YuanTu.Platform.Dept
{
    public interface IAdDeptAppService : IAsynPermissionAppService<AdDept, AdDeptDto, long, PagedAdDeptRequestDto, AdDeptDto, AdDeptDto>
    { 
    }
}