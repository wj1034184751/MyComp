using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.SN.Dto
{
    public class PagedSTNameplateRequestDto : CustomPagedAndSortedWithOrgDto
    {
        /// <summary>
        /// 原始数据，不带SN码值列表信息 1-是 0-否
        /// </summary>
        public int Original { get; set; }
    }

    public class PagedSTNameplateExRequestDto : PagedAndSortedResultRequestDto
    {
        public string HospitalCode { get; set; }
        public string HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string UnionId { get; set; }
    }
}