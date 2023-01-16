namespace YuanTu.Platform.Em
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using YuanTu.Platform.Common;


    /// <summary>
    /// 题库维护
    /// 作者: 系统用户
    /// 生成时间: 2022年07月08日 15:57:32
    /// </summary>
    public class Em_Question : CustomEntity<string>
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
        [Required()]
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
        /// 标题
        /// </summary>
        [Required()]
        [StringLength(128)]
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
        [Required()]
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

        /// <summary>
        /// 知识点
        /// </summary>
        [Required()]
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
        /// 答案
        /// </summary>
        [StringLength(512)]
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
