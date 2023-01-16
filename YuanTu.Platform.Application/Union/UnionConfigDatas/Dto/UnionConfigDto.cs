using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Union
{
    [Abp.AutoMapper.AutoMap(typeof(UnionConfigData))]
    public class UnionConfigDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string ServerIP { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public string ServerPort { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public string TimeOut { get; set; }

        /// <summary>
        /// 银行TPDU
        /// </summary>
        public string TPDU { get; set; }

        /// <summary>
        /// 报文头
        /// </summary>
        public string Head { get; set; }

        /// <summary>
        /// 终端编号
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

        /// <summary>
        /// 主密钥
        /// </summary>
        public string MKey { get; set; }

        /// <summary>
        /// 主密钥索引
        /// </summary>
        public int MainKeyIndex { get; set; }

        /// <summary>
        /// PIN密钥索引
        /// </summary>
        public int PinKeyIndex { get; set; }

        /// <summary>
        /// MAC密钥索引
        /// </summary>
        public int MacKeyIndex { get; set; }

        /// <summary>
        /// MTR密钥索引
        /// </summary>
        public string TrkKeyIndex { get; set; }

        /// <summary>
        /// 银行类型
        /// </summary>
        public string BankType { get; set; }

        /// <summary>
        /// 银联读卡器名称
        /// </summary>
        public string CardReaderName { get; set; }

        /// <summary>
        /// 是否吸入式
        /// </summary>
        public string Inhale { get; set; }

        /// <summary>
        /// 读卡器端口或U口
        /// </summary>
        public string CardReaderPort { get; set; }

        /// <summary>
        /// 读卡器波特率
        /// </summary>
        public string CardReaderBaud { get; set; }

        /// <summary>
        /// 自动退卡
        /// </summary>
        public string AutoEject { get; set; }

        /// <summary>
        /// 金属键盘名称
        /// </summary>
        public string MKeyboardName { get; set; }

        /// <summary>
        /// 金属键盘串口或U口
        /// </summary>
        public string MKeyboardPort { get; set; }

        /// <summary>
        /// 金属键盘波特率
        /// </summary>
        public string MKeyboardBaud { get; set; }

        /// <summary>
        /// 环境模式 0:真实环境 1:硬件模拟 2:离线模拟
        /// </summary>
        public int EnvMode { get; set; }

        /// <summary>
        /// 银联版本号
        /// </summary>
        public string Version { get; set; }
    }
}
