using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Management.Dto;
using YuanTu.Platform.Management.Trigger.Dto;

namespace YuanTu.Platform.Management.Trigger
{
    public interface ITaskTriggerAppService : IAsynPermissionAppService<TaskTrigger, TaskTriggerDto, string, PagedTaskTriggerRequestDto, TaskTriggerDto, TaskTriggerDto>
    {
        Task<List<TaskTriggerDto>> GetTriggersByTask(string taskId);
    }
}
