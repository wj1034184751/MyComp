using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YuanTu.Platform.Local.FireWalls.Dto;
using Abp.Linq.Extensions;
using Abp.Extensions;

namespace YuanTu.Platform.Local.FireWalls
{
    public class FireWallAppService: AsynPermissionAppService<FireWall, FireWallDto, string, PagedFireWallRequestDto, FireWallDto, FireWallDto>, IFireWallAppService
    {
        private readonly IRepository<AbpAttachment, string> _repositoryAttachment;
        public FireWallAppService(IRepository<FireWall, string> repository, IRepository<AbpAttachment, string> repositoryAttachment)
            : base(repository)
        {
            _repositoryAttachment = repositoryAttachment;
        }

        protected override IQueryable<FireWall> CreateFilteredQuery(PagedFireWallRequestDto input)
        {
            var list = Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Name.Contains(input.Keyword));
            return list;
        }
    }
}
