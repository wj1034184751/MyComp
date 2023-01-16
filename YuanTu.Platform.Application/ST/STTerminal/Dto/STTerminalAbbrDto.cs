using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTerminal))]
    public class STTerminalAbbrDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  名称
        /// </summary>
        public string Name { get; set; }
    }
}
