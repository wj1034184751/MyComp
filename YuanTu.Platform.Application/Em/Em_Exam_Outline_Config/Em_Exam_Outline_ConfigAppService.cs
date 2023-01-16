namespace YuanTu.Platform.Em
{
    using System;
    using System.Linq;
    using Abp.Domain.Repositories;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 大纲配置
    /// 作者: 系统用户
    /// 生成时间: 2022年07月08日 21:38:11
    /// </summary>
    public class Em_Exam_Outline_ConfigAppService : AsynPermissionAppService<Em_Exam_Outline_Config, Em_Exam_Outline_ConfigDto, string, ParentCustomPagedAndSortedDto<string>, Em_Exam_Outline_ConfigDto, Em_Exam_Outline_ConfigDto>, IEm_Exam_Outline_ConfigAppService
    {
        
        public Em_Exam_Outline_ConfigAppService(IRepository<Em_Exam_Outline_Config, string> repository) : 
                base(repository)
        {
        }

        protected override IQueryable<Em_Exam_Outline_Config> CreateFilteredQuery(ParentCustomPagedAndSortedDto<string> input)
        {
            input.Sorting = $"{nameof(Em_Exam_Outline_Config.CreationTime) } desc";
            return Repository.GetAll()
                .Where(s => s.Mid == input.Mid);
        }
    }
}
