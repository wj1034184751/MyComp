using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    public class PagedSTTerminalRequestDto : CustomPagedAndSortedWithOrgDto
    {
        public bool? IsActive { get; set; }
        public bool? IsPowerOn { get; set; }
        public bool? CanbeAccess { get; set; }
        public string TerminalType { get; set; } 
        public string WardAreaId { get; set; }
        /// <summary>
        /// 原始数据，不带配件，插件等信息 1-是 0-否
        /// </summary>
        public int Original { get; set; } 
        /// <summary>
        /// 0-不展示 1-展示
        /// </summary>
        public int ShowVersion { get; set; }
        public string PluginCode { get; set; }
    }
}