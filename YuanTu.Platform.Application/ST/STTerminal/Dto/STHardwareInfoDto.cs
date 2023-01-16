using System.Collections.Generic;
using YuanTu.Platform.POS;
using YuanTu.Platform.POS.Dto;

namespace YuanTu.Platform.ST.Dto
{
    public enum CardType
    {
        //磁条卡
        Mag = 1,
        //射频卡
        M1 = 2,
        //普通芯片卡
        IC = 4,
        //身份证
        ID = 8,
        //社保卡
        MC = 16,
        //银行卡
        BK = 32,
        //未知
        Unknow = 64
    }

    public class STHardwareInfoDto
    {
        /// <summary>
        /// 终端ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 终端编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 终端类型
        /// </summary>
        public string TerminalType { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enable { get; set; }
        /// <summary>
        /// 是否更新
        /// </summary>
        public bool IsUpdated { get; set; }
        /// <summary>
        /// 主板序列号
        /// </summary> 
        public string BID { get; set; }
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

        /// <summary>
        /// 是否开启调试
        /// </summary>
        public bool IsDebug { get; set; }

        /// <summary>
        /// 硬件信息
        /// </summary>
        public STHardwareInfo HardwareInfo { get; set; }
        /// <summary>
        /// 插件信息
        /// </summary>
        public IEnumerable<STTerminalExDto> Plugins { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public object PatientCard { get; set; }

        /// <summary>
        /// 医院信息
        /// </summary>
        public Hospital Hospital { get; set; }

        /// <summary>
        /// 银联配置
        /// </summary>
        public IEnumerable<PosConfigs> PosConfig { get; set; }

        /// <summary>
        /// 运行模式
        /// </summary>
        public RunMode RunMode { get; set; }
    }


    public class PatientCardDto
    {
        /// <summary>
        /// 卡类别
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 是否卡内号
        /// </summary>
        public string IsInnerCardNo { get; set; }
        /// <summary>
        /// 是否需要密钥
        /// </summary>
        public string IsKeyA { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string KeyA { get; set; }
        /// <summary>
        /// Sec
        /// </summary>
        public string Sec { get; set; }
        /// <summary>
        /// 块
        /// </summary>
        public string Block { get; set; }
        /// <summary>
        /// 编码名称
        /// </summary>
        public string EncodeName { get; set; }
    }

    /// <summary>
    /// 硬件配置
    /// </summary>
    public class STHardwareInfo
    {
        /// <summary>
        /// 读卡器
        /// </summary>
        public List<dynamic> CardReaders { get; set; }
        /// <summary>
        /// 键盘
        /// </summary>
        public List<dynamic> Keyboards { get; set; }
        /// <summary>
        /// 打印机
        /// </summary>
        public List<dynamic> Printers { get; set; }
        /// <summary>
        /// 钱箱
        /// </summary>
        public List<dynamic> Cashboxs { get; set; }
        /// <summary>
        /// 扫码墩
        /// </summary>
        public List<dynamic> Sumatuns { get; set; }
        /// <summary>
        /// 摄像头
        /// </summary>
        public List<dynamic> Cameras { get; set; }
        /// <summary>
        /// 发卡机
        /// </summary>
        public List<dynamic> CardDispensers { get; set; }
        /// <summary>
        /// LED
        /// </summary>
        public List<dynamic> Leds { get; set; }
        /// <summary>
        /// 控制板
        /// </summary>
        public List<dynamic> Motherboards { get; set; }
        /// <summary>
        /// 心电图
        /// </summary>
        public List<dynamic> Ecgs { get; set; }
        /// <summary>
        /// 血氧仪
        /// </summary>
        public List<dynamic> Oximeters { get; set; }
        /// <summary>
        /// 身高体重仪
        /// </summary>
        public List<dynamic> HeightAndWeights { get; set; }
        /// <summary>
        /// 血压仪
        /// </summary>
        public List<dynamic> Sphygmomanometers { get; set; }
        /// <summary>
        /// 温度计
        /// </summary>
        public List<dynamic> Thermometers { get; set; }
    }

    /// <summary>
    /// 医院信息配置
    /// </summary>
    public class Hospital
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 服务器地址
        /// </summary>
        public string RemoteIP { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 医院编号
        /// </summary>
        public string HospitalId { get; set; }

        /// <summary>
        /// 监控医院编号
        /// </summary> 
        public string MonitorHospitalId { get; set; }

        /// <summary>
        /// 分院编号
        /// </summary>
        public string AreaCode { get; set; }

        /// <summary>
        /// 医联体编号
        /// </summary>
        public string UnionId { get; set; }

        /// <summary>
        /// 网关地址
        /// </summary>
        public string GatewayUrl { get; set; }

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
        public int McReadMode { get; set; }

        /// <summary>
        /// 正则匹配规则
        /// </summary> 
        public string Pattern { get; set; }

        /// <summary>
        /// 终端版本
        /// </summary>
        public string Version { get; set; } 
    }

    [Abp.AutoMapper.AutoMap(typeof(PosConfig))]
    public class PosConfigs
    {
        /// <summary>
        /// 网络模式  0-https 1-socket 2-webservice
        /// </summary>
        public byte NetWork { get; set; }
        #region 报文信息
        /// <summary>
        /// 银行TPDU
        /// </summary>
        public string TPDU { get; set; }

        /// <summary>
        /// 报文头
        /// </summary>
        public string Head { get; set; }

        #endregion

        #region 其他信息

        /// <summary>
        /// 通讯节点号
        /// </summary>
        public string CommNodeId { get; set; }

        /// <summary>
        /// 医院编码
        /// </summary>
        public string HospitalId { get; set; }

        #endregion

        #region 商户终端信息
        /// <summary>
        /// 银联终端编号
        /// </summary>
        public string TerminalId { get; set; }

        /// <summary>
        /// 商户代码
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerchantName { get; set; }
        #endregion

        #region 服务器信息

        /// <summary>
        /// 地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 超时时间(毫秒)
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 网关服务地址
        /// </summary>
        public string GatewayUrl { get; set; }

        #endregion

        #region 金属键盘信息
        /// <summary>
        /// 主密钥索引
        /// </summary>
        public byte MainKeyIndex { get; set; }

        /// <summary>
        /// PIN密钥索引
        /// </summary>
        public byte PinKeyIndex { get; set; }

        /// <summary>
        /// MAC密钥索引
        /// </summary>
        public byte MacKeyIndex { get; set; }

        /// <summary>
        /// MTR密钥索引
        /// </summary>
        public byte TrkKeyIndex { get; set; }

        /// <summary>
        /// 金属键盘
        /// </summary>
        public string KeyboardName { get; set; }

        #endregion

        /// <summary>
        /// 定时对账文件拉取时间
        /// </summary>
        public string FetchRecordTime { get; set; }

        /// <summary>
        /// 银行类型
        /// CUP,                                                            // 银联
        /// ICBC,                                                           // 工商银行
        /// ABC,                                                            // 农业银行
        /// CCB,                                                            // 建设银行
        /// BOC,                                                            // 中国银行
        /// CMBC,                                                           // 民生银行
        /// RCB,                                                            // 农商行
        /// WZCB,                                                           // 温州银行
        /// CITIC,                                                          // 中信银行
        /// CMB,                                                            // 招商银行
        /// CIB,                                                            // 兴业银行
        /// CDB,                                                            // 国家开发银行
        /// BCCB,                                                           // 北京市商业银行
        /// HSBC,                                                           // 汇丰银行
        /// PBC,                                                            // 中国人民银行
        /// RCC,                                                            // 安徽农信
        /// CEB,                                                            // 中国光大
        /// BCM,                                                            // 交通银行
        /// MSSM,                                                           // 民生卡或市民卡
        /// </summary> 
        public byte BankType { get; set; }

        /// <summary>
        /// 银联版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 环境模式
        /// Default = 0,    // 正式环境
        /// Virtual = 1,    // 硬件模拟
        /// Offline = 2,    // 离线模拟
        /// CardVR = 4,     // 读卡器模拟
        /// BoardVR = 8     // 金属键盘模拟
        /// </summary>
        public byte EnvMode { get; set; }

        /// <summary>
        /// 银行或第三方dll引用路径，用于动态加载dll
        /// </summary>
        public string DllPath { get; set; }

        /// <summary>
        /// 中间件EXE地址，解决部分银行对环境的依赖
        /// </summary>
        public string ExePath { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary> 
        public string PayMethod { get; set; }

        /// <summary>
        /// 收单机构编码
        /// </summary> 
        public string AcqInst { get; set; }

        public string Field_2F01 { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Extend { get; set; }
        public string Extend1 { get; set; }
        public string Extend2 { get; set; }
    }

    /// <summary>
    /// 运行模式
    /// </summary>
    public enum RunMode { On, Off }
}