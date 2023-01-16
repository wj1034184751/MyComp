using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using YuanTu.Platform.Management.Dto;
using YuanTu.Platform.Management.Operation.Dto;
using YuanTu.Platform.Management.Trigger.Dto;
using System.IO;
using System.Xml;
using Abp.Json;
using Abp.UI;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.Management
{
    [AbpAuthorize]
    public class TaskAppService : AsynPermissionAppService<Task, TaskDto, string, PagedTaskRequestDto, TaskDto, TaskDto>, ITaskAppService
    {
        private readonly IRepository<Task, string> _repositoryTask;
        private readonly IRepository<TaskTrigger, string> _repositoryTrigger;
        private readonly IRepository<TaskOperation, string> _repositoryOperation;
        private readonly IRepository<TaskVsTerminal, string> _repositoryTerminal;
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;

        public TaskAppService(IRepository<Task, string> repository, IRepository<TaskTrigger, string> repositoryTrigger,
            IRepository<TaskOperation, string> repositoryOperation, IRepository<TaskVsTerminal, string> repositoryTerminal,
            IRepository<STTerminal, string> repositorySTTerminal)
            : base(repository)
        {
            _repositoryTask = repository;
            _repositoryTrigger = repositoryTrigger;
            _repositoryOperation = repositoryOperation;
            _repositoryTerminal = repositoryTerminal;
            _repositorySTTerminal = repositorySTTerminal;
        }


        [ActionName("GetPage")]
        public override async Task<PagedResultDto<TaskDto>> GetAllAsync(PagedTaskRequestDto input)
        {
            var list = await base.GetAllAsync(input);
            await GetDtos(list.Items);
            return list;
        }

        private async System.Threading.Tasks.Task GetDtos(IEnumerable<TaskDto> infos)
        {
            foreach (var info in infos)
            {
                info.Triggers =
                    ObjectMapper.Map<List<TaskTriggerDto>>(await _repositoryTrigger.GetAllListAsync(s => s.TaskId.Equals(info.Id)));

                info.Operations =
                    ObjectMapper.Map<List<TaskOperationDto>>(await _repositoryOperation.GetAllListAsync(s => s.TaskId.Equals(info.Id)));

                await GetTerminalByTask(info);
                    //ObjectMapper.Map<List<TaskVsTerminalDto>>(await _repositoryTerminal.GetAllListAsync(s => s.TaskId.Equals(info.Id)));

            }
        }

        public async System.Threading.Tasks.Task GetTerminalByTask(TaskDto info)
        {
            IList<TaskVsTerminalDto> terminals = (IList<TaskVsTerminalDto>)ObjectMapper.Map<List<TaskVsTerminalDto>>(await _repositoryTerminal.GetAllListAsync(s => s.TaskId.Equals(info.Id)));
            
            if (terminals!=null && terminals.Count > 0)
            {
                
                foreach (var terminal in terminals)
                {
                    terminal.StartPlan =( await _repositoryTrigger.GetAsync(terminal.TriggerId)).StartPlan;
                    terminal.Operation = (await _repositoryOperation.GetAsync(terminal.OperationId)).Operation;
                    terminal.Name = (await _repositorySTTerminal.GetAsync(terminal.TerminalId)).Name;

                }
            }
            info.Terminals = terminals;
            //info.Triggers = ObjectMapper.Map<TaskTriggerDto>(await _repositoryTrigger.GetAsync(info.TriggerId));
            //info.Operations = ObjectMapper.Map<TaskOperationDto>(await _repositoryOperation.GetAsync(info.OperationId));
            //info.Tasks = ObjectMapper.Map<TaskDto>(await _repositoryTask.GetAsync(info.TaskId));
            //return null;
        }
        public override async Task<TaskDto> CreateAsync(TaskDto input)
        {
            input.Id = new Guid().ToString();
            try
            {
                var model = ObjectMapper.Map<Task>(input);
                model.Id = input.Id = Guid.NewGuid().ToString();

                await AddTriggers(input, model);

                await AddOperations(input, model);

                await AddTaskTernimals(input, model);

                await Repository.InsertAsync(model);
                return input;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                return null;
            }
        }

        private async System.Threading.Tasks.Task AddTriggers(TaskDto input, Task model)
        {
            if (input.Triggers != null && input.Triggers.Count > 0)
            {
                foreach (var info in input.Triggers)
                {
                    if (info.Id == null)
                    {
                        info.Id = Guid.NewGuid().ToString();
                        info.TaskId = model.Id;
                        await _repositoryTrigger.InsertAsync(ObjectMapper.Map<TaskTrigger>(info));
                    }
                    else
                    {
                        await _repositoryTrigger.UpdateAsync(ObjectMapper.Map<TaskTrigger>(info));
                    }
                    
                }
            }
        }

        private async System.Threading.Tasks.Task AddOperations(TaskDto input, Task model)
        {
            if (input.Operations != null && input.Operations.Count > 0)
            {
                foreach (var info in input.Operations)
                {
                    if(info.Id == null)
                    {
                        info.Id = Guid.NewGuid().ToString();
                        info.TaskId = model.Id;
                        await _repositoryOperation.InsertAsync(ObjectMapper.Map<TaskOperation>(info));
                    }
                    else
                    {
                        await _repositoryOperation.UpdateAsync(ObjectMapper.Map<TaskOperation>(info));
                    }
                    
                }
            }
        }

        private async System.Threading.Tasks.Task AddTaskTernimals(TaskDto input, Task model)
        {
            if (input.Terminals != null && input.Terminals.Count > 0)
            {
                foreach (var info in input.Terminals)
                {
                    var terminalIds = info.TerminalId.Split(',').Where(x => !x.IsNullOrEmpty()).ToList();
                    if(terminalIds!=null && terminalIds.Count > 0)
                    {
                        foreach (var id in terminalIds)
                        {
                            if (info.Id == null)
                            {
                                TaskVsTerminal taskVs = new TaskVsTerminal() {TaskId=model.Id,TriggerId=info.TriggerId,OperationId=info.OperationId ,Id = Guid.NewGuid().ToString() ,TerminalId=id};
                                
                                await _repositoryTerminal.InsertAsync(taskVs);
                            }
                            else
                            {
                                TaskVsTerminal taskVs = new TaskVsTerminal() { TaskId = model.Id, TriggerId = info.TriggerId, OperationId = info.OperationId, Id = info.Id,TerminalId=id };
                                await _repositoryTerminal.UpdateAsync(ObjectMapper.Map<TaskVsTerminal>(info));
                            }
                        }
                    }
                   
                    
                }
            }
        }

        public override async Task<TaskDto> UpdateAsync(TaskDto input)
        {
            try
            {
                var model = await _repositoryTask.FirstOrDefaultAsync(s => s.Id.Equals(input.Id));
                MapToEntity(input, model);

                //await DeleteAllAsync(input.Id);

                await AddTriggers(input, model);
                await AddOperations(input, model);

                await AddTaskTernimals(input, model);

                await Repository.UpdateAsync(model);

                return MapToEntityDto(model);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                return null;
            }
        }

        private async System.Threading.Tasks.Task DeleteAllAsync(string id)
        {
            await _repositoryTrigger.DeleteAsync(s => s.TaskId.Equals(id));
            await _repositoryOperation.DeleteAsync(s => s.TaskId.Equals(id));
            await _repositoryTerminal.DeleteAsync(s => s.TaskId.Equals(id));
        }

        protected override IQueryable<Task> CreateFilteredQuery(PagedTaskRequestDto input)
        {
            var list = Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.TaskName.Contains(input.Keyword) || x.Description.Contains(input.Keyword));
            return list;
        }

        public async System.Threading.Tasks.Task BatchRunningAsync(dynamic data)
        {
            string ids = data.ids;
            string status = data.status;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");
            var arr = ids.Split(',');
            foreach (var id in arr)
            {
                var model = await Repository.GetAsync(id);
                model.Status = status;
                await Repository.UpdateAsync(model);
            }
        } 

        public async Task<string> ExportXmlAsync(dynamic data)
        {
            string ids = data.ids;
            string filePath = data.filePath;
            string  folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskResource");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string fileName ="data.json";
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");
            var arr = ids.Split(',');


            //XmlDocument xmlDocument = new XmlDocument();
            //XmlNode node = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", "");
            //xmlDocument.AppendChild(node);
            //XmlElement xeRoot = xmlDocument.CreateElement("Task");
            //xmlDocument.AppendChild(xeRoot);
            TaskDto task = new TaskDto();
            foreach (var id in arr)
            {
                var model = await Repository.GetAsync(id);
                fileName = model.TaskName + model.Id + ".json";
                task = MapToEntityDto(model);
                task.Triggers =
                    ObjectMapper.Map<List<TaskTriggerDto>>(await _repositoryTrigger.GetAllListAsync(s => s.TaskId.Equals(id)));

                task.Operations =
                    ObjectMapper.Map<List<TaskOperationDto>>(await _repositoryOperation.GetAllListAsync(s => s.TaskId.Equals(id)));

                //CreateNode(xmlDocument, xeRoot, "TaskName", task.TaskName);
                //CreateNode(xmlDocument, xeRoot, "Description", task.Description);
                //CreateNode(xmlDocument, xeRoot, "Status", task.Status);


                //XmlNode xn_root = xmlDocument.SelectSingleNode("Task");
                //if (xn_root != null)
                //{
                //    if (task.Triggers.Count > 0)
                //    {
                //        xeRoot = xmlDocument.CreateElement("Triggers");
                //        foreach (var item in task.Triggers)
                //        {
                //            XmlElement element = xmlDocument.CreateElement(item.StartPlan);
                //            CreateNode(xmlDocument, element, "StartTime", item.StartTime.ToString());
                //            CreateNode(xmlDocument, element, "TaskId", item.TaskId);
                //            CreateNode(xmlDocument, element, "Description", item.Description);
                //            CreateNode(xmlDocument, element, "IsDelay", item.IsDelay.ToString());
                //            CreateNode(xmlDocument, element, "Delay", item.Delay);
                //            CreateNode(xmlDocument, element, "IsRepeat", item.IsRepeat.ToString());
                //            CreateNode(xmlDocument, element, "RepeatInterval", item.RepeatInterval);
                //            CreateNode(xmlDocument, element, "RepeatLastTime", item.RepeatLastTime);
                //            CreateNode(xmlDocument, element, "Interval", item.Interval);
                //            CreateNode(xmlDocument, element, "IsActive", item.IsActive.ToString());
                //            CreateNode(xmlDocument, element, "Frequency", item.Frequency);
                //            CreateNode(xmlDocument, element, "DetailWeek", item.DetailWeek);
                //            CreateNode(xmlDocument, element, "DetailMonth", item.DetailMonth);
                //            CreateNode(xmlDocument, element, "DetailMonthDay", item.DetailMonthDay);
                //            CreateNode(xmlDocument, element, "ExpectTime", item.ExpectTime.ToString());
                //            CreateNode(xmlDocument, element, "RepeatLastTime", item.RepeatLastTime);
                //            CreateNode(xmlDocument, element, "PerUser", item.PerUser);
                //            xeRoot.AppendChild(element);
                //        }
                //        xn_root.AppendChild(xeRoot);
                //    }
                //    if (task.Operations.Count > 0)
                //    {
                //        xeRoot = xmlDocument.CreateElement("Operations");
                //        foreach (var item in task.Operations)
                //        {

                //            XmlElement element = xmlDocument.CreateElement(item.Operation);
                //            CreateNode(xmlDocument, element, "LocalPath", item.LocalPath);
                //            CreateNode(xmlDocument, element, "Params", item.Params);
                //            CreateNode(xmlDocument, element, "StartFrom", item.StartFrom);
                //            CreateNode(xmlDocument, element, "TaskId", item.TaskId);
                //            xeRoot.AppendChild(element);
                //        }
                //        xn_root.AppendChild(xeRoot);
                //    }
                //}
            }
            filePath = Path.Combine(folderPath, fileName);
            try
            {
                if (!File.Exists(filePath))
                {
                    //xmlDocument.Save(Path.Combine(filePath, fileName));
                    FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
                    file.Close();
                }
                //else
                //{
                //    FileStream file = File.Create(filePath);
                //    file.Close();
                //    xmlDocument.Save(filePath);
                //    return "文件已存在";
                //}
                
                File.WriteAllText(filePath, task.ToJsonString(true));
            }
            catch (Exception e)
            {                //显示错误信息    
                return e.Message;
            }
             
           
            return filePath;
        }

        public async Task<bool> InputXml(string path)
        {
            //string fileFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "taskResource");

            string jsonText = path.Substring(4,path.Length-12).Replace("\\","");
            var dto = jsonText.FromJsonString<TaskDto>();

            //TaskDto dtoTest = new TaskDto()
            //{
            //    CreationTime = DateTime.Now,
            //    Id = Guid.NewGuid().ToString(),
            //    Description = "测试",
            //    Triggers = new List<TaskTriggerDto>()
            //    {
            //        new TaskTriggerDto(){IsDelay =false,IsRepeat= false }
            //    },
            //    Operations = new List<TaskOperationDto>() 
            //    { 
            //        new TaskOperationDto{ Description="测试", LocalPath="D://"}
            //    }

            //};
            //var test = dtoTest.ToJsonString();



            //path = "D://陈//data2.xml";
            //List<TaskDto> dtos = new List<TaskDto>();
            //TaskDto dto = new TaskDto();
            //TaskTriggerDto taskTrigger = new TaskTriggerDto();
            //TaskOperationDto taskOperation = new TaskOperationDto();
            //XDocument document = XDocument.Load(path);

            ////获取到XML的根元素进行操作
            //XElement root = document.Root;//Task
            //XElement trigger = root.Element("Triggers");
            //XElement operation = root.Element("Operations");
            ////获取根元素下的所有子元素
            //IEnumerable<XElement> triggers = trigger.Elements();
            //foreach (XElement item in triggers)
            //{
            //    taskTrigger.StartPlan = item.Name.LocalName;
            //    taskTrigger.StartTime = Convert.ToDateTime(item.Elements().Where(x => x.Name.LocalName.Equals("StartTime")).FirstOrDefault().Value);
            //    taskTrigger.Description =  item.Elements().Where(x => x.Name.LocalName.Equals("Description")).FirstOrDefault().Value;
            //    taskTrigger.IsDelay = item.Elements().Where(x => x.Name.LocalName.Equals("IsDelay")).FirstOrDefault().Value.Equals("1")?true:false;
            //    taskTrigger.Delay = item.Elements().Where(x => x.Name.LocalName.Equals("Delay")).FirstOrDefault().Value;
            //    taskTrigger.IsRepeat = item.Elements().Where(x => x.Name.LocalName.Equals("IsRepeat")).FirstOrDefault().Value.Equals("1") ? true : false; ;
            //    taskTrigger.RepeatInterval = item.Elements().Where(x => x.Name.LocalName.Equals("RepeatInterval")).FirstOrDefault().Value;
            //    taskTrigger.RepeatLastTime = item.Elements().Where(x => x.Name.LocalName.Equals("RepeatLastTime")).FirstOrDefault().Value;
            //    taskTrigger.IsActive = item.Elements().Where(x => x.Name.LocalName.Equals("IsActive")).FirstOrDefault().Value.Equals("1") ? true : false; ;

            //    taskTrigger.Frequency = item.Elements().Where(x => x.Name.LocalName.Equals("Frequency")).FirstOrDefault().Value;
            //    taskTrigger.DetailWeek = item.Elements().Where(x => x.Name.LocalName.Equals("DetailWeek")).FirstOrDefault().Value;
            //    taskTrigger.DetailMonth = item.Elements().Where(x => x.Name.LocalName.Equals("DetailMonth")).FirstOrDefault().Value;
            //    taskTrigger.DetailMonthDay = item.Elements().Where(x => x.Name.LocalName.Equals("DetailMonthDay")).FirstOrDefault().Value;
            //    taskTrigger.ExpectTime = Convert.ToDateTime(item.Elements().Where(x => x.Name.LocalName.Equals("ExpectTime")).FirstOrDefault().Value);
            //    taskTrigger.RepeatLastTime = item.Elements().Where(x => x.Name.LocalName.Equals("RepeatLastTime")).FirstOrDefault().Value;

            //    taskTrigger.PerUser = item.Elements().Where(x => x.Name.LocalName.Equals("PerUser")).FirstOrDefault().Value;

            //}
            //IEnumerable<XElement> operations = operation.Elements();
            //foreach (XElement item in operations)
            //{
            //    taskOperation.Operation = item.Name.LocalName;
            //    taskOperation.LocalPath = item.Elements().Where(x => x.Name.LocalName.Equals("LocalPath")).FirstOrDefault().Value;
            //    taskOperation.Params = item.Elements().Where(x => x.Name.LocalName.Equals("Params")).FirstOrDefault().Value;
            //    taskOperation.StartFrom = item.Elements().Where(x => x.Name.LocalName.Equals("StartFrom")).FirstOrDefault().Value;
            //    taskOperation.TaskId = item.Elements().Where(x => x.Name.LocalName.Equals("TaskId")).FirstOrDefault().Value;
            //}

            await CreateAsync(dto);
            return true;
        }

         /// <summary>      
         /// 创建节点      
         /// </summary>      
         /// <param name="xmldoc"></param>  xml文档    
         /// <param name="parentnode"></param>父节点      
         /// <param name="name"></param>  节点名    
         /// <param name="value"></param>  节点值    
         ///     
         public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
         {
             XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
             node.InnerText = value;
             parentNode.AppendChild(node);
         }

       
       

    }
}
