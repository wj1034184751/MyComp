using System.ComponentModel.DataAnnotations;
using Abp.Dependency;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    public abstract class PluginBase : CustomCreationEntityWithOrg<string>, ITransientDependency
    { 
        /// <summary>
        /// 插件编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PluginId { get; set; }
        /// <summary>
        /// 插件名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PluginName { get; set; }
        /// <summary>
        /// 插件代码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PluginCode { get; set; }
        /// <summary>
        /// 版本编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string VersionId { get; set; }
        /// <summary>
        /// 版本名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Version { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public virtual bool Enabled { get; set; }
        /// <summary>
        /// 程序路径
        /// </summary>
        [StringLength(PlatformConsts.MaxLength1024)]
        public virtual string Path { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Type { get; set; }

        /// <summary>
        /// 启动方式 1-延时启动 2-定时启动
        /// </summary>
        public virtual int StartMode { get; set; }

        /// <summary>
        /// 延迟时间(秒)
        /// </summary>
        public virtual int Delay { get; set; }

        /// <summary>
        /// 固定启动时间(HH:mm:ss,例如：9:00:00)
        /// </summary>
        [StringLength(PlatformConsts.MaxLength20)]
        public virtual string FixedTime { get; set; }

        /// <summary>
        /// 是否守护
        /// </summary>
        public virtual bool Protectable { get; set; }

        /// <summary>
        /// 是否模拟测试
        /// </summary>
        public virtual bool IsMock { get; set; }
    }
}