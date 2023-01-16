using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform{
    
    
    /// <summary>
    /// 附件管理
    /// </summary>
    public class AbpAttachment : CustomCreationEntityWithOrg<string> {

        /// <summary>
        /// 文件扩展名
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string FileExt { get; set; }

        /// <summary>
        /// 服务器路径
        /// </summary>
        [StringLength(PlatformConsts.MaxLength1024)]
        public virtual string ServerPath { get; set; }

        /// <summary>
        /// 大小
        /// </summary> 
        public virtual long FileSize { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 哈希码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string HashCode { get; set; }

        /// <summary>
        /// 本地路径
        /// </summary>
        [StringLength(PlatformConsts.MaxLength1024)]
        public virtual string LocalPath { get; set; }

        /// <summary>
        /// 扩展ID，包括 配件、插件等编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ExtendId { get; set; } 
    }
}
