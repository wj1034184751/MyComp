using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Medical.MedCheckExpDatas.Dto;

namespace YuanTu.Platform.Medical.MedCheckExpDatas
{
    public interface IMedCheckExpDataAppService : IAsynPermissionAppService<MedCheckExpData, MedCheckExpDataDto, string, MedCheckExpDataRequestDto, MedCheckExpDataDto, MedCheckExpDataDto>
    {
    }
}
