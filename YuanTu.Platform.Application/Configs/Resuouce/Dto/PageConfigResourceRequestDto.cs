using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Configs.Resource.Dto
{
    public  class PageConfigResourceRequestDto : CustomPagedAndSortedDto
    {
        public long Id { get; set; }

        public string TerminalTypeId { get; set; }

        public string TypeName { get; set; }

        public string ResouceCode { get; set; }
    }

    public class ConfigResourceRequestDto
    {
        /// <summary>
        /// 资源类型Code
        /// </summary>
        public string ResourceCode { get; set; }

        /// <summary>
        /// 机型TypeId,传多个以,分隔
        /// </summary>
        public string TerminalTypeId { get; set; }

        /// <summary>
        /// 资源名称Code
        /// </summary>
        public string TypeCode { get; set; }

        /// <summary>
        /// 资源名称
        /// </summary>

        public string TypeName { get; set; }

      
    }
}
