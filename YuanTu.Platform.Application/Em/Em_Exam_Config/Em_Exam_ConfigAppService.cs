namespace YuanTu.Platform.Em
{
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Abp.EntityFrameworkCore;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using YuanTu.Platform.EntityFrameworkCore;


    /// <summary>
    /// 试卷配置
    /// 作者: 系统用户
    /// 生成时间: 2022年07月08日 21:38:08
    /// </summary>
    public class Em_Exam_ConfigAppService : AsynPermissionAppService<Em_Exam_Config, Em_Exam_ConfigDto, string, Em_Exam_ConfigCustomPagedAndSortedDto, Em_Exam_ConfigDto, Em_Exam_ConfigDto>, IEm_Exam_ConfigAppService
    {
        IRepository<Em_Exam_Outline_Config, string> m_repOutline_configs;
        IRepository<Em_Exam_Outline_Question_Config, string> m_repQuestion_configs;

        IRepository<Em_Question, string> m_repQuestions;
        IRepository<Em_Question_Answer, string> m_repAnswers;
        IDbContextProvider<PlatformDbContext> m_db = null;

        public Em_Exam_ConfigAppService(IRepository<Em_Exam_Config, string> repository
            , IRepository<Em_Exam_Outline_Config, string> repOutlines
            , IRepository<Em_Exam_Outline_Question_Config, string> repQuestion_configs
            , IRepository<Em_Question, string> repQuestions
            , IRepository<Em_Question_Answer, string> repAnswers,
            IDbContextProvider<PlatformDbContext> db) :
                base(repository)
        {
            this.m_repOutline_configs = repOutlines;
            this.m_repQuestion_configs = repQuestion_configs;
            this.m_repQuestions = repQuestions;
            this.m_repAnswers = repAnswers;
            this.m_db = db;
        }

        protected override IQueryable<Em_Exam_Config> CreateFilteredQuery(Em_Exam_ConfigCustomPagedAndSortedDto input)
        {
            input.Sorting = $"{nameof(Em_Exam_Config.CreationTime) } desc";
            return Repository.GetAll()
                .Where(s => s.ExamType.StartsWith(input.PrefixCode));
        }

        /// <summary>
        /// 同步题库以及答案
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, AbpAllowAnonymous]
        public async Task<bool> BatchSync(Em_Exam_Config_BatchDto input)
        {
            bool create = !input.Main.CreatorUserId.HasValue;
            if (create)
            {
                input.Main.Id = Guid.NewGuid().ToString("N");
                await Repository.InsertAsync(input.Main);
            }
            else
            {
                await Repository.UpdateAsync(input.Main);
            }

            if (input.Details == null)
            {
                input.Details = new List<Em_Exam_Outline_Config>();
            }

            foreach (var detail in input.Details)
            {
                detail.Mid = input.Main.Id;
            }

            if (!create)
            {
                var deletes = new List<Em_Exam_Outline_Config>();
                // 删除不存在的大纲
                deletes = m_repOutline_configs.GetAll().Where(v => v.Mid == input.Main.Id && !input.Details.Select(m => m.Id).Contains(v.Id)).ToList();
                foreach (var item in deletes)
                {
                    m_repOutline_configs.Delete(item);
                }
            }

            foreach (var detail in input.Details)
            {
                if (detail.CreatorUserId.HasValue)
                {
                    await m_repOutline_configs.UpdateAsync(detail);
                }
                else
                {
                    string uid = Guid.NewGuid().ToString("N");

                    foreach (var second in input.Seconds)
                    {
                        if (second.Pid == detail.Id)
                        {
                            second.Pid = uid;
                            second.Mid = input.Main.Id;
                        }
                    }

                    detail.Id = uid;

                    await m_repOutline_configs.InsertAsync(detail);
                }
            }


            if (input.Seconds == null)
            {
                input.Seconds = new List<Em_Exam_Outline_Question_Config>();
            }

            foreach (var second in input.Seconds)
            {
                second.Mid = input.Main.Id;
            }

            input.Seconds.RemoveAll(v => input.Details.Where(m => m.Id == v.Pid).Count() == 0);

            if (!create)
            {
                var deletes = new List<Em_Exam_Outline_Question_Config>();
                // 删除不存在的习题
                deletes = m_repQuestion_configs.GetAll().Where(v => v.Mid == input.Main.Id && !input.Seconds.Select(m => m.Id).Contains(v.Id)).ToList();
                foreach (var item in deletes)
                {
                    m_repQuestion_configs.Delete(item);
                }
            }

            foreach (var second in input.Seconds)
            {
                if (second.CreatorUserId.HasValue)
                {
                    await m_repQuestion_configs.UpdateAsync(second);
                }
                else
                {
                    second.Id = Guid.NewGuid().ToString("N");
                    await m_repQuestion_configs.InsertAsync(second);
                }
            }

            return true;
        }

        /// <summary>
        /// 获取随机试题
        /// </summary>
        /// <param name="input">试题配置</param>
        /// <returns></returns>
        [HttpPost, AbpAllowAnonymous]
        public async Task<Em_ExamRto> GetRandByExamConfig(Em_Exam_ConfigDto input)
        {
            Em_ExamRto res = new Em_ExamRto();

            // 获取大纲配置清单
            var outlines = m_repOutline_configs.GetAll().Where(v => v.Mid == input.Id).ToList();
            res.Outlines.AddRange(ObjectMapper.Map<List<Em_Exam_Outline_ConfigRto>>(outlines));
            // 获取问题配置清单
            var questions = m_repQuestion_configs.GetAll().Where(v => v.Mid == input.Id).ToList();

            // 获取随机问题
            foreach (var question in questions)
            {
                var query = m_db.GetDbContext().Set<Em_Question>()
                    .FromSqlRaw($"select *,RAND() as tt from em_question where QuestionType ={{0}} and DifficultyDegree = {{1}}  ORDER BY tt  limit {question.QuestionNum}"
                    , question.QuestionType, question.DifficultyDegree);
                // 获取问题清单
                res.Questions.AddRange(query.ToList()
                    .Select(m =>
                    {
                        var item = ObjectMapper.Map<Em_Exam_Outline_QuestionRto>(m);
                        // 设置大纲Id
                        item.Pid = question.Pid;
                        item.Score = question.Score;
                        return item;
                    }));
            }

            // 获取答案清单
            var answers = m_repAnswers.GetAll().Where(m => res.Questions.Select(v => v.Id).Contains(m.Mid)).ToList()
                .Select(m =>
                {
                    var item = ObjectMapper.Map<Em_Exam_Outline_Question_AnswerRto>(m);
                    item.Pid = m.Mid;
                    return item;
                });

            foreach (var answer in answers)
            {
                foreach (var question in res.Questions)
                {
                    if (question.Id == answer.Pid)
                    {
                        question.List.Add(answer);
                    }
                }
            }

            return res;
        }
    }
}
