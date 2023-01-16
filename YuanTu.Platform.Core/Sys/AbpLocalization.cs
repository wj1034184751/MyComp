using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    public class AbpLocalization : CustomEntityWithOrg<string>
    {
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string LocalizationTypeId { get; set; }
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string LocalizationCatalogId { get; set; }
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        public virtual int Sort { get; set; }
    }
}
