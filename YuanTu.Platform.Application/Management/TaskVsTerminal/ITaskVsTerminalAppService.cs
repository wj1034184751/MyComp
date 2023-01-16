using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Management.Dto;

namespace YuanTu.Platform.Management
{
    public interface ITaskVsTerminalAppService : IAsynPermissionAppService<TaskVsTerminal, TaskVsTerminalDto, string, PagedTaskVsTerminalRequestDto, TaskVsTerminalDto, TaskVsTerminalDto>
    {
    }
}
