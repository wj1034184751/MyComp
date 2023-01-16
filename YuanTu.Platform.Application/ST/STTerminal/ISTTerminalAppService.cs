using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Dept.Dto;
using YuanTu.Platform.ST.Dto;
using YuanTu.Platform.Sys.Dto;

namespace YuanTu.Platform.ST
{
    public interface ISTTerminalAppService : IAsynPermissionAppService<STTerminal, STTerminalDto, string, PagedSTTerminalRequestDto, STTerminalDto, STTerminalDto>
    {
        /// <summary>
        /// 获取简要的不带插件、配件等信息，Id/Code/Name/IP
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<object>> GetSimpleListAsync();
        /// <summary>
        /// 根据主板序列号获取终端
        /// </summary>
        /// <param name="bid">主板序列号</param>
        /// <returns></returns>
        Task<STTerminalDto> GetByBIdAsync(string bid);

        /// <summary>
        /// 导入模板
        /// </summary> 
        /// <param name="data">包含以下字段：ids  templateId type:1-part 2-plugin</param>
        /// <returns></returns>
        Task<bool> ImportTemplateAsync(dynamic data);

        /// <summary>
        /// 导入预检设备配置
        /// </summary> 
        /// <param name="data">包含以下字段：ids  configId</param>
        /// <returns></returns>
        Task<bool> ImportHealthConfigAsync(dynamic data);
        /// <summary>
        /// 导入声音模板
        /// </summary> 
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> ImportVoiceAsync(STTerminalVoiceDto input);

        /// <summary>
        /// 导入自定义字典模板
        /// </summary> 
        /// <param name="data">包含以下字段：ids  templateId type</param>
        /// <returns></returns>
        Task<bool> ImportEnumTemplateAsync(dynamic data);

        /// <summary>
        /// 导出终端自定义字典模板
        /// </summary> 
        /// <param name="data">包含以下字段：tid  templateId</param>
        /// <returns></returns>
        Task<bool> ExportEnumAsync(dynamic data);

        /// <summary>
        /// 导入钱箱币值
        /// </summary> 
        /// <param name="data">包含以下字段：ids  cashType</param>
        /// <returns></returns>
        Task<bool> ImportCashTypeAsync(dynamic data);

        /// <summary>
        /// 批量激活
        /// </summary> 
        /// <param name="data">包含以下字段：ids  status</param>
        /// <returns></returns>
        Task<bool> BatchActiveAsync(dynamic data);
        /// <summary>
        /// 获取插件文件列表
        /// </summary>
        /// <param name="bid">主板序列号</param>
        /// <returns></returns>
        Task<List<STTerminalExDto>> GetPluginFileList(string bid);
        /// <summary>
        /// 获取配件文件列表
        /// </summary>
        /// <param name="bid">主板序列号</param>
        /// <returns></returns>
        Task<List<STTerminalPartDto>> GetPartFileList(string bid);
        /// <summary>
        /// 获取终端硬件配置列表
        /// </summary>
        /// <param name="bid">主板序列号</param>
        /// <returns></returns>
        Task<STHardwareInfoDto> GetHardwareInfo(string bid);
        /// <summary>
        /// 获取预检设备配置
        /// </summary>
        /// <param name="code">终端编号</param>
        /// <returns></returns>
        Task<string> GetHealthConfig(string code);
        /// <summary>
        /// 获取设备在线状态
        /// </summary>
        /// <param name="bid">主板序列号</param>
        /// <returns></returns>
        Task<bool> GetPowerOnAsync(string bid);
        /// <summary>
        /// 更新设备在线/离线状态
        /// </summary>
        /// <param name="data">入参</param>
        /// <returns></returns>
        Task<bool> UpdatePowerOn(STStatusDto data);
        /// <summary>
        /// 更新设备程序更新状态
        /// </summary>
        /// <param name="data">入参</param>
        /// <returns></returns>
        Task<bool> UpdateStatus(STUpdateStatusDto data);
        /// <summary>
        /// 更新配件状态和消息
        /// </summary>
        /// <param name="id">配件关联表ID</param>
        /// <param name="status">状态</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        Task<bool> UpdatePartStatus(string id, int status, string message);

        /// <summary>
        /// 检测是否存在指定终端编号数据
        /// </summary>
        /// <param name="code">终端编号</param>
        /// <param name="orgId">机构编号</param>
        /// <returns></returns>
        Task<bool> ExistCode(string code, long orgId);
        /// <summary>
        /// 获取终端自定义枚举
        /// </summary>
        /// <param name="bid">主板序列号</param>
        /// <returns></returns>
        Task<PagedResultDto<STTerminalCustomEnumDto>> GetTerminalEnums(string bid);
        /// <summary>
        /// 导出详情
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<IActionResult> ExportAsync(dynamic data);
    }
}