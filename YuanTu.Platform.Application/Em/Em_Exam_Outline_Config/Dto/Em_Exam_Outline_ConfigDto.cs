namespace YuanTu.Platform.Em
{
    using System;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 大纲配置
    /// 作者: 系统用户
    /// 生成时间: 2022年07月08日 21:38:11
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(Em_Exam_Outline_Config))]
    public class Em_Exam_Outline_ConfigDto : CustomEntityDto<string>
    {
        
        private string _Caption;
        
        private int _TotalScore;
        
        private int _Sort;
        
        private string _Mid;
        
        /// <summary>
        /// 大纲说明
        /// </summary>
        public string Caption
        {
            get
            {
                return this._Caption;
            }
            set
            {
                this._Caption = value;
            }
        }
        
        /// <summary>
        /// 总分
        /// </summary>
        public int TotalScore
        {
            get
            {
                return this._TotalScore;
            }
            set
            {
                this._TotalScore = value;
            }
        }
        
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort
        {
            get
            {
                return this._Sort;
            }
            set
            {
                this._Sort = value;
            }
        }
        
        /// <summary>
        /// 试卷配置Id
        /// </summary>
        public string Mid
        {
            get
            {
                return this._Mid;
            }
            set
            {
                this._Mid = value;
            }
        }
    }
}
