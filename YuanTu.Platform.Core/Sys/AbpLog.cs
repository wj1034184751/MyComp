using System;
using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    public class AbpLog : CustomCreationEntityWithOrg<string>
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string IP { get; set; }

        /// <summary>
        /// Media Access Control Address
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Mac { get; set; }

        /// <summary>
        /// 终端号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string TerminalNo { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string HospitalId { get; set; }

        /// <summary>
        /// 分院编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string HospitalSubId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string HospitalName { get; set; }

        /// <summary>
        /// 分院名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string HospitalSubName { get; set; }

        /// <summary>
        /// 追溯Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string TraceId { get; set; }

        /// <summary>
        /// 父追溯Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string ParentTraceId { get; set; }

        /// <summary>
        /// 业务名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string BusinessName { get; set; }

        /// <summary>
        /// 子业务名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public virtual string SubBusinessName { get; set; }

        /// <summary>
        /// 日志类型(Request, Response, Exception)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string LogType { get; set; }

        /// <summary>
        /// 日志分类(Pos Net Hardware MedIns)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string LogCatalog { get; set; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public virtual string Msg { get; set; }

        /// <summary>
        /// 代码位置
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string Position { get; set; }

        /// <summary>
        /// 日志级别(Debug Info Warn Error Fatal)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string LogLevel { get; set; }

        /// <summary>
        /// 日志编码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength64)]
        public string SystemName { get; set; }

        /// <summary>
        /// 当前线程号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string CurrentThreadId { get; set; }

        /// <summary>
        /// 业务服务访问地址
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string BusinessServiceUrl { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Extend { get; set; }

        /// <summary>
        /// 接口名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string InterfaceName { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string ErrCode { get; set; }

        /// <summary>
        /// 日志记录时间
        /// </summary>
        public virtual DateTime RecordTime { get; set; }

        /// <summary>
        /// 错误等级
        /// </summary>
        [StringLength(8)]
        public virtual string ErrLevel { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [StringLength(PlatformConsts.MaxLength2048)]
        public virtual string ErrMsg { get; set; }

        /// <summary>
        /// 错误堆栈信息
        /// </summary>
        public virtual string ErrStackTrace { get; set; }

        /// <summary>
        /// 执行时长（单位：毫秒）
        /// </summary>
        public int ExecutionTime { get; set; }
    }
}