using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Json;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Local;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.ST.Dto;
using YuanTu.Platform.Sys.Dto;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTemplateEnumAppService : AsynPermissionAppService<STTemplateEnum, STTemplateEnumDto, string, PagedSTTemplateEnumRequestDto, STTemplateEnumDto, STTemplateEnumDto>, ISTTemplateEnumAppService
    {
        private readonly IRepository<STTemplateCustomEnum, string> _repositoryCustomEnum;
        protected IHttpContextAccessor httpContext;

        public STTemplateEnumAppService(IRepository<STTemplateEnum, string> repository, IRepository<STTemplateCustomEnum, string> repositoryCustomEnum, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _repositoryCustomEnum = repositoryCustomEnum;
            httpContext = httpContextAccessor;
        }

        protected override IQueryable<STTemplateEnum> CreateFilteredQuery(PagedSTTemplateEnumRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Code.Contains(input.Keyword) || x.Name.Contains(input.Keyword));
        }


        [ActionName("GetPage")]
        public override async Task<PagedResultDto<STTemplateEnumDto>> GetAllAsync(PagedSTTemplateEnumRequestDto input)
        {
            return await base.GetAllAsync(input);
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            await _repositoryCustomEnum.DeleteAsync(s => s.TemplateId == input.Id);

            await base.DeleteAsync(input);
        }

        [AbpAllowAnonymous, RequestSizeLimit(PlatformConsts.RequestSizeLimit)]
        public async Task<bool> ImportTpl(long orgId)
        {
            try
            {
                if (httpContext.HttpContext == null || !httpContext.HttpContext.Request.HasFormContentType || httpContext.HttpContext.Request.Form.Files.Count == 0)
                    return false;

                var file = httpContext.HttpContext.Request.Form.Files[0];
                var ext = Path.GetExtension(file.FileName);
                if (!".json".Equals(ext)) return false;

                await using var ms = new MemoryStream();
                await file.CopyToAsync(ms);

                var bytes = ms.ToArray();
                var text = Encoding.UTF8.GetString(bytes);
                var infos = text.FromJsonString<List<STTemplateEnumDto>>();
                foreach (var info in infos)
                {
                    var copy = MapToEntity(info);
                    copy.OrgId = orgId;
                    copy.Id = CreateSequentialGuid();

                    await CopyDetails(info, copy);

                    await Repository.InsertAsync(copy);
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
            }
            return false;
        }

        private async Task CopyDetails(STTemplateEnumDto info, STTemplateEnum copy)
        {
            if (info.Details != null)
            {

                var list = info.Details.ToString().FromJsonString<List<STTemplateCustomEnum>>();
                var root = list.Find(s => string.IsNullOrWhiteSpace(s.ParentId));

                if (root != null)
                {
                    var copyModel = CopyModel(root.ParentId, root);
                    var copyList = new List<STTemplateCustomEnum> { copyModel };

                    SetTemplateEnumValue(root.Id, copyModel.Id, list, copyList);

                    foreach (var copyInfo in copyList)
                    {
                        copyInfo.TemplateId = copy.Id;
                        await _repositoryCustomEnum.InsertAsync(copyInfo);
                    }
                }
            }
        }

        private void SetTemplateEnumValue(string oldPid, string newPid, List<STTemplateCustomEnum> list, List<STTemplateCustomEnum> copyList)
        {
            var ss = list.FindAll(s => s.ParentId.Equals(oldPid));
            foreach (var info in ss)
            {
                var copy = CopyModel(newPid, info);
                copyList.Add(copy);

                SetTemplateEnumValue(info.Id, copy.Id, list, copyList);
            }
        }

        private STTemplateCustomEnum CopyModel(string newPid, STTemplateCustomEnum info)
        {
            var copy = new STTemplateCustomEnum
            {
                Id = CreateSequentialGuid(),
                Code = info.Code,
                Name = info.Name,
                ParentId = newPid,
                ParentCode = info.ParentCode,
                Sort = info.Sort,
                OrgId = info.OrgId,
                Remark = info.Remark,
                Rule = info.Rule
            };
            return copy;
        }

        [HttpPost, AbpAllowAnonymous]
        public async Task<IActionResult> ExportTpl(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");

            var arr = ids.Split(',');
            if (arr.Length == 0) return null;

            var datas = Repository.GetAll().Where(s => arr.Contains(s.Id)).ToList();
            var maps = ObjectMapper.Map<List<STTemplateEnumDto>>(datas);
            var mapIds = maps.Select(s => s.Id);
            var enums = await _repositoryCustomEnum.GetAllListAsync(s => mapIds.Contains(s.TemplateId));
            foreach (var info in maps)
            {
                var customEnums = enums.Where(s => s.TemplateId.Equals(info.Id));
                info.Details = ObjectMapper.Map<List<STTemplateCustomEnumDto>>(customEnums).Select(s => new { s.Id, s.Code, s.Name, s.OrgId, s.ParentId, s.ParentCode, s.TemplateId, s.Sort, s.Rule, s.Remark }).ToList();
            }
            var text = maps.Select(s => new { s.Code, s.Name, s.Details }).ToJsonString(true);
            var fileName = $"{Guid.NewGuid()}.json";

            var ms = new MemoryStream();
            await ms.WriteAsync(Encoding.UTF8.GetBytes(text));
            ms.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationOctetStream}") { FileDownloadName = fileName };
        }
    }
}