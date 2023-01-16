using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Union
{
    public class UnionRequestDto : PagedResultRequestDto
    {
        public string patientId { get; set; }

        public string cardNo { get; set; }
        
        public string platformNo { get; set; }

        public string patientName { get; set; }

        public string bankType { get; set; }

        public string Pid { get; set; }


    }
}
