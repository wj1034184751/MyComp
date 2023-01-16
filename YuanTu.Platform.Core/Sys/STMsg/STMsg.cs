using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 消息文案
    /// </summary>
    public class STMsg : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 目录Id
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength32)]
        public string STMsgCatalogId { get; set; }

        /// <summary>
        /// 码值
        /// </summary>
        [Required]
        [StringLength(8)]
        public string Code { get; set; }

        /// <summary>
        /// 报错原因
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string Reason { get; set; }

        /// <summary>
        /// 解决方案（简述）
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string Solution { get; set; }

        /// <summary>
        /// 参考链接
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string Link { get; set; }

        /// <summary>
        /// 绑定字段
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string Field { get; set; }

        /// <summary>
        /// 脚本内容
        /// </summary>
        [StringLength(PlatformConsts.MaxLength2048)]
        public string Script { get; set; }

        /// <summary>
        /// 语言包Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string STLanguageId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string STMsgType { get; set; }

        /// <summary>
        /// 倒计时
        /// </summary>
        public int Timeout { get; set; }
    }
}
