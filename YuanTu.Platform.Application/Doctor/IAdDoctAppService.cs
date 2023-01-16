using YuanTu.Platform.Doctor.Dto;

namespace YuanTu.Platform.Doctor
{
    public interface IAdDoctAppService : IAsynPermissionAppService<AdDoct, AdDoctDto, long, PagedAdDoctRequestDto, AdDoctDto, AdDoctDto>
    { 
    }
}