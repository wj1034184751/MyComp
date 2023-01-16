namespace YuanTu.Platform.St
{
    using System;
    using Abp.Domain.Repositories;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 数字模型
    /// 作者: 系统用户
    /// 生成时间: 2022年09月06日 10:39:27
    /// </summary>
    public class DigitalMapModelAppService : AsynPermissionAppService<DigitalMapModel, DigitalMapModelDto, string, CustomPagedAndSortedWithOrgDto, DigitalMapModelDto, DigitalMapModelDto>, IDigitalMapModelAppService
    {
        
        public DigitalMapModelAppService(IRepository<DigitalMapModel, string> repository) : 
                base(repository)
        {
        }
    }
}
