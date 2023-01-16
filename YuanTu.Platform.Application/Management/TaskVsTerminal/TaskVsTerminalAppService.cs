using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Management.Dto;
using YuanTu.Platform.Management.Operation.Dto;
using YuanTu.Platform.Management.Trigger.Dto;
using YuanTu.Platform.ST;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.Management
{
    [AbpAuthorize]
    public class TaskVsTerminalAppService : AsynPermissionAppService<TaskVsTerminal, TaskVsTerminalDto, string, PagedTaskVsTerminalRequestDto, TaskVsTerminalDto, TaskVsTerminalDto>, ITaskVsTerminalAppService
    {
        private readonly IRepository<TaskVsTerminal, string> _repository;
        private readonly IRepository<Task, string> _repositoryTask;
        private readonly IRepository<TaskTrigger, string> _repositoryTrigger;
        private readonly IRepository<TaskOperation, string> _repositoryOperation;
        private readonly IRepository<STTerminal, string> _repositoryTerminal;
        public TaskVsTerminalAppService(IRepository<TaskVsTerminal, string> repository, IRepository<Task, string> repositoryTask, IRepository<TaskTrigger, string> repositoryTrigger, IRepository<TaskOperation, string> repositoryOperation, IRepository<STTerminal, string> repositoryTerminal)
            : base(repository)
        {
            _repository = repository;
            _repositoryTask = repositoryTask;
            _repositoryTrigger = repositoryTrigger;
            _repositoryOperation = repositoryOperation;
            _repositoryTerminal = repositoryTerminal;
    }

        [ActionName("GetPage")]
        public override async System.Threading.Tasks.Task<PagedResultDto<TaskVsTerminalDto>> GetAllAsync(PagedTaskVsTerminalRequestDto input)
        {
            var list = await base.GetAllAsync(input);
            await GetDtos(list.Items);
            return list;
        }

        private async System.Threading.Tasks.Task GetDtos(IEnumerable<TaskVsTerminalDto> infos)
        {
            foreach (var info in infos)
            {
                info.Triggers =ObjectMapper.Map<TaskTriggerDto>(await _repositoryTrigger.GetAsync(info.TriggerId));
                info.Operations = ObjectMapper.Map<TaskOperationDto>(await _repositoryOperation.GetAsync(info.OperationId));
                info.Tasks = ObjectMapper.Map<TaskDto>(await _repositoryTask.GetAsync(info.TaskId));

                //var terminalIds = info.TerminalId.Split(',').ToList();
                //if(terminalIds!=null&& terminalIds.Count > 0)
                //{
                //    foreach (var id in terminalIds)
                //    {
                //        info.Terminals.Add(ObjectMapper.Map<STTerminalDto>(await _repositoryTerminal.GetAsync(id)));
                //           await _repositoryTerminal.GetAsync(id);
                //    }
                //}
                info.Terminals = ObjectMapper.Map<STTerminalDto>(await _repositoryTerminal.GetAsync(info.TerminalId));

                info.TaskName = info.Tasks.TaskName;
                info.Status = info.Tasks.Status;
                info.StartPlan = info.Triggers.StartPlan;
                info.TriggerDescription = info.Triggers.Description;
                info.Operation = info.Operations.Operation;
                info.OperationDescription = info.Operations.Description;
                info.Name = info.Terminals.Name;
                info.Spec = info.Terminals.Spec;
                info.IP = info.Terminals.IP;
                info.TerminalTypeId = info.Terminals.TerminalTypeId;
                info.Code = info.Terminals.Code;

            }
        }

        public override Task<TaskVsTerminalDto> CreateAsync(TaskVsTerminalDto input)
        {
            return base.CreateAsync(input);

        }
    }
}
