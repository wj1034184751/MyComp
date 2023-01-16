using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.Local.Dto
{
    public class PrintTemplateBaseDto<T> : CustomCreationEntityWithOrgDto<T>
    {
        /// <summary>
        /// 附件
        /// </summary> 
        //public ICollection<AbpAttachmentDto> Attachments { get; set; }
    }
}
