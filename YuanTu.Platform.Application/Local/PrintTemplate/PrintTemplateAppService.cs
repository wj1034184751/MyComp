using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Json;
using Abp.UI;
using YuanTu.Platform.Local;
using YuanTu.Platform.Local.Dto;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.Organizations;
using YuanTu.Platform.Sys;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class PrintTemplateAppService : AsynPermissionAppService<PrintTemplate, PrintTemplateDto, string, PagedPrintTemplateRequestDto, PrintTemplateDto, PrintTemplateDto>, IPrintTemplateAppService
    {
        private readonly IRepository<AbpCustomEnum, string> _repositoryEnum;
        private readonly IRepository<AbpOrg, long> _repositoryAbpOrg;
        private readonly IRepository<AbpAttachment, string> _repositoryAttachment;
        protected IHttpContextAccessor httpContext;
        public PrintTemplateAppService(IRepository<PrintTemplate, string> repository, IRepository<AbpCustomEnum, string> repositoryEnum, IRepository<AbpOrg, long> repositoryAbpOrg, IRepository<AbpAttachment, string> repositoryAttachment, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            _repositoryEnum = repositoryEnum;
            _repositoryAbpOrg = repositoryAbpOrg;
            _repositoryAttachment = repositoryAttachment;
            httpContext = httpContextAccessor;
        }

        protected override IQueryable<PrintTemplate> CreateFilteredQuery(PagedPrintTemplateRequestDto input)
        {
            var list = Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Code.Contains(input.Keyword) || x.Name.Contains(input.Keyword))
                  .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId).Select(s => new PrintTemplate
                  {
                      Id = s.Id,
                      Code = s.Code,
                      Name = s.Name,
                      PrintTypeId = s.PrintTypeId,
                      IsEnable = s.IsEnable,
                      CreationTime = s.CreationTime,
                      CreatorUserId = s.CreatorUserId,
                      DeleterUserId = s.DeleterUserId,
                      DeletionTime = s.DeletionTime,
                      IsDeleted = s.IsDeleted,
                      LastModifierUserId = s.LastModifierUserId,
                      LastModificationTime = s.LastModificationTime,
                      TenantId = s.TenantId,
                      OrgId = s.OrgId,
                      Remark = s.Remark
                  });
            return list;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<PrintTemplateDto>> GetAllAsync(PagedPrintTemplateRequestDto input)
        {
            input.Sorting = "CreationTime DESC";
            var m = await base.GetAllAsync(input);
            /*foreach (var item in m.Items)
                item.Content = string.Empty;*/
            /*foreach (var s in m.Items)
                s.Attachments = ObjectMapper.Map<List<AbpAttachmentDto>>(_repositoryAttachment.GetAllList(t => t.ExtendId.Equals(s.Id)));*/
            return m;
        }

        [ActionName("GetAll")]
        [AbpAllowAnonymous]
        public override Task<ListResultDto<PrintTemplateDto>> GetAllListAsync()
        {
            return base.GetAllListAsync();
        }

        [AbpAllowAnonymous]
        public Task<ListResultDto<PrintTemplateDto>> GetFilterListAsync(long? orgId)
        {
            var list = Repository.GetAll().Where(s => s.IsEnable)
                .WhereIf(orgId.HasValue, s => s.OrgId == orgId)
                .Select(s => new PrintTemplateDto { Code = s.Code, Name = s.Name }).ToList();
            return Task.FromResult(new ListResultDto<PrintTemplateDto>(list));
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

                var list = await Backup(orgId);

                await using var ms = new MemoryStream();
                await file.CopyToAsync(ms);

                var bytes = ms.ToArray();
                var text = Encoding.UTF8.GetString(bytes);
                var infos = text.FromJsonString<List<PrintTemplate>>();
                foreach (var info in infos)
                {
                    info.OrgId = orgId;
                    var m = list.FirstOrDefault(s => s.Code.Equals(info.Code));
                    if (m == null)
                    {
                        info.Id = CreateSequentialGuid();
                        await Repository.InsertAsync(info);
                    }
                    else
                    {
                        m.Name = info.Name;
                        m.Content = info.Content;
                        m.IsEnable = info.IsEnable;
                        m.PrintTypeId = info.PrintTypeId;
                        await Repository.UpdateAsync(m);
                    }
                }

                #region Excel

                /*var cols = new Dictionary<string, string>
                {
                    {"模板编号", "Code"},
                    {"模板名称", "Name"},
                    {"模板类型", "PrintTypeId"},
                    {"是否启用", "IsEnable"},
                    {"机构编号", "OrgId"},
                    {"模板内容", "Content"},
                };

                var file = httpContext.HttpContext.Request.Form.Files[0];

                var list = await ExcelUtil.ImportAsync<PrintTemplate>(file, cols);
                foreach (var info in list)
                {
                    info.Id = CreateSequentialGuid();
                    await Repository.InsertAsync(info);
                }*/

                #endregion

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
            }
            return false;
        }

        /// <summary>
        ///  备份该机构下模板
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        private async Task<List<PrintTemplate>> Backup(long orgId)
        {
            var bakList = await Repository.GetAllListAsync(s => s.OrgId == orgId);
            try
            {
                if (bakList.Count > 0)
                {
                    var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bak", "pt");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    await File.WriteAllTextAsync(Path.Combine(folder, $"{orgId}-{DateTime.Now:yyyyMMddHHmmss}.json"),
                        bakList.ToJsonString());
                } 
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
            }
             
            return bakList;
        }

        [HttpPost, AbpAllowAnonymous]
        public async Task<IActionResult> ExportTpl(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");

            var arr = ids.Split(',');
            if (arr.Length == 0) return null;

            #region Excel

            /* var datas = Repository.GetAll().Where(s => arr.Contains(s.Id))
                 .GroupJoin(_repositoryEnum.GetAll().Where(s => s.ParentCode.Equals("IsPrinterType")),
                     x => x.PrintTypeId, s => s.Code, (x, s) => new { x, s })
                 .SelectMany(t => t.s.DefaultIfEmpty(), (x, s) => new { x, s })
                 .GroupJoin(_repositoryAbpOrg.GetAll(), x => x.x.x.OrgId, s => s.Id, (x, s) => new { x, s })
                 .SelectMany(t => t.s.DefaultIfEmpty(), (x, s) => new
                 {
                     x.x.x.x.Code,
                     x.x.x.x.Name,
                     PrintTypeId = x.x.s.Code,
                     PrintTypeName = x.x.s.Name,
                     IsEnable = x.x.x.x.IsEnable ? 1 : 0,
                     x.x.x.x.OrgId,
                     s.DisplayName,
                     x.x.x.x.Content
                 });

             var (fileName, filePath) = await ExcelUtil.ExportAsync(Guid.NewGuid().ToString("N"), datas, new List<string> { "模板编号", "模板名称", "模板类型", "模板类型名称", "是否启用", "机构编号", "机构名称", "模板内容" });

             var ms = new MemoryStream();
             await using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
             await fs.CopyToAsync(ms);

             ms.Seek(0, SeekOrigin.Begin);*/

            #endregion

            var datas = Repository.GetAll().Where(s => arr.Contains(s.Id)).Select(s => new { s.Code, s.Name, s.PrintTypeId, s.IsEnable, s.OrgId, s.Content });
            var text = datas.ToJsonString(true);
            var fileName = $"{Guid.NewGuid()}.json";

            var ms = new MemoryStream();
            await ms.WriteAsync(Encoding.UTF8.GetBytes(text));
            ms.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationOctetStream}") { FileDownloadName = fileName };
        }

        public override async Task<PrintTemplateDto> CreateAsync(PrintTemplateDto input)
        {
            try
            {
                var model = ObjectMapper.Map<PrintTemplate>(input);
                model.Id = input.Id = CreateSequentialGuid();

                /*if (input.Attachments != null && input.Attachments.Count > 0)
                {
                    foreach (var detail in input.Attachments)
                    {
                        detail.Id = CreateSequentialGuid();
                        detail.ExtendId = model.Id;
                        await _repositoryAttachment.InsertAsync(ObjectMapper.Map<AbpAttachment>(detail));
                    }
                }*/

                await Repository.InsertAsync(model);
                return input;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                throw;
            }
        }

        public override async Task<PrintTemplateDto> UpdateAsync(PrintTemplateDto input)
        {
            try
            {
                var model = await Repository.FirstOrDefaultAsync(s => s.Id.Equals(input.Id));
                MapToEntity(input, model);

                /*
                var details = input.Attachments?.Select(s =>
                {
                    s.Id = CreateSequentialGuid();
                    return s;
                }).ToList();

                await _repositoryAttachment.DeleteAsync(s => s.ExtendId.Equals(model.Id));

                details?.ForEach(async s => await _repositoryAttachment.InsertAsync(ObjectMapper.Map<AbpAttachment>(s)));
                */

                await Repository.UpdateAsync(model);

                return MapToEntityDto(model);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                throw;
            }
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            //await _repositoryAttachment.DeleteAsync(s => s.ExtendId.Equals(input.Id));
            await base.DeleteAsync(input);
        }

        public override async Task DeleteByIds(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");
            var inputs = ids.Split(",");
            if (inputs.Length > 0)
            {
                await Repository.DeleteAsync(s => inputs.Contains(s.Id));
            }
        }

        [AbpAllowAnonymous]
        public override Task<ListResultDto<PrintTemplateDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = Repository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(key), x => x.Code.Equals(key)).Where(x => x.OrgId == orgId).ToList();

            foreach (var info in list)
            {
                if (info.LastModificationTime.HasValue)
                    info.CreationTime = info.LastModificationTime.Value;
            }

            return Task.FromResult(new ListResultDto<PrintTemplateDto>(ObjectMapper.Map<List<PrintTemplateDto>>(list)));
        }

        /*public Task Export(string ids)
        {
            httpContext.HttpContext.Response.Headers.Add("Content-Disposition", "attachment;filename=Tet.rar");
            httpContext.HttpContext.Response.ContentType = "application/octet-stream";
            httpContext.HttpContext.Response.SendFileAsync("Tet.rar");

            return Task.CompletedTask;
        }*/
    }
}
