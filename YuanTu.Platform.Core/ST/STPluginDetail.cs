using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    public class STPluginDetail : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 插件编号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PluginId { get; set; }

        /// <summary>
        /// 版本
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Version { get; set; } 

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }
    }
}