using System;
using System.Collections.Generic;
using System.Text;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Parts;

namespace YuanTu.Platform.Local.FireWalls.Dto
{
    [Abp.AutoMapper.AutoMap(typeof(FireWall))]
    public class FireWallDto : PartBaseDto<string>
    {
        /// <summary>
        /// 程序名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 配置文件
        /// </summary>
        public string Range { get; set; }
        /// <summary>
        /// 程序路径
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// 协议
        /// </summary>
        public string Deal { get; set; }
        /// <summary>
        /// 本地地址
        /// </summary>
        public string LocalAddress { get; set; }
        /// <summary>
        /// 本地端口
        /// </summary>
        public string LocalPort { get; set; }
        /// <summary>
        /// 远端地址
        /// </summary>
        public string RemoteAddress { get; set; }
        /// <summary>
        /// 远端端口
        /// </summary>
        public string RemotePort { get; set; }
        /// <summary>
        /// 规则设置
        /// </summary>
        public string Rules { get; set; }
        /// <summary>
        /// 操作选项
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public string IsEnable { get; set; }
    }
}
