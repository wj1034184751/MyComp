using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.UC
{
    public class UCCatalog : CustomCreationEntityWithOrg<string>
    {
        /// <summary>
        /// 博客分类名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }
    }
}