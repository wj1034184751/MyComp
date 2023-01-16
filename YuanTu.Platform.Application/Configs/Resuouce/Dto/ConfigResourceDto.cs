using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.AdOrder;
using Abp.Application.Services.Dto;
using Abp.Extensions;

namespace YuanTu.Platform.Configs.Resource.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(ConfigResource))]
    public class ConfigResourceDto : EntityDto<string>
    {
        public string ResourceCode { get; set; }

        public string TerminalTypeId { get; set; }

        public string TypeCode { get; set; }

        public List<string> TerminalCodes { get; set; }

        public string TypeName { get; set; }

        public string HashCode { get; set; }

        public string ResourceUrl { get; set; }

        public int Status { get; set; }

        public DateTime CteateTime { get; set; }

        public DateTime ModifyTime { get; set; }

        public string ResourceCodeStr { get; set; }

        public string TerminalCodeStr { get; set; }

        public string TerminalCodesStr { get; set; }

        public string code
        {
            get
            {
                if (!TypeCode.IsNullOrWhiteSpace())
                {
                    var endIndex = this.TypeCode.LastIndexOf(".");
                    var codeLength = this.TypeCode.Length - endIndex - 1;
                    var code = this.TypeCode.Substring(endIndex + 1, codeLength);
                    return code;
                }

                return string.Empty;
            }
        }

        public string prefixCode
        {
            get
            {
                if (!TypeCode.IsNullOrWhiteSpace())
                {
                    var endIndex = this.TypeCode.LastIndexOf(".");
                    var codeLength = this.TypeCode.Length - endIndex - 1;
                    var prefixCode = TypeCode.Substring(0, TypeCode.Length - codeLength - 1);
                    return prefixCode;
                }

                return string.Empty;
            }
        }

        public bool IsVideo
        {
            get
            {
                if (this.abpAttachment != null && !string.IsNullOrWhiteSpace(this.abpAttachment.FileExt))
                {
                    if (this.abpAttachment.FileExt.Contains(".mp4"))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public bool IsDeleted { get; set; }

        public AbpAttachment abpAttachment { get; set; } = new AbpAttachment();
    }
}
