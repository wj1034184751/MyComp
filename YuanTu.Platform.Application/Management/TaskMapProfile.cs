using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Management.Dto;
using YuanTu.Platform.Management.Operation.Dto;
using YuanTu.Platform.Management.Trigger.Dto;

namespace YuanTu.Platform.Management.Dto
{
    public class TaskMapProfile:Profile
    {
        public TaskMapProfile()
        {
            CreateMap<TaskDto, Task>();
            CreateMap<Task, TaskDto>();


            CreateMap<TaskTriggerDto, TaskTrigger>();
            CreateMap<TaskTrigger, TaskTriggerDto>();

            CreateMap<TaskOperationDto, TaskOperation>();
            CreateMap<TaskOperation, TaskOperationDto>();

            CreateMap<TaskVsTerminal, TaskVsTerminalDto>();
            CreateMap<TaskVsTerminalDto, TaskVsTerminal>();
        }
    }
}
