using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Management.Operation.Dto;

namespace YuanTu.Platform.Management.Operation
{
    public  interface ITaskOperationAppService : IAsynPermissionAppService<TaskOperation, TaskOperationDto, string, PagedTaskOperationRequestDto, TaskOperationDto, TaskOperationDto>
    {
        Task<List<TaskOperationDto>> GetOperationsByTask(string taskId);
    }
}
