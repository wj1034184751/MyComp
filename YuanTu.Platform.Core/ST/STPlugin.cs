using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    public class STPlugin : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 插件类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PluginType { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }  
    }
}