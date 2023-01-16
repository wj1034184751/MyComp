using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Management.Operation.Dto;
using YuanTu.Platform.Management.Trigger.Dto;

namespace YuanTu.Platform.Management.Operation
{
    [AbpAuthorize]
    public class TaskOperationAppService : AsynPermissionAppService<TaskOperation, TaskOperationDto, string, PagedTaskOperationRequestDto, TaskOperationDto, TaskOperationDto>, ITaskOperationAppService
    {
        
        private readonly IRepository<TaskOperation, string> _repositoryOperation;
        public TaskOperationAppService(IRepository<TaskOperation, string> repository, IHttpContextAccessor httpContextAccessor)
            : base(repository)
        {
            _repositoryOperation = repository;
        }
        public async Task<List<TaskOperationDto>> GetOperationsByTask(string taskId)
        {
            return ObjectMapper.Map<List<TaskOperationDto>>(await _repositoryOperation.GetAllListAsync(s => s.TaskId.Equals(taskId)));

        }
    }
}
