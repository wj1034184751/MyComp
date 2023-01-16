namespace YuanTu.Platform.Em
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using YuanTu.Platform.Common;
    
    
    /// <summary>
    /// 习题配置
    /// 作者: 系统用户
    /// 生成时间: 2022年07月09日 15:59:15
    /// </summary>
    public class Em_Exam_Outline_Question_Config : CustomEntity<string>
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
        [StringLength(32)]
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
        [StringLength(32)]
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
        [Required()]
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
        [Required()]
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
        [StringLength(32)]
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
        [Required()]
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
        [StringLength(32)]
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
        [Required()]
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
        [StringLength(32)]
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
