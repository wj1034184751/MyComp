namespace YuanTu.Platform.Em
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using YuanTu.Platform.Common.Dto;
    using YuanTu.Platform.EntityFrameworkCore;


    /// <summary>
    /// 考试结果
    /// 作者: 系统用户
    /// 生成时间: 2022年07月25日 09:36:05
    /// </summary>
    public class Em_Exam_ResultAppService : AsynPermissionAppService<Em_Exam_Result, Em_Exam_ResultDto, string, CustomPagedAndSortedDto, Em_Exam_ResultDto, Em_Exam_ResultDto>, IEm_Exam_ResultAppService
    {
        IRepository<Em_Exam_Result_Outline, string> m_repOutline;
        IRepository<Em_Exam_Result_Outline_Question, string> m_repQuestion;
        IDbContextProvider<PlatformDbContext> m_db = null;

        public Em_Exam_ResultAppService(IRepository<Em_Exam_Result, string> repository,
            IDbContextProvider<PlatformDbContext> db) : base(repository)
        {
            m_db = db;
        }

        protected override IQueryable<Em_Exam_Result> CreateFilteredQuery(CustomPagedAndSortedDto input)
        {
            input.Sorting = $"{ nameof(Em_Exam_Result.CreationTime) } desc";
            return Repository.GetAll();
        }

        /// <summary>
        /// 记录考试结果
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, AbpAllowAnonymous]
        public async Task<bool> CreateExamResult(Em_ExamRto input)
        {
            input.Exam.ExaminerId = this.AbpSession.UserId.Value;

            Em_Exam_ResultDto main = new Em_Exam_ResultDto();
            main.Caption = input.Exam.Caption;
            main.BeginTime = input.Exam.BeginTime;
            main.EndTime = input.Exam.EndTime;
            main.Examiner = "admin";
            main.Em_Exam_ConfigId = input.Exam.Em_Exam_ConfigId;
            main.ExaminerId = this.AbpSession.UserId.Value;
            main.IsPractice = false;
            main.TotalScore = input.Exam.TotalScore;
            await base.CreateAsync(main);

            List<Em_Exam_Result_Outline> outlines = new List<Em_Exam_Result_Outline>();
            foreach (var item in input.Outlines)
            {
                Em_Exam_Result_Outline outline = new Em_Exam_Result_Outline();
                outline.Caption = item.Caption;
                outline.Em_Exam_Outline_ConfigId = item.Mid;
                outline.Mid = main.Id;
                outline.Id = Guid.NewGuid().ToString("N");
                outline.Sort = item.Sort;
                outlines.Add(outline);

                item.Remark = outline.Id;
            }
            m_db.GetDbContext().BulkInsert(outlines);

            List<Em_Exam_Result_Outline_Question> questions = new List<Em_Exam_Result_Outline_Question>();
            foreach (var item in input.Questions)
            {
                Em_Exam_Result_Outline_Question question = new Em_Exam_Result_Outline_Question();
                question.Mid = main.Id;
                question.Pid = input.Outlines.FirstOrDefault(v=>v.Id == item.Pid).Remark;
                question.Em_QuestionId = item.Id;
                question.ConfirmAnswer = item.ConfirmAnswer;
                question.Id = Guid.NewGuid().ToString("N");

                questions.Add(question);
            }
            m_db.GetDbContext().BulkInsert(questions);

            return true;
        }
    }
}
