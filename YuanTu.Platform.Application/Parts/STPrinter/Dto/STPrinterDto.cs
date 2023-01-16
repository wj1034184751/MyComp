using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Parts.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(STPrinter))]
    public class STPrinterDto : PartBaseDto<string>
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandId { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// 通讯类型
        /// </summary>
        public string CommunicationType { get; set; }
        /// <summary>
        /// 串口
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// 支持U转串
        /// </summary>
        public bool IsUsbToPort { get; set; }
        /// <summary>
        /// 波特率
        /// </summary>
        public string Baud { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 双纸盒
        /// </summary>
        public bool IsDoubleTray { get; set; }
        /// <summary>
        /// 打印机类型
        /// </summary>
        public string IsPrinterType { get; set; }
        /// <summary>
        /// 纸张大小
        /// </summary>
        public string IsPrintPaperSize { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 打印
        /// </summary>
        public bool Print { get; set; }
        /// <summary>
        /// 打印机名称
        /// </summary> 
        public string PrinterName { get; set; }
        /// <summary>
        /// 是否彩色
        /// </summary>
        public bool IsColor { get; set; }
        /// <summary>
        /// 打印机IP
        /// </summary>
        public string PrinterIP { get; set; }
    }
}