namespace YuanTu.Platform.Em
{
    using System;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 题库维护
    /// 作者: 系统用户
    /// 生成时间: 2022年07月08日 13:36:19
    /// </summary>
    public class Em_QuestionRto : CustomEntityDto<string>
    {
        
        private string _QuestionType;
        
        private string _Caption;
        
        private bool _IsCorrect;
        
        private string _DifficultyDegree;
        
        private string _BusinessType;
        
        private string _Answers;
        
        private string _Solution;
        
        /// <summary>
        /// 题库类型
        /// </summary>
        public string QuestionType
        {
            get
            {
                return this._QuestionType;
            }
            set
            {
                this._QuestionType = value;
            }
        }
        
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
        /// 是否正确
        /// </summary>
        public bool IsCorrect
        {
            get
            {
                return this._IsCorrect;
            }
            set
            {
                this._IsCorrect = value;
            }
        }
        
        /// <summary>
        /// 难度级别
        /// </summary>
        public string DifficultyDegree
        {
            get
            {
                return this._DifficultyDegree;
            }
            set
            {
                this._DifficultyDegree = value;
            }
        }
        
        /// <summary>
        /// 知识点
        /// </summary>
        public string BusinessType
        {
            get
            {
                return this._BusinessType;
            }
            set
            {
                this._BusinessType = value;
            }
        }
        
        /// <summary>
        /// 答案
        /// </summary>
        public string Answers
        {
            get
            {
                return this._Answers;
            }
            set
            {
                this._Answers = value;
            }
        }
        
        /// <summary>
        /// 解题思路
        /// </summary>
        public string Solution
        {
            get
            {
                return this._Solution;
            }
            set
            {
                this._Solution = value;
            }
        }
    }
}
