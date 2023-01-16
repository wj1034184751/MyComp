using System.Collections.Generic;
using YuanTu.Platform.Common;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STPluginFolder))]
    public class STPluginFolderDto : ParentCustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 文件夹名称
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// 关联文件ID
        /// </summary> 
        public string FileId { get; set; }

        /// <summary>
        /// 大小
        /// </summary> 
        public long FileSize { get; set; }

        /// <summary>
        /// 哈希码
        /// </summary> 
        public string HashCode { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary> 
        public string ExtendId { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary> 
        public string FilePath { get; set; }

        /// <summary>
        /// 子集
        /// </summary> 
        public ICollection<STPluginFolderDto> Children { get; set; }
    }
}