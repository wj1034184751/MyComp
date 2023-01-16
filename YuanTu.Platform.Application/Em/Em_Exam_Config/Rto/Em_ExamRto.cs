using System;
using System.Collections.Generic;
using System.Text;

namespace YuanTu.Platform.Em
{
    [Abp.AutoMapper.AutoMap(typeof(Em_Question))]
    public class Em_Exam_Outline_QuestionRto : Em_Question
    {
        public string Pid { get; set; }

        public string Mid { get; set; }

        public int Score { get; set; }

        public string ConfirmAnswer { get; set; }

        public List<Em_Exam_Outline_Question_AnswerRto> List { get; set; } = new List<Em_Exam_Outline_Question_AnswerRto>();
    }

    [Abp.AutoMapper.AutoMap(typeof(Em_Question_Answer))]
    public class Em_Exam_Outline_Question_AnswerRto : Em_Question_Answer
    {
        public string Pid { get; set; }
    }


    public class Em_ExamRto
    {
        public Em_Exam_ResultDto Exam { get; set; }

        public List<Em_Exam_Outline_ConfigRto> Outlines { get; set; } = new List<Em_Exam_Outline_ConfigRto>();

        public List<Em_Exam_Outline_QuestionRto> Questions { get; set; } = new List<Em_Exam_Outline_QuestionRto>();

        //public List<Em_Exam_Outline_Question_AnswerRto> Answers { get; set; } = new List<Em_Exam_Outline_Question_AnswerRto>();
    }
}