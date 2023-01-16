using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.ST.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STPluginFolderAppService : AsynPermissionAppService<STPluginFolder, STPluginFolderDto, string, PagedSTPluginFolderRequestDto, STPluginFolderDto, STPluginFolderDto>, ISTPluginFolderAppService
    {
        private readonly IRepository<AbpAttachment, string> _repositoryAttachment;
        public STPluginFolderAppService(IRepository<STPluginFolder, string> repository, IRepository<AbpAttachment, string> repositoryAttachment)
            : base(repository)
        {
            _repositoryAttachment = repositoryAttachment;
        }

        public override Task<ListResultDto<STPluginFolderDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = Repository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(key), s => s.ExtendId.Equals(key) || s.ParentId.Equals(key)).Where(s => s.OrgId == orgId).OrderBy(s => s.Sort).ToList();
            var dto = ObjectMapper.Map<List<STPluginFolderDto>>(list);
            return Task.FromResult(new ListResultDto<STPluginFolderDto>(dto));
        }

        [ActionName("GetAll")]
        public override Task<ListResultDto<STPluginFolderDto>> GetAllListAsync()
        {
            var list = Repository.GetAll().OrderBy(s => s.Sort);
            var dto = ObjectMapper.Map<List<STPluginFolderDto>>(list);
            return Task.FromResult(new ListResultDto<STPluginFolderDto>(dto));
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public override async Task DeleteByIds(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");

            var arr = ids.Split(',');
            if (arr.Length == 0) return;

            await Repository.DeleteAsync(s => arr.Contains(s.Id));
        }
    }
}