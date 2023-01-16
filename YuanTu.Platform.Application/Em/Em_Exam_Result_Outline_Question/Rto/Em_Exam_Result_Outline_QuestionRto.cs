namespace YuanTu.Platform.Em
{
    using System;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 习题
    /// 作者: 系统用户
    /// 生成时间: 2022年07月25日 09:33:23
    /// </summary>
    public class Em_Exam_Result_Outline_QuestionRto : CustomEntityDto<string>
    {
        
        private string _Em_QuestionId;
        
        private string _Mid;
        
        private string _Pid;
        
        private string _Answer;
        
        /// <summary>
        /// 习题Id
        /// </summary>
        public string Em_QuestionId
        {
            get
            {
                return this._Em_QuestionId;
            }
            set
            {
                this._Em_QuestionId = value;
            }
        }
        
        /// <summary>
        /// 考试结果Id
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
        /// 作答
        /// </summary>
        public string Answer
        {
            get
            {
                return this._Answer;
            }
            set
            {
                this._Answer = value;
            }
        }
    }
}
