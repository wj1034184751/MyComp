using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.Authorization.Menus.Dto;

namespace YuanTu.Platform.Jc
{
    /// <summary>
    /// 基础枚举信息服务
    /// </summary>
    public class Jc_UserEnumAppService : AsynPermissionAppService<Jc_UserEnum, Jc_UserEnumDto, string, Jc_UserEnum_CustomPagedAndSortedWithOrgDto, Jc_UserEnumDto, Jc_UserEnumDto>, IJc_UserEnumAppService
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        public Jc_UserEnumAppService(IRepository<Jc_UserEnum, string> repository) : base(repository)
        {
        }

        protected override IQueryable<Jc_UserEnum> CreateFilteredQuery(Jc_UserEnum_CustomPagedAndSortedWithOrgDto input)
        {
            input.Sorting = "Sort";

            var list = Repository.GetAll().WhereIf(!input.PrefixCode.IsNullOrWhiteSpace(), x => x.PrefixCode.StartsWith(input.PrefixCode) || (x.PrefixCode + "." + x.Code == input.PrefixCode));

            return list;
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<Jc_UserEnumDto>> GetAllListAsync()
        {
            var list = (await Repository.GetAllListAsync()).OrderBy(s => s.Sort);

            return new ListResultDto<Jc_UserEnumDto>(ObjectMapper.Map<List<Jc_UserEnumDto>>(list));
        }
    }
}
