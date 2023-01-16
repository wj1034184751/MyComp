using YuanTu.Platform.Common.Dto;

namespace YuanTu.Platform.Sys
{
    [Abp.AutoMapper.AutoMap(typeof(STMsg))]
    public class STMsgDto : CustomEntityWithOrgDto<string>
    {
        /// <summary>
        /// 目录Id
        /// </summary>
        public string STMsgCatalogId { get; set; }

        /// <summary>
        /// 码值
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 报错原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 解决方案（简述）
        /// </summary>
        public string Solution { get; set; }

        /// <summary>
        /// 参考链接
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// 绑定字段
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 脚本内容
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// 语言包Id
        /// </summary>
        public string STLanguageId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public string STMsgType { get; set; }

        /// <summary>
        /// 倒计时
        /// </summary>
        public int Timeout { get; set; }
    }
}
