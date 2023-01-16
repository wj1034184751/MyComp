using YuanTu.Platform.Common;
using YuanTu.Platform.Common.Dto;
namespace YuanTu.Platform.Sys.AbpFolders.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(AbpFolder))]
    public class AbpFolderDto : ParentCustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 文件夹名称
        /// </summary> 
        public string Name { get; set; }

        /// <summary>
        /// 文件夹类型
        /// </summary> 
        public FolderEnum FolderType { get; set; } = FolderEnum.Terminal;

        /// <summary>
        /// 扩展字段
        /// </summary> 
        public string ExtendId { get; set; }
    }
}