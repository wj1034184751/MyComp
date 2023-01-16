using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Management.Operation.Dto
{
    public class TaskOperationDto : EntityDto<string>
    {
        /// <summary>
        /// 操作
        /// </summary>
        public virtual string Operation { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 程序或脚本路径
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary> 
        public string FileExt { get; set; }

        /// <summary>
        /// 服务器路径
        /// </summary> 
        public string ServerPath { get; set; }

        /// <summary>
        /// 大小
        /// </summary> 
        public string FileSize { get; set; }

        /// <summary>
        /// 名称
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// 哈希码
        /// </summary> 
        public string HashCode { get; set; }

        /// <summary>
        /// 本地路径
        /// </summary> 
        public string LocalPath { get; set; }

        /// <summary>
        /// 参数(可选)
        /// </summary>
        public virtual string Params { get; set; }

        /// <summary>
        /// 起始于(可选)
        /// </summary>
        public virtual string StartFrom { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>

        public virtual string TaskId { get; set; }
    }
}
