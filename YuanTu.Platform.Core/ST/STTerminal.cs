using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using YuanTu.Platform.Common;

namespace YuanTu.Platform.ST
{
    public class STTerminal : CustomEntityWithOrg<string>
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Code { get; set; }

        /// <summary>
        /// 终端名称
        /// </summary>
        [Required]
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Spec { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TerminalTypeId { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string IP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public virtual int Port { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sort { get; set; }

        /// <summary>
        /// 建筑Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string BuildingId { get; set; }

        /// <summary>
        /// 所在楼层
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string FloorId { get; set; }

        /// <summary>
        /// 点位
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Position { get; set; }

        /// <summary>
        /// 所在坐标
        /// </summary>
        public virtual int X { get; set; }

        /// <summary>
        /// 所在坐标
        /// </summary>
        public virtual int Y { get; set; }

        /// <summary>
        /// 所在坐标
        /// </summary>
        public virtual int Z { get; set; }

        ///// <summary>
        ///// 经度
        ///// </summary>
        //public decimal Longitude { get; set; }

        ///// <summary>
        ///// 纬度
        ///// </summary>
        //public decimal Latitude { get; set; }

        /// <summary>
        /// 硬盘序列号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string HID { get; set; }

        /// <summary>
        /// 网卡序列号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Mac { get; set; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 是否在线
        /// </summary>
        public virtual bool IsPowerOn { get; set; }

        /// <summary>
        /// 是否已更新
        /// </summary>
        public virtual bool IsUpdated { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string Version { get; set; }

        /// <summary>
        /// 模板编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TemplateId { get; set; }

        /// <summary>
        /// 模板名称
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string TemplateName { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string HospitalId { get; set; }

        #region 设备证书

        /// <summary>
        /// 产品序列号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string ProductKey { get; set; }

        /// <summary>
        /// 设备密钥
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DeviceSecret { get; set; }

        #endregion

        /// <summary>
        /// 文件夹ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string FolderId { get; set; }

        /// <summary>
        /// 病区ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string WardAreaId { get; set; }

        /// <summary>
        /// 院区编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string HospitalCode { get; set; }

        /// <summary>
        /// 签到时间
        /// </summary>
        public virtual DateTime SignDate { get; set; } 

        /// <summary>
        /// 预检设备功能配置编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string HealthConfigId { get; set; }

        /// <summary>
        /// 准入
        /// </summary>
        public virtual bool CanbeAccess { get; set; }

        /// <summary>
        /// 运行模式
        /// </summary>
        public virtual int RunMode { get; set; }

        /// <summary>
        /// 主板序列号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string BID { get; set; }

        /// <summary>
        /// 设备出厂编号
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DeviceNo { get; set; }

        /// <summary>
        /// 声音速率
        /// </summary>
        public virtual int Rate { get; set; }

        /// <summary>
        /// 声音音量
        /// </summary>
        public virtual int Volumn { get; set; }

        /// <summary>
        /// 声音类型 微软自带/科大讯飞
        /// </summary> 
        public virtual int VoiceType { get; set; }

        /// <summary>
        /// 是否开启声音
        /// </summary>
        public virtual bool IsVoiceEnable { get; set; }

        /// <summary>
        /// 是否开启调试
        /// </summary>
        public virtual bool IsDebug { get; set; }

        /// <summary>
        /// 配置code
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)] 
        public virtual string ConfigCode { get; set; }

        /// <summary>
        /// SN码
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public virtual string SerialNo { get; set; }

        /// <summary>
        /// 关联功能模板Id
        /// </summary>
        [StringLength(PlatformConsts.MaxLength32)]
        public string StFuncConfigId { get; set; }

        /// <summary>
        /// 关联消杀管理ID
        /// </summary>
        [StringLength(PlatformConsts.MaxLength255)]
        public virtual string DisinfectId { get; set; }

    }
}