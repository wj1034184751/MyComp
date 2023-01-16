namespace YuanTu.Platform.Em
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using YuanTu.Platform.Common;
    
    
    /// <summary>
    /// 大纲
    /// 作者: 系统用户
    /// 生成时间: 2022年07月25日 09:33:20
    /// </summary>
    public class Em_Exam_Result_Outline : CustomEntity<string>
    {
        
        private string _Em_Exam_Outline_ConfigId;
        
        private string _Caption;
        
        private int _TotalScore;
        
        private int _Sort;
        
        private string _Mid;
        
        /// <summary>
        /// 试卷大纲Id
        /// </summary>
        [Required()]
        public string Em_Exam_Outline_ConfigId
        {
            get
            {
                return this._Em_Exam_Outline_ConfigId;
            }
            set
            {
                this._Em_Exam_Outline_ConfigId = value;
            }
        }
        
        /// <summary>
        /// 大纲说明	
        /// </summary>
        [Required()]
        [StringLength(1024)]
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
        /// 答题总分
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
        /// 考试结果Id
        /// </summary>
        [Required()]
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
    }
}
