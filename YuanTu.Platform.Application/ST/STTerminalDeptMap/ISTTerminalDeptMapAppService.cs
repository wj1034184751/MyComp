using System.Collections.Generic;
using System.Threading.Tasks;
using YuanTu.Platform.Dept.Dto;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    public interface ISTTerminalDeptMapAppService : IAsynPermissionAppService<STTerminalDeptMap, STTerminalDeptMapDto, string, PagedSTTerminalDeptMapRequestDto, STTerminalDeptMapDto, STTerminalDeptMapDto>
    {
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="infos"></param>
        /// <returns></returns>
        Task<bool> BatchAdd(List<STTerminalDeptMapDto> infos);

        /// <summary>
        /// 根据医院编号获取科室
        /// </summary>
        /// <param name="corpId"></param>
        /// <returns></returns>
        Task<List<AdDeptDto>> GetDepts(string corpId);
    }
}