using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 消息文案目录
    /// </summary>
    public class STMsgCatalog : ParentCustomEditEntityWithOrg<string>
    {
        /// <summary>
        /// 前缀
        /// </summary>
        [Required]
        [StringLength(2)]
        public string Prefix { get; set; }

        /// <summary>
        /// 层级码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string LevelCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int Sort { get; set; }
    }
}
