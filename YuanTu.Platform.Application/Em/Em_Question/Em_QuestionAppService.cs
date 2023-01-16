namespace YuanTu.Platform.Em
{
    using Abp.Authorization;
    using Abp.Domain.Repositories;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    /// <summary>
    /// 题库维护
    /// 作者: 系统用户
    /// 生成时间: 2022年06月29日 17:28:15
    /// </summary>
    public class Em_QuestionAppService : AsynPermissionAppService<Em_Question, Em_QuestionDto, string, Em_QuestionCustomPagedAndSortedDto, Em_QuestionDto, Em_QuestionDto>, IEm_QuestionAppService
    {
        IRepository<Em_Question_Answer, string> m_repAnswers;
        public Em_QuestionAppService(IRepository<Em_Question, string> repository, IRepository<Em_Question_Answer, string> repAnswers) : 
                base(repository)
        {
            m_repAnswers = repAnswers;
        }

        protected override IQueryable<Em_Question> CreateFilteredQuery(Em_QuestionCustomPagedAndSortedDto input)
        {
            input.Sorting = $"{nameof(Em_Question.CreationTime) } desc";
            return Repository.GetAll()
                .Where(s => s.BusinessType.StartsWith(input.PrefixCode));
        }

        /// <summary>
        /// 同步题库以及答案
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, AbpAllowAnonymous]
        public async Task<bool> BatchSync(Em_Question_Answer_BatchDto input)
        {
            bool create = string.IsNullOrEmpty(input.Main.Id);
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
                input.Details = new List<Em_Question_Answer>();
            }

            foreach (var detail in input.Details)
            {
                detail.Mid = input.Main.Id;
            }

            if (!create)
            {
                var deletes = new List<Em_Question_Answer>();
                // 删除不存在的答案
                deletes = m_repAnswers.GetAll().Where(v => v.Mid == input.Main.Id && !input.Details.Select(m => m.Id).Contains(v.Id)).ToList();
                foreach (var item in deletes)
                {
                    m_repAnswers.Delete(item);
                }
            }

            foreach (var detail in input.Details)
            {
                if (string.IsNullOrEmpty(detail.Id))
                {
                    detail.Id = Guid.NewGuid().ToString("N");
                    await m_repAnswers.InsertAsync(detail);
                }
                else
                {
                    await m_repAnswers.UpdateAsync(detail);
                }
            }

            return true;
        }
    }
}
