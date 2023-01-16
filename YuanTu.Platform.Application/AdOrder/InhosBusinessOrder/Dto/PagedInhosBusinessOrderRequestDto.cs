using Abp.Application.Services.Dto;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.InhosBusinessOrder.Dto
{
    public class PagedInhosBusinessOrderRequestDto : CustomPagedAndSortedDto
    {
        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string PatientName { get; set; }

        public string IdNo { get; set; }
        public string Phone { get; set; }

        public string DeviceNo { get; set; }

    }
}