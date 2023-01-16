namespace YuanTu.Platform.Em
{
    using System;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 题库答案
    /// 作者: 系统用户
    /// 生成时间: 2022年06月29日 17:28:17
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(Em_Question_Answer))]
    public class Em_Question_AnswerDto : CustomEntityDto<string>
    {
        
        private string _Caption;
        
        private int _Sort;
        
        private string _ImageAddress;
        
        private bool _IsAnswer;
        
        private string _Mid;
        
        /// <summary>
        /// 标题
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
        /// 图文
        /// </summary>
        public string ImageAddress
        {
            get
            {
                return this._ImageAddress;
            }
            set
            {
                this._ImageAddress = value;
            }
        }
        
        /// <summary>
        /// 是否答案
        /// </summary>
        public bool IsAnswer
        {
            get
            {
                return this._IsAnswer;
            }
            set
            {
                this._IsAnswer = value;
            }
        }
        
        /// <summary>
        /// 题库Id
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
