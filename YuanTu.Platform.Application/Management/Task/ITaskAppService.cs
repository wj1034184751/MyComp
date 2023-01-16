using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Management.Dto;
using YuanTu.Platform.Management.Operation.Dto;
using YuanTu.Platform.Management.Trigger.Dto;

namespace YuanTu.Platform.Management
{
    public interface ITaskAppService : IAsynPermissionAppService<Task, TaskDto, string , PagedTaskRequestDto, TaskDto, TaskDto>
    {
        /// <summary>
        /// 批量修改状态
        /// </summary> 
        /// <param name="data">包含以下字段：ids  status</param>
        /// <returns></returns>
        System.Threading.Tasks.Task BatchRunningAsync(dynamic data);

        /// <summary>
        /// 导出为xml文件
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="data">包含以下字段：ids  filePath</param>
        /// <returns></returns>
        System.Threading.Tasks.Task<string> ExportXmlAsync(dynamic data);

        /// <summary>
        /// 导入xml文件
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        System.Threading.Tasks.Task<bool> InputXml(string path);


      

       
    }
}
