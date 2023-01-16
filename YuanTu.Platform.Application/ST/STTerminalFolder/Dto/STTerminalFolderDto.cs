using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTerminalFolder))]
    public class STTerminalFolderDto : ParentCustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 文件夹名称
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary> 
        public string ExtendId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 终端列表
        /// </summary>
        public ICollection<STTerminalDto> Children { get; set; }
    }
}