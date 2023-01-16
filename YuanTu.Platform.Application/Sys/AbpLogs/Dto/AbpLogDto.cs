using System;
using YuanTu.Platform.Common.Dto; 
namespace YuanTu.Platform.Sys.AbpLogs.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AbpLog))]
    public class AbpLogDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Media Access Control Address
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        public string TerminalNo { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public string HospitalId { get; set; }

        /// <summary>
        /// 分院编号
        /// </summary>
        public string HospitalSubId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 分院名称
        /// </summary>
        public string HospitalSubName { get; set; }

        /// <summary>
        /// 追溯Id
        /// </summary>
        public string TraceId { get; set; }

        /// <summary>
        /// 父追溯Id
        /// </summary>
        public string ParentTraceId { get; set; }

        /// <summary>
        /// 业务名称
        /// </summary>
        public string BusinessName { get; set; }

        /// <summary>
        /// 子业务名称
        /// </summary>
        public string SubBusinessName { get; set; }

        /// <summary>
        /// 日志类型(Request, Response, Exception)
        /// </summary>
        public string LogType { get; set; }

        /// <summary>
        /// 日志分类(Pos Net Hardware MedIns)
        /// </summary>
        public string LogCatalog { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public virtual string Msg { get; set; }

        /// <summary>
        /// 代码位置
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 日志级别(Debug Info Warn Error Fatal)
        /// </summary>
        public string LogLevel { get; set; }

        /// <summary>
        /// 日志编码
        /// </summary>
        public string LogCode { get; set; }

        /// <summary>
        /// 当前线程号
        /// </summary>
        public string CurrentThreadId { get; set; }

        /// <summary>
        /// 业务服务访问地址
        /// </summary>
        public string BusinessServiceUrl { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        public string InterfaceName { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// 日志记录时间
        /// </summary>
        public DateTime RecordTime { get; set; }

        /// <summary>
        /// 错误等级
        /// </summary>
        public string ErrLevel { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 错误堆栈信息
        /// </summary>
        public string ErrStackTrace { get; set; }

        /// <summary>
        /// 执行时长（单位：毫秒）
        /// </summary>
        public int ExecutionTime { get; set; }
    }
}