using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    public class AbpTable : CustomEntityWithOrg<string>
    {
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Namespace { get; set; }
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string PkDataType { get; set; }

        public virtual bool IsParent { get; set; }

        public virtual bool IsDistinatOrg { get; set; }

        public virtual bool IsFullEdit { get; set; }

        /// <summary>
        /// 是否从表
        /// </summary>
        public virtual bool IsDetail { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }


        [StringLength(PlatformConsts.MaxLength36)]
        public string ParentId { get; set; }
    }
}
