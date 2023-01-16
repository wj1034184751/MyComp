namespace YuanTu.Platform.Em
{
    using System;
    using System.Linq;
    using Abp.Domain.Repositories;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 习题配置
    /// 作者: 系统用户
    /// 生成时间: 2022年07月08日 21:38:50
    /// </summary>
    public class Em_Exam_Outline_Question_ConfigAppService : AsynPermissionAppService<Em_Exam_Outline_Question_Config, Em_Exam_Outline_Question_ConfigDto, string, ParentCustomPagedAndSortedDto<string>, Em_Exam_Outline_Question_ConfigDto, Em_Exam_Outline_Question_ConfigDto>, IEm_Exam_Outline_Question_ConfigAppService
    {
        
        public Em_Exam_Outline_Question_ConfigAppService(IRepository<Em_Exam_Outline_Question_Config, string> repository) : 
                base(repository)
        {
        }

        protected override IQueryable<Em_Exam_Outline_Question_Config> CreateFilteredQuery(ParentCustomPagedAndSortedDto<string> input)
        {
            input.Sorting = $"{nameof(Em_Exam_Outline_Question_Config.CreationTime) } desc";
            return Repository.GetAll()
                .Where(s => s.Mid == input.Mid);
        }
    }
}
