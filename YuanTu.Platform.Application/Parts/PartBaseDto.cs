using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.Parts
{
    public class PartBaseDto<T> : CustomCreationEntityWithOrgDto<T>
    {
        /// <summary>
        /// 附件
        /// </summary> 
        public  ICollection<AbpAttachmentDto> Attachments { get; set; }
    }
}