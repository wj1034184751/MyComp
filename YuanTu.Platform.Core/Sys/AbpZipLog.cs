using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.Sys
{
    public class AbpZipLog : CustomCreationEntityWithOrg<long>
    {
        /// <summary>
        /// 文件ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public string FileId { get; set; }

        /// <summary>
        /// ZIP文件路径
        /// </summary>
        [StringLength(PlatformConsts.MaxLength2048)]
        public string ZipPath { get; set; }
    }
}