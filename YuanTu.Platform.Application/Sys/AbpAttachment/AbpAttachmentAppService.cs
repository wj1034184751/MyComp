using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.ST;
using YuanTu.Platform.Sys.AbpAttachment;
using YuanTu.Platform.Sys.AbpAttachment.Dto;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.Sys
{
    /// <summary>
    /// 附件管理服务类
    /// </summary>
    public class AbpAttachmentAppService : AsynPermissionAppService<Platform.AbpAttachment, AbpAttachmentDto, string, PagedAbpAttachmentDto, AbpAttachmentDto, AbpAttachmentDto>
        , IAbpAttachmentAppService
    {

        protected IHttpContextAccessor httpContext;
        private IRepository<STPluginFolder, string> _repositoryFolder;
        private IRepository<AbpZipLog, long> _repositoryZip;

        /// <summary>
        /// 构造函数
        /// </summary>
        public AbpAttachmentAppService(IRepository<Platform.AbpAttachment, string> repository, IHttpContextAccessor httpContextAccessor, IRepository<STPluginFolder, string> repositoryFolder, IRepository<AbpZipLog, long> repositoryZip) :
                base(repository)
        {
            httpContext = httpContextAccessor;
            _repositoryFolder = repositoryFolder;
            _repositoryZip = repositoryZip;
        }

        protected override IQueryable<Platform.AbpAttachment> CreateFilteredQuery(PagedAbpAttachmentDto input)
        {
            input.Sorting = " CreationTime DESC";
            return base.CreateFilteredQuery(input).WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), s => s.Name.Contains(input.Keyword) || s.HashCode.Contains(input.Keyword));
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(AbpAttachmentDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Name))
                throw new UserFriendlyException(nameof(input.Name));
            if (string.IsNullOrWhiteSpace(input.HashCode))
                throw new UserFriendlyException(nameof(input.HashCode));
            if (string.IsNullOrWhiteSpace(input.ServerPath))
                throw new UserFriendlyException(nameof(input.ServerPath));

            var fileName = $"{input.HashCode}{Path.GetExtension(input.Name)}";

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, input.ServerPath, fileName);
            if (!File.Exists(path)) return new NotFoundResult();

            var ms = new MemoryStream();
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
                await fs.CopyToAsync(ms);

            ms.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationOctetStream}; charset=UTF-8") { FileDownloadName = input.Name };
        }

        [HttpPost]
        public async Task<List<string>> DownloadZipFile(List<string> ids)
        {
            if (ids == null || ids.Count == 0) throw new UserFriendlyException(nameof(ids));
            var result = new List<string>();
            try
            {
                await ExistZip(ids, result);

                var list = await Repository.GetAllListAsync(s => ids.Contains(s.Id));
                foreach (var info in list)
                {
                    var name = info.Id;//info.Name.Replace(info.FileExt, string.Empty);
                    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, info.ServerPath, $"{info.HashCode}{info.FileExt}");
                    var zipPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, info.ServerPath, $"{name}.zip");

                    ZipFile(path, info.Name, zipPath);

                    result.Add($"{info.ServerPath}\\{name}.zip");
                    await _repositoryZip.InsertAsync(new AbpZipLog { FileId = info.Id, ZipPath = $"{info.ServerPath}\\{name}.zip" });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
            }

            return result;
        }

        public async Task<List<AbpAttachmentExDto>> Download(List<string> ids)
        {
            if (ids == null || ids.Count == 0) throw new UserFriendlyException(nameof(ids));
            var result = new List<AbpAttachmentExDto>();
            try
            {
                var list = await Repository.GetAllListAsync(s => ids.Contains(s.Id));
                result.AddRange(list.Select(info => new AbpAttachmentExDto()
                {
                    Name = info.Name,
                    Url = $"{httpContext.HttpContext.Request.Scheme}://{httpContext.HttpContext.Request.Host}/{Path.Combine(info.ServerPath, $"{info.HashCode}{info.FileExt}").Replace(@"\", "/")}"
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
            }

            return result;
        }

        private async Task ExistZip(List<string> ids, List<string> result)
        {
            var zipList = await _repositoryZip.GetAllListAsync(s => ids.Contains(s.FileId));
            if (zipList != null && zipList.Count > 0)
            {
                zipList.ForEach(s =>
                {
                    if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, s.ZipPath)))
                    {
                        result.Add(s.ZipPath);
                        ids.Remove(s.FileId);
                    }
                });
            }
        }

        //[DisableRequestSizeLimit]
        [RequestSizeLimit(PlatformConsts.RequestSizeLimit)]
        public async Task<ListResultDto<AbpAttachmentDto>> UploadFile()
        {
            return await ListResultDto();
        }

        private async Task<ListResultDto<AbpAttachmentDto>> ListResultDto(string folderId = null, string rootId = null)
        {
            var datas = new List<AbpAttachmentDto>();
            try
            {
                if (httpContext.HttpContext == null || !httpContext.HttpContext.Request.HasFormContentType || httpContext.HttpContext.Request.Form.Files.Count == 0)
                    return new ListResultDto<AbpAttachmentDto>();

                var files = httpContext.HttpContext.Request.Form.Files;

                foreach (var file in files)
                {
                    var data = new AbpAttachmentDto
                    {
                        Name = file.FileName,
                        FileExt = Path.GetExtension(file.FileName),
                        FileSize = file.Length.ToString(),
                        ServerPath = Path.Combine("uploads", DateTime.Now.ToString("yyyy"),
                            DateTime.Now.ToString("MM"))
                    };

                    var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, data.ServerPath);
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    await using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);

                    var bytes = ms.ToArray();
                    data.HashCode = bytes.ComputeMD5();

                    var m = await Repository.GetAll().Where(s => s.HashCode.Equals(data.HashCode) && s.FileExt.Equals(data.FileExt)).OrderByDescending(s => s.CreationTime).FirstOrDefaultAsync();
                    if (m != null)
                    {
                        data.Id = m.Id;
                        data.ServerPath = m.ServerPath;
                    }
                    data.Url = $"{httpContext.HttpContext.Request.Scheme}://{httpContext.HttpContext.Request.Host}/{Path.Combine(data.ServerPath, $"{data.HashCode}{data.FileExt}").Replace(@"\", "/")}";

                    await AddPluginFolder(folderId, rootId, data);
                    datas.Add(data);

                    if (m != null) continue;

                    await using var fs = new FileStream(Path.Combine(folderPath, $"{data.HashCode}{data.FileExt}"), FileMode.OpenOrCreate,
                        FileAccess.ReadWrite);
                    await fs.WriteAsync(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Logger.Error(ex.ToString);
            }

            return new ListResultDto<AbpAttachmentDto>(datas);
        }

        private async Task AddPluginFolder(string folderId, string rootId, AbpAttachmentDto data)
        {
            if (!string.IsNullOrWhiteSpace(folderId))
            {
                if (string.IsNullOrWhiteSpace(data.Id))
                {
                    data.Id = CreateSequentialGuid();
                    var model = MapToEntity(data);
                    await Repository.InsertAsync(model);
                }

                //判断同文件夹下同名文件
                var list = await _repositoryFolder.GetAllListAsync(s =>
                    s.ParentId.Equals(folderId) && s.Name.Equals(data.Name));
                if (list.Count > 0)
                {
                    foreach (var info in list)
                    {
                        info.HashCode = data.HashCode;
                        info.FilePath = data.ServerPath;
                        info.FileSize = long.TryParse(data.FileSize, out var f) ? f : 0;
                        info.FileId = data.Id;
                        info.CreationTime = data.CreationTime;
                        await _repositoryFolder.UpdateAsync(info);
                    }
                }
                else
                {
                    var id = CreateSequentialGuid();
                    data.ExtendId = id;
                    await _repositoryFolder.InsertAsync(new STPluginFolder
                    {
                        Id = id,
                        Name = data.Name,
                        FileSize = long.TryParse(data.FileSize, out var f) ? f : 0,
                        FilePath = data.ServerPath,
                        HashCode = data.HashCode,
                        ParentId = folderId,
                        FileId = data.Id,
                        Sort = 100,
                        ExtendId = rootId
                    });
                }
            }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fid">父级文件夹ID</param>
        /// <param name="rid">顶级节点ID</param>
        /// <returns></returns>
        [RequestSizeLimit(PlatformConsts.RequestSizeLimit)]
        public async Task<ListResultDto<AbpAttachmentDto>> UploadFileById(string fid, string rid)
        {
            if (string.IsNullOrWhiteSpace(fid))
                throw new UserFriendlyException(nameof(fid));
            if (string.IsNullOrWhiteSpace(rid))
                throw new UserFriendlyException(nameof(rid));
            return await ListResultDto(fid, rid);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public override async Task DeleteByIds(dynamic data)
        {
            string ids = data.ids;
            string delFlag = data.delFlag;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");

            var arr = ids.Split(',');
            if (arr.Length == 0) return;

            var list = await Repository.GetAllListAsync(s => arr.Contains(s.Id));

            await Repository.DeleteAsync(s => arr.Contains(s.Id));

            SyncDeleteFile(delFlag, list);
        }

        private void SyncDeleteFile(string delFlag, List<Platform.AbpAttachment> list)
        {
            try
            {
                if (!"1".Equals(delFlag)) return;

                foreach (var path in list
                    .Select(info => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, info.ServerPath,
                        $"{info.HashCode}{info.FileExt}")).Where(File.Exists))
                    File.Delete(path);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
            }
        }

        /// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="filePath">被压缩的文件名称(包含文件路径)，文件的全路径</param>
        /// <param name="trueFileName">压缩包内真实文件名称</param>
        /// <param name="zipedFileName">压缩后的文件名称(包含文件路径)，保存的文件名称</param>
        /// <param name="compressionLevel">压缩率0（无压缩）到 9（压缩率最高）</param>
        private void ZipFile(string filePath, string trueFileName, string zipedFileName, int compressionLevel = 9)
        {
            // 如果文件没有找到，则报错 
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("文件：" + filePath + "没有找到！");
            }
            // 如果压缩后名字为空就默认使用源文件名称作为压缩文件名称
            if (string.IsNullOrEmpty(zipedFileName))
            {
                var oldValue = Path.GetFileName(filePath);
                if (oldValue != null)
                {
                    zipedFileName = filePath.Replace(oldValue, "") + Path.GetFileNameWithoutExtension(filePath) + ".zip";
                }
            }
            // 如果压缩后的文件名称后缀名不是zip，就是加上zip
            if (Path.GetExtension(zipedFileName) != ".zip")
            {
                zipedFileName = zipedFileName + ".zip";
            }
            // 如果指定位置目录不存在，创建该目录 
            var zipedDir = zipedFileName.Substring(0, zipedFileName.LastIndexOf("\\", StringComparison.Ordinal));
            if (!Directory.Exists(zipedDir))
            {
                Directory.CreateDirectory(zipedDir);
            }

            var streamToZip = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var zipFile = File.Create(zipedFileName);
            var zipStream = new ZipOutputStream(zipFile);
            var zipEntry = new ZipEntry(trueFileName) { IsUnicodeText = true };
            zipStream.PutNextEntry(zipEntry);
            zipStream.SetLevel(compressionLevel);
            var buffer = new byte[2048];
            var size = streamToZip.Read(buffer, 0, buffer.Length);
            zipStream.Write(buffer, 0, size);
            try
            {
                while (size < streamToZip.Length)
                {
                    var sizeRead = streamToZip.Read(buffer, 0, buffer.Length);
                    zipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            finally
            {
                zipStream.Finish();
                zipStream.Close();
                streamToZip.Close();
            }
        }
    }
}
