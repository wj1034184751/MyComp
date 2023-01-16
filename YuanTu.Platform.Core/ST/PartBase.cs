using System.ComponentModel.DataAnnotations;
using Abp.Dependency;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    public abstract class PartBase : CustomCreationEntityWithOrg<string>, ITransientDependency
    { 
        /// <summary>
        /// 配件编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PartId { get; set; }
        /// <summary>
        /// 配件名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PartName { get; set; }
        /// <summary>
        /// 配件类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PartType { get; set; }
        /// <summary>
        /// JSON文本
        /// </summary> 
        public virtual string JsonText { get; set; } 
    }
}