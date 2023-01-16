namespace YuanTu.Platform.Em
{
    using System;
    using Abp.Domain.Repositories;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 大纲
    /// 作者: 系统用户
    /// 生成时间: 2022年07月25日 09:33:20
    /// </summary>
    public class Em_Exam_Result_OutlineAppService : AsynPermissionAppService<Em_Exam_Result_Outline, Em_Exam_Result_OutlineDto, string, ParentCustomPagedAndSortedDto<string>, Em_Exam_Result_OutlineDto, Em_Exam_Result_OutlineDto>, IEm_Exam_Result_OutlineAppService
    {
        
        public Em_Exam_Result_OutlineAppService(IRepository<Em_Exam_Result_Outline, string> repository) : 
                base(repository)
        {
        }
    }
}
