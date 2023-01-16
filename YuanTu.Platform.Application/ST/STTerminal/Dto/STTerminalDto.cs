using System;
using System.Collections.Generic;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Health.Dto;
using YuanTu.Platform.Sys.Dto;

namespace YuanTu.Platform.ST.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STTerminal))]
    public class STTerminalDto : CustomCreationEntityWithOrgDto<string>
    {
        /// <summary>
        /// 编号号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 终端名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string Spec { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string TerminalTypeId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 建筑Id
        /// </summary>
        public string BuildingId { get; set; }

        /// <summary>
        /// 所在楼层
        /// </summary>
        public string FloorId { get; set; }

        /// <summary>
        /// 点位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 所在坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// 所在坐标
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 所在坐标
        /// </summary>
        public int Z { get; set; }

        /// <summary>
        /// 硬盘序列号
        /// </summary>
        public string HID { get; set; }

        /// <summary>
        /// 网卡序列号
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        public bool IsPowerOn { get; set; }

        /// <summary>
        /// 是否已更新
        /// </summary>
        public bool IsUpdated { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 模板编号
        /// </summary>
        public string TemplateId { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public string HospitalId { get; set; }

        #region 设备证书

        /// <summary>
        /// 产品序列号
        /// </summary>
        public string ProductKey { get; set; }

        /// <summary>
        /// 设备密钥
        /// </summary>
        public string DeviceSecret { get; set; }

        #endregion

        /// <summary>
        /// 配件列表
        /// </summary>
        public IList<STTerminalPartDto> Parts { get; set; }

        /// <summary>
        /// 插件件列表
        /// </summary>
        public IList<STTerminalPluginDto> Plugins { get; set; }

        /// <summary>
        /// 文件夹ID
        /// </summary> 
        public string FolderId { get; set; }

        /// <summary>
        /// 病区ID
        /// </summary> 
        public string WardAreaId { get; set; }

        public AbpWardAreaDto WardArea { get; set; }

        /// <summary>
        /// 院区编号
        /// </summary> 
        public string HospitalCode { get; set; }

        /// <summary>
        /// 签到时间
        /// </summary>
        public DateTime SignDate { get; set; }

        /// <summary>
        /// 网关模板编号
        /// </summary> 
        public int GatewayTemplateId { get; set; }

        /// <summary>
        /// 网关模板名称
        /// </summary> 
        public string GatewayTemplateName { get; set; }

        /// <summary>
        /// 预检设备功能配置编号
        /// </summary>
        public string HealthConfigId { get; set; }

        public HealthConfigDto HealthConfig { get; set; }

        /// <summary>
        /// 准入
        /// </summary>
        public bool CanbeAccess { get; set; }

        /// <summary>
        /// 运行模式
        /// </summary>
        public int RunMode { get; set; }

        /// <summary>
        /// 主板序列号
        /// </summary> 
        public string BID { get; set; }

        /// <summary>
        /// 设备出厂编号
        /// </summary> 
        public string DeviceNo { get; set; }

        #region 声音相关

        /// <summary>
        /// 声音速率
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// 声音音量
        /// </summary>
        public int Volumn { get; set; }

        /// <summary>
        /// 声音类型 微软自带/科大讯飞
        /// </summary> 
        public int VoiceType { get; set; }

        /// <summary>
        /// 是否开启声音
        /// </summary>
        public bool IsVoiceEnable { get; set; }

        #endregion

        /// <summary>
        /// 是否开启调试
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// 配置code
        /// </summary> 
        public string ConfigCode { get; set; }

        /// <summary>
        /// SN码
        /// </summary>
        public string SerialNo { get; set; }
        
        /// <summary>
        /// 关联模板Id
        /// </summary>
        public string StFuncConfigId { get; set; }

        /// <summary>
        /// 优先展示科室类型
        /// </summary>
        public byte PriorityType { get; set; }

        /// <summary>
        /// 优先展示科室集合（JSON）
        /// </summary>
        public string PriorityTypeDept { get; set; } 

        /// <summary>
        /// 限制展示科室类型
        /// </summary>
        public byte RestrictionType { get; set; }

        /// <summary>
        /// 限制展示科室类型（JSON）
        /// </summary>
        public string RestrictionTypeDept { get; set; }

        /// <summary>
        /// 关联消杀管理ID
        /// </summary>
        public string DisinfectId { get; set; }

    }

    /// <summary>
    /// 终端声音相关类
    /// </summary>
    public class STTerminalVoiceDto
    {
        /// <summary>
        /// 终端ID集合
        /// </summary>
        public string ids { get; set; }

        /// <summary>
        /// 声音速率
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// 声音音量
        /// </summary>
        public int Volumn { get; set; }

        /// <summary>
        /// 声音类型 微软自带/科大讯飞
        /// </summary> 
        public int VoiceType { get; set; }

        /// <summary>
        /// 是否开启声音
        /// </summary>
        public bool IsVoiceEnable { get; set; }
    }
}