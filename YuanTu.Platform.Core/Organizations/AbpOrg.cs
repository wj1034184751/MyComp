using System.ComponentModel.DataAnnotations; 

namespace YuanTu.Platform.Organizations
{ 
    public class AbpOrg: Abp.Organizations.OrganizationUnit
    {  
        /// <summary>
        /// 离线模式 1-离线 0-正常
        /// </summary>
        public virtual int OfflineMode { get; set; }

        /// <summary>
        /// 对接模式 1-新网关模式 2-老网关模式  3-兼容模式
        /// </summary>
        public virtual int DockMode { get; set; } = 1;

        /// <summary>
        /// 医联体通用模式（共用代码）0-否 1-是
        /// </summary>
        public virtual int UnionMode { get; set; }
         
        /// <summary>
        /// 医联体ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string UnionId { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary> 
        public virtual int HospitalId { get; set; }

        /// <summary>
        /// 监控医院编号
        /// </summary> 
        public virtual int MonitorHospitalId { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string OrgSecret { get; set; }

        /// <summary>
        /// 前置网关地址
        /// </summary>
        [StringLength(PlatformConsts.MaxLength512)]
        public virtual string GatewayUrl { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public virtual int Timeout { get; set; }

        /// <summary>
        /// 省医保编码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string ProvincialMiCode { get; set; }

        /// <summary>
        /// 市医保编码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength128)]
        public virtual string MunicipalMiCode { get; set; }

        /// <summary>
        /// 终端管理平台后台服务地址
        /// </summary>
        [StringLength(PlatformConsts.MaxLength512)]
        public virtual string ServerUrl { get; set; }

        /// <summary>
        /// 监控平台地址
        /// </summary>
        [StringLength(PlatformConsts.MaxLength512)]
        public virtual string MonitorUrl { get; set; }

        /// <summary>
        /// 终端管理平台前端地址
        /// </summary>
        [StringLength(PlatformConsts.MaxLength512)]
        public virtual string FrontUrl { get; set; }

        /// <summary>
        /// 医保读卡模式
        /// </summary> 
        public virtual int McReadMode { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Remark { get; set; }

        /// <summary>
        /// 正则匹配规则
        /// </summary>
        [StringLength(PlatformConsts.MaxLength512)]
        public virtual string Pattern { get; set; }

        /// <summary>
        /// 维护人
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Maintainer { get; set; }

        /// <summary>
        /// 终端版本
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string Version { get; set; } 
    }
}