namespace YuanTu.Platform.Em
{
    using System;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 习题配置
    /// 作者: 系统用户
    /// 生成时间: 2022年07月08日 21:38:50
    /// </summary>
    public class Em_Exam_Outline_Question_ConfigRto : CustomEntityDto<string>
    {
        
        private string _Pid;
        
        private string _Mid;
        
        private int _Score;
        
        private int _Sort;
        
        private string _QuestionType;
        
        private int _QuestionNum;
        
        private string _BusinessType;
        
        private int _TotalScore;
        
        private string _DifficultyDegree;
        
        /// <summary>
        /// 大纲Id
        /// </summary>
        public string Pid
        {
            get
            {
                return this._Pid;
            }
            set
            {
                this._Pid = value;
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
        
        /// <summary>
        /// 分数
        /// </summary>
        public int Score
        {
            get
            {
                return this._Score;
            }
            set
            {
                this._Score = value;
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
        /// 题目数量
        /// </summary>
        public int QuestionNum
        {
            get
            {
                return this._QuestionNum;
            }
            set
            {
                this._QuestionNum = value;
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
        /// 总分数
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
    }
}
