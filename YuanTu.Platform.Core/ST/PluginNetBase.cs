using System.ComponentModel.DataAnnotations;
using Abp.Dependency;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    public abstract class PluginNetBase : CustomCreationEntityWithOrg<string>, ITransientDependency
    { 
        /// <summary>
        /// 插件编号
        /// </summary> 
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PluginId { get; set; }
        /// <summary>
        /// 端口
        /// </summary> 
        public virtual int Port { get; set; }
        /// <summary>
        /// 网络类型：TCP /UDP /HTTP
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string NetType { get; set; }
    }
}