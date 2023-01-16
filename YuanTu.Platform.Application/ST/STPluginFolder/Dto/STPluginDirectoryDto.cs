using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace YuanTu.Platform.ST.Dto
{
    /// <summary>
    /// 文件目录
    /// </summary>
    public class STPluginDirectoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long FileSize { get; set; }
        public string Path { get; set; }
        public string HashCode { get; set; }
        public string FileId { get; set; }
        [JsonIgnore]
        public string ParentId { get; set; }
        public DateTime CreationTime { get; set; }

        public FolderType FolderType { get; set; } = FolderType.Child;

        public List<STPluginDirectoryDto> Children { get; set; } = new List<STPluginDirectoryDto>();
    }

    /// <summary>
    /// 文件夹类型
    /// </summary>
    public enum FolderType : byte
    {
        Parent = 1,
        Child = 2
    }
}