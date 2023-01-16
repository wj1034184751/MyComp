namespace YuanTu.Platform.Em
{
    using System;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 试卷配置
    /// 作者: 系统用户
    /// 生成时间: 2022年07月25日 08:30:19
    /// </summary>
    [Abp.AutoMapper.AutoMap(typeof(Em_Exam_Config))]
    public class Em_Exam_ConfigDto : CustomEntityDto<string>
    {
        
        private string _Caption;
        
        private string _Decribe;
        
        private string _Author;
        
        private System.DateTime _PublishTime;
        
        private bool _IsPublish;
        
        private string _ExamType;
        
        private int _Sort;
        
        private bool _IsFixTime;
        
        private System.DateTime _BeginTime;
        
        private System.DateTime _EndTime;
        
        private int _TotalTime;
        
        private bool _IsForceSubmit;
        
        private string _ExamMode;
        
        private string _NavImage;
        
        private int _TotalScore;
        
        /// <summary>
        /// 试卷标题
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
        /// 试卷描述
        /// </summary>
        public string Decribe
        {
            get
            {
                return this._Decribe;
            }
            set
            {
                this._Decribe = value;
            }
        }
        
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get
            {
                return this._Author;
            }
            set
            {
                this._Author = value;
            }
        }
        
        /// <summary>
        /// 发布时间
        /// </summary>
        public System.DateTime PublishTime
        {
            get
            {
                return this._PublishTime;
            }
            set
            {
                this._PublishTime = value;
            }
        }
        
        /// <summary>
        /// 已发布
        /// </summary>
        public bool IsPublish
        {
            get
            {
                return this._IsPublish;
            }
            set
            {
                this._IsPublish = value;
            }
        }
        
        /// <summary>
        /// 试卷类型
        /// </summary>
        public string ExamType
        {
            get
            {
                return this._ExamType;
            }
            set
            {
                this._ExamType = value;
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
        /// 是否固定时间
        /// </summary>
        public bool IsFixTime
        {
            get
            {
                return this._IsFixTime;
            }
            set
            {
                this._IsFixTime = value;
            }
        }
        
        /// <summary>
        /// 开始时间
        /// </summary>
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
        /// 结束时间
        /// </summary>
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
        /// 答题时间(s)
        /// </summary>
        public int TotalTime
        {
            get
            {
                return this._TotalTime;
            }
            set
            {
                this._TotalTime = value;
            }
        }
        
        /// <summary>
        /// 是否强制交卷
        /// </summary>
        public bool IsForceSubmit
        {
            get
            {
                return this._IsForceSubmit;
            }
            set
            {
                this._IsForceSubmit = value;
            }
        }
        
        /// <summary>
        /// 默认模式
        /// </summary>
        public string ExamMode
        {
            get
            {
                return this._ExamMode;
            }
            set
            {
                this._ExamMode = value;
            }
        }
        
        /// <summary>
        /// 导航图片
        /// </summary>
        public string NavImage
        {
            get
            {
                return this._NavImage;
            }
            set
            {
                this._NavImage = value;
            }
        }
        
        /// <summary>
        /// 试卷总分
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
    }
}
