using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Management.Dto;

namespace YuanTu.Platform.Management
{
    public interface ITaskDetailAppService : IAsynPermissionAppService<TaskDetail, TaskDetailDto, string , PagedTaskDetailRequestDto, TaskDetailDto, TaskDetailDto>
    {
    }
}
