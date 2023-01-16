using System.Collections.Generic;

namespace YuanTu.Platform.ST.Dto
{
    public class STTerminalExDto
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; } = "none";
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  名称
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 程序路径
        /// </summary> 
        public string Path { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// 版本更新日志
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 网络端口类型
        /// </summary>
        public object Nets { get; set; }

        /// <summary>
        /// exe传入参数
        /// </summary> 
        public string Args { get; set; }

        /// <summary>
        /// 文件绝对路径
        /// </summary> 
        public string AbsolutePath { get; set; }

        /// <summary>
        /// 延迟时间(秒)
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// 固定启动时间(HH:mm:ss,例如：9:00:00)
        /// </summary> 
        public string FixedTime { get; set; }

        /// <summary>
        /// 是否守护
        /// </summary>
        public bool Protectable { get; set; }

        /// <summary>
        /// 是否模拟测试
        /// </summary>
        public bool IsMock { get; set; }

        public List<STPluginDirectoryDto> List { get; set; }

        //public List<STPluginDirectoryDto> PartFileList { get; set; }
    }
}