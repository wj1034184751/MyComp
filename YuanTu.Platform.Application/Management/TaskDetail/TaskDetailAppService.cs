using Abp.Authorization;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Management.Dto;

namespace YuanTu.Platform.Management
{
    [AbpAuthorize]
    public class TaskDetailAppService : AsynPermissionAppService<TaskDetail, TaskDetailDto, string, PagedTaskDetailRequestDto, TaskDetailDto, TaskDetailDto>, ITaskDetailAppService
    {
        private readonly IRepository<TaskDetail, string> _repositoryTask;
        public TaskDetailAppService(IRepository<TaskDetail, string> repository)
            : base(repository)
        {
            _repositoryTask = repository;
        }

    }
}
