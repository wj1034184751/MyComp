using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Management.Dto;
using YuanTu.Platform.Management.Trigger.Dto;

namespace YuanTu.Platform.Management.Trigger
{
    [AbpAuthorize]
    public class TaskTriggerAppService : AsynPermissionAppService<TaskTrigger, TaskTriggerDto, string, PagedTaskTriggerRequestDto, TaskTriggerDto, TaskTriggerDto>, ITaskTriggerAppService
    {
        private readonly IRepository<TaskTrigger, string> _repositoryTrigger;
        public TaskTriggerAppService(IRepository<TaskTrigger, string> repository)
            : base(repository)
        {
            _repositoryTrigger = repository;
        }

        public async Task<List<TaskTriggerDto>> GetTriggersByTask(string taskId)
        {
            return ObjectMapper.Map<List<TaskTriggerDto>>(await _repositoryTrigger.GetAllListAsync(s => s.TaskId.Equals(taskId)));

        }

    }
}
