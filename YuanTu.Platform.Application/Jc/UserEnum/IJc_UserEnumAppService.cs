using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Jc
{
    /// <summary>
    /// 药品信息接口
    /// </summary>
    public interface IJc_UserEnumAppService : IAsynPermissionAppService<Jc_UserEnum, Jc_UserEnumDto, string, Jc_UserEnum_CustomPagedAndSortedWithOrgDto, Jc_UserEnumDto, Jc_UserEnumDto>
    {
    }
}
