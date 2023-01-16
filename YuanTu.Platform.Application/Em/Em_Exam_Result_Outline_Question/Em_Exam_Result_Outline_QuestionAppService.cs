namespace YuanTu.Platform.Em
{
    using System;
    using Abp.Domain.Repositories;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 习题
    /// 作者: 系统用户
    /// 生成时间: 2022年07月25日 09:33:23
    /// </summary>
    public class Em_Exam_Result_Outline_QuestionAppService : AsynPermissionAppService<Em_Exam_Result_Outline_Question, Em_Exam_Result_Outline_QuestionDto, string, ParentCustomPagedAndSortedDto<string>, Em_Exam_Result_Outline_QuestionDto, Em_Exam_Result_Outline_QuestionDto>, IEm_Exam_Result_Outline_QuestionAppService
    {
        
        public Em_Exam_Result_Outline_QuestionAppService(IRepository<Em_Exam_Result_Outline_Question, string> repository) : 
                base(repository)
        {
        }
    }
}
