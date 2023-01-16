using System;
using System.Collections.Generic;
using Abp.AutoMapper;
using Abp.Organizations;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Organizations.Dto
{
    [AutoMap(typeof(AbpOrg))]
    public class AbpOrgDto : ParentCustomEntityDto<long>
    {
        /// <summary>
        /// 机构名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 院区编号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 离线模式 1-离线 0-正常
        /// </summary>
        public int OfflineMode { get; set; } = 0;

        /// <summary>
        /// 对接模式 1-新网关模式 2-老网关模式  3-兼容模式
        /// </summary>
        public int DockMode { get; set; } = 3;

        /// <summary>
        /// 医联体通用模式（共用代码）0-否 1-是
        /// </summary>
        public int UnionMode { get; set; } = 1;

        /// <summary>
        /// 医联体ID
        /// </summary> 
        public string UnionId { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary> 
        public int HospitalId { get; set; } = 0;

        /// <summary>
        /// 监控医院编号
        /// </summary> 
        public int MonitorHospitalId { get; set; } = 0;

        /// <summary>
        /// 密钥
        /// </summary>
        public string OrgSecret { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 前置网关地址
        /// </summary> 
        public string GatewayUrl { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; } = 0;

        /// <summary>
        /// 省医保编码
        /// </summary> 
        public string ProvincialMiCode { get; set; }

        /// <summary>
        /// 市医保编码
        /// </summary> 
        public string MunicipalMiCode { get; set; }

        /// <summary>
        /// 终端管理平台后台服务地址
        /// </summary> 
        public string ServerUrl { get; set; }

        /// <summary>
        /// 监控平台地址
        /// </summary> 
        public string MonitorUrl { get; set; }

        /// <summary>
        /// 终端管理平台前端地址
        /// </summary> 
        public string FrontUrl { get; set; }

        /// <summary>
        /// 医保读卡模式
        /// </summary> 
        public int McReadMode { get; set; } = 0;

        /// <summary>
        /// 正则匹配规则
        /// </summary> 
        public string Pattern { get; set; }

        /// <summary>
        /// 维护人
        /// </summary> 
        public string Maintainer { get; set; }

        /// <summary>
        /// 终端版本
        /// </summary> 
        public string Version { get; set; }
    }
}
