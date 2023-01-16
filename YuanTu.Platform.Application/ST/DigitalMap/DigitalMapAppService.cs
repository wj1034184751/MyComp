namespace YuanTu.Platform.St
{
    using System;
    using Abp.Domain.Repositories;
    using YuanTu.Platform.Common.Dto;
    
    
    /// <summary>
    /// 数字地图
    /// 作者: 系统用户
    /// 生成时间: 2022年09月06日 14:19:37
    /// </summary>
    public class DigitalMapAppService : AsynPermissionAppService<DigitalMap, DigitalMapDto, string, CustomPagedAndSortedWithOrgDto, DigitalMapDto, DigitalMapDto>, IDigitalMapAppService
    {
        
        public DigitalMapAppService(IRepository<DigitalMap, string> repository) : 
                base(repository)
        {
        }
    }
}
