namespace YuanTu.Platform.Em
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using YuanTu.Platform.Common;
    
    
    /// <summary>
    /// 考试结果
    /// 作者: 系统用户
    /// 生成时间: 2022年07月25日 09:36:05
    /// </summary>
    public class Em_Exam_Result : CustomEntity<string>
    {
        
        private long _ExaminerId;
        
        private int _TotalScore;
        
        private System.DateTime _BeginTime;
        
        private string _Em_Exam_ConfigId;
        
        private bool _IsPractice;
        
        private System.DateTime _EndTime;
        
        private string _Caption;
        
        private string _Examiner;
        
        /// <summary>
        /// 考试人员
        /// </summary>
        [Required()]
        [StringLength(32)]
        public long ExaminerId
        {
            get
            {
                return this._ExaminerId;
            }
            set
            {
                this._ExaminerId = value;
            }
        }
        
        /// <summary>
        /// 考试得分
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
        /// 开始时间
        /// </summary>
        [Required()]
        public System.DateTime BeginTime
        {
            get
            {
                return this._BeginTime;
            }
            set
            {
                this._BeginTime = value;
            }
        }
        
        /// <summary>
        /// 试卷Id
        /// </summary>
        [Required()]
        public string Em_Exam_ConfigId
        {
            get
            {
                return this._Em_Exam_ConfigId;
            }
            set
            {
                this._Em_Exam_ConfigId = value;
            }
        }
        
        /// <summary>
        /// 是否练习
        /// </summary>
        [Required()]
        public bool IsPractice
        {
            get
            {
                return this._IsPractice;
            }
            set
            {
                this._IsPractice = value;
            }
        }
        
        /// <summary>
        /// 结束时间
        /// </summary>
        [Required()]
        public System.DateTime EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                this._EndTime = value;
            }
        }
        
        /// <summary>
        /// 试卷标题
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
        /// 考试人员
        /// </summary>
        [Required()]
        [StringLength(128)]
        public string Examiner
        {
            get
            {
                return this._Examiner;
            }
            set
            {
                this._Examiner = value;
            }
        }
    }
}
