namespace YuanTu.Platform.Em
{
    using System;
    using System.Linq;
    using Abp.Domain.Repositories;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 题库答案
    /// 作者: 系统用户
    /// 生成时间: 2022年06月29日 17:28:17
    /// </summary>
    public class Em_Question_AnswerAppService : AsynPermissionAppService<Em_Question_Answer, Em_Question_AnswerDto, string, ParentCustomPagedAndSortedDto<string>, Em_Question_AnswerDto, Em_Question_AnswerDto>, IEm_Question_AnswerAppService
    {
        
        public Em_Question_AnswerAppService(IRepository<Em_Question_Answer, string> repository) : 
                base(repository)
        {
        }

        protected override IQueryable<Em_Question_Answer> CreateFilteredQuery(ParentCustomPagedAndSortedDto<string> input)
        {
            input.Sorting = "Sort";
            return Repository.GetAll()
                .Where(s => s.Mid == input.Mid);
        }
    }
}
