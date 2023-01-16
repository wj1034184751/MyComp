using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.POS.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(PosConfig))]
    public class PosConfigDto : CustomEntityWithOrgDto<string>
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

        /// <summary>
        /// 自助机编号
        /// </summary>  
        public string TerminalIds { get; set; }
        /// <summary>
        /// 自助机名称/code
        /// </summary>
        public string BindTerminal { get; set; }
    }
}