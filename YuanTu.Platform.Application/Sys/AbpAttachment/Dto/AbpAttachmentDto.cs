using System.ComponentModel.DataAnnotations;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 附件管理
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(Platform.AbpAttachment))]
    public sealed class AbpAttachmentDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 文件扩展名
        /// </summary> 
        public string FileExt { get; set; }

        /// <summary>
        /// 服务器路径
        /// </summary> 
        public string ServerPath { get; set; }

        /// <summary>
        /// 大小
        /// </summary> 
        public string FileSize { get; set; }

        /// <summary>
        /// 名称
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// 哈希码
        /// </summary> 
        public string HashCode { get; set; }

        /// <summary>
        /// 本地路径
        /// </summary> 
        public string LocalPath { get; set; }

        /// <summary>
        /// 扩展ID ，包括 配件、插件等编号
        /// </summary>
        public string ExtendId { get; set; } 

        /// <summary>
        /// 完整路径
        /// </summary>
        public  string Url { get; set; }
    }
}
