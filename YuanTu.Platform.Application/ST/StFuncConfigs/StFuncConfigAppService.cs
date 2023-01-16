using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.EntityFrameworkCore;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.StFuncConfigs
{
    public class StFuncConfigAppService : AsynPermissionAppService<StFuncConfig, StFuncConfigDto, string, PagedStFuncConfigRequestDto, StFuncConfigDto, StFuncConfigDto>, IStFuncConfigAppService
    {
        protected IHttpContextAccessor httpContext;
        IDbContextProvider<PlatformDbContext> _db = null;
        public StFuncConfigAppService(IRepository<StFuncConfig, string> repository, IHttpContextAccessor httpContextAccessor, IDbContextProvider<PlatformDbContext> db) : base(repository)
        {
            this.httpContext = httpContextAccessor;

            _db = db;
        }

        protected override IQueryable<StFuncConfig> CreateFilteredQuery(PagedStFuncConfigRequestDto input)
        {
            input.Sorting = " Sort";
            return this.Repository.GetAll()
                .Where(v => !v.IsUnique && string.IsNullOrEmpty(v.ParentId));
        }

        public async override Task DeleteAsync(EntityDto<string> input)
        {
            var item = await base.GetEntityByIdAsync(input.Id);

            var deletes = this.Repository.GetAll().Where(v => v.LevelCode.StartsWith(item.LevelCode));

            _db.GetDbContext().BulkDelete(deletes);
        }

        public override Task<StFuncConfigDto> UpdateAsync(StFuncConfigDto input)
        {
            if (input.LevelCode.StartsWith("0000"))
            {
                if (input.ReferParentUniqueId != input.ParentId && input.LevelCode.Length > 4)
                {
                    var updates = new List<StFuncConfig>();

                    // 重置层级码
                    string maxcode = "";
                    var pid = input.ParentId;

                    if (string.IsNullOrEmpty(pid))
                    {
                        maxcode = "0000";
                    }
                    else
                    {
                        maxcode = this.Repository.GetAll().Where(v => v.ParentId == pid).Max(v => v.LevelCode);

                        if (string.IsNullOrEmpty(maxcode))
                        {
                            maxcode = this.Repository.GetAll().FirstOrDefault(v => v.Id == pid).LevelCode + "0001";
                        }
                        else
                        {
                            maxcode = maxcode.Substring(0, maxcode.Length - 4) + $"{int.Parse(maxcode.Substring(maxcode.Length - 4)) + 1}".PadLeft(4, '0');
                        }
                    }

                    ResetLevelCode(maxcode, input.Id, updates);

                    _db.GetDbContext().BulkUpdate(updates);

                    input.LevelCode = maxcode;
                }

                input.ReferParentUniqueId = input.ParentId;
            }

            return base.UpdateAsync(input);
        }

        private void ResetLevelCode(string maxcode, string pid, List<StFuncConfig> updates)
        {
            var children = this.Repository.GetAll().Where(v => v.ParentId == pid).ToList();

            var index = 1;

            foreach (var item in children.OrderBy(v => v.Sort))
            {
                item.LevelCode = maxcode + index.ToString().PadLeft(4, '0');

                ResetLevelCode(item.LevelCode, item.Id, updates);

                index++;
            }

            updates.AddRange(children);
        }

        public async Task<ListResultDto<StFuncConfigDto>> GetTreeData(TreeStFuncConfigRequestDto input)
        {
            List<StFuncConfig> res = new List<StFuncConfig>();
            if (string.IsNullOrEmpty(input.Pid))
            {
                res = await this.Repository.GetAllListAsync(v => v.LevelCode.StartsWith("0000"));

                if (res.Count == 0)
                {
                    await CreateAsync(new StFuncConfigDto() { IsUnique = true, Code = "UniqueFunc", Name = "全局功能模板", LevelCode = "0000", ReadOnly = 0 });

                    res = await this.Repository.GetAllListAsync(v => v.LevelCode.StartsWith("0000"));
                }
            }
            else
            {
                var parent = this.Repository.Get(input.Pid);

                res = await this.Repository.GetAllListAsync(v => v.LevelCode.StartsWith(parent.LevelCode));
            }

            return new ListResultDto<StFuncConfigDto>(ObjectMapper.Map<List<StFuncConfigDto>>(res.OrderBy(v => v.Sort)));
        }

        public override Task<StFuncConfigDto> CreateAsync(StFuncConfigDto input)
        {
            // 设置层级码
            if (!input.IsUnique)
            {
                var roots = this.Repository.GetAllList(v => v.LevelCode.StartsWith("0000"));
                if (roots.Count == 0)
                {
                    throw new UserFriendlyException("请先维护全局模板!");
                }

                var levelcode = string.Empty;

                if (!string.IsNullOrEmpty(input.ParentId))
                {
                    var parent = this.Repository.Get(input.ParentId);
                    if (parent != null)
                    {
                        levelcode = parent.LevelCode;
                    }
                    else
                    {
                        input.ParentId = string.Empty;
                    }
                }

                var maxcode = string.Empty;

                if (string.IsNullOrEmpty(input.ParentId))
                {
                    maxcode = this.Repository.GetAll().Where(v => string.IsNullOrEmpty(v.ParentId)).Max(v => v.LevelCode);
                }
                else
                {
                    maxcode = this.Repository.GetAll().Where(v => v.ParentId == input.ParentId).Max(v => v.LevelCode);
                }

                if (string.IsNullOrEmpty(maxcode))
                    maxcode = "0000";

                maxcode = maxcode.Substring(maxcode.Length - 4);

                input.LevelCode = levelcode + (int.Parse(maxcode) + 1).ToString().PadLeft(4, '0');

                // 判断是否新增模板
                if (string.IsNullOrEmpty(input.ParentId))
                {
                    input.Id = Guid.NewGuid().ToString("N");

                    var list = MapperUtil.Mapper<List<StFuncConfig>>(roots);

                    var root = list.FirstOrDefault(v => string.IsNullOrEmpty(v.ParentId));

                    list.Remove(root);

                    input.ReferUniqueId = root.Id;

                    input.ReferParentUniqueId = root.ReferParentUniqueId;

                    var children = list.Where(v => v.ParentId == root.Id).ToList();

                    for (var pp = 0; pp < children.Count; pp++)
                    {
                        var child = children[pp];
                        child.ParentId = input.Id;
                    }

                    // 自动导入全局模板
                    for (var p = 0; p < list.Count; p++)
                    {
                        var item = list[p];
                        //item.ReferParentUniqueId = item.ParentId;

                        var key = Guid.NewGuid().ToString("N");
                        children = list.Where(v => v.ParentId == item.Id).ToList();
                        for (var pp = 0; pp < children.Count; pp++)
                        {
                            var child = children[pp];
                            child.ParentId = key;
                        }

                        item.ReferUniqueId = item.Id;

                        item.IsUnique = false;
                        item.LevelCode = input.LevelCode + item.LevelCode.Substring(4);
                        item.Id = key;
                    }

                    _db.GetDbContext().BulkInsert(list);
                    //foreach (var item in list)
                    //{
                    //    base.Repository.Insert(item);
                    //}
                }
            }

            return base.CreateAsync(input);
        }

        /// <summary>
        /// 同步模板
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<bool> SyncTemplateAsync(dynamic data)
        {
            string type = data.type;
            string dd = data.ids;
            var levelcodes = dd.Split(',');

            // 获取全局模板
            var source = Repository.GetAll().Where(v => v.LevelCode.StartsWith("0000")).OrderBy(v => v.LevelCode).ToList();

            var updates = new List<StFuncConfig>();
            var inserts = new List<StFuncConfig>();
            var deletes = new List<StFuncConfig>();

            foreach (var levelcode in levelcodes)
            {
               SyncData(source, levelcode, deletes, updates, inserts);
            }

            _db.GetDbContext().BulkUpdate(updates);

            _db.GetDbContext().BulkInsert(inserts);

            _db.GetDbContext().BulkDelete(deletes);

            return await Task.FromResult(true);
        }

        /// <summary>
        /// 同步全局模板
        /// </summary>
        /// <param name="source"></param>
        /// <param name="levelcode"></param>
        private void SyncData(List<StFuncConfig> source, string levelcode, List<StFuncConfig> deletes, List<StFuncConfig> updates, List<StFuncConfig> inserts)
        {
            var targets = Repository.GetAll().Where(v => v.LevelCode.StartsWith(levelcode)).ToList();

            var exits = targets.ToList();

            // 移除无效明细
            foreach (var target in exits)
            {
                bool exist = false;
                foreach (var item in source)
                {
                    if (target.ReferUniqueId == item.Id)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    //await this.Repository.HardDeleteAsync(v => v.Id == target.Id);

                    deletes.Add(target);

                    targets.Remove(target);
                }
            }

            foreach (var item in source)
            {
                StFuncConfig one = new StFuncConfig();
                one.Id = Guid.NewGuid().ToString("N");

                if (string.IsNullOrEmpty(item.ParentId))
                    continue;
                bool isExist = false;
                foreach (var target in targets)
                {
                    if (item.Id == target.ReferUniqueId)
                    {
                        one = target;
                        isExist = true;
                        break;
                    }
                }

                one.Sort = item.Sort;
                one.Code = item.Code;
                one.Name = item.Name;
                one.Remark = item.Remark;
                one.StFuncItemConfigId = item.StFuncItemConfigId;
                one.ComponentType = item.ComponentType;
                one.ReadOnly = item.ReadOnly;
                one.SyncMode = item.SyncMode;
                one.Enable = item.Enable;
                one.ReferUniqueId = item.Id;

                // 判定是否覆盖模式
                if (item.SyncMode)
                {
                    one.Value = item.Value;
                }

                if (!isExist)
                {
                    var target = targets.Where(v => v.ReferUniqueId == item.ParentId).FirstOrDefault();
                    if (target != null)
                    {
                        one.ParentId = target.Id;
                        one.LevelCode = target.LevelCode.Substring(0, 4) + item.LevelCode.Substring(4);
                    }

                    one.Value = item.Value;

                    //await Repository.InsertAsync(one);

                    inserts.Add(one);

                    targets.Add(one);
                }
                else
                {
                    if ((one.LastModificationTime ?? one.CreationTime) < (item.LastModificationTime ?? item.CreationTime))
                    {
                        // 更新层级码
                        one.LevelCode = one.LevelCode.Substring(0, 4) + item.LevelCode.Substring(4);

                        // 判断结构是否发生变化
                        if (one.ReferParentUniqueId != item.ParentId)
                        {
                            one.ParentId = targets.FirstOrDefault(v => v.ReferUniqueId == item.ParentId).Id;
                        }

                        updates.Add(one);
                    }
                }
            }
        }

        /// <summary>
        /// 同步模板
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<bool> SaveConfig(List<StFuncConfig> list)
        {
            foreach (var one in list)
            {
                await Repository.UpdateAsync(one);
            }

            return true;
        }

        [HttpGet, AbpAllowAnonymous]
        public async Task<IActionResult> ExportTpl()
        {
            var list = Repository.GetAll().Where(v=>v.LevelCode.StartsWith("0000")).ToList();

            var ms = new MemoryStream();

            JsonSerializerSettings settings = new JsonSerializerSettings();

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            await ms.WriteAsync(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(list, settings)));
            ms.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationOctetStream}") { FileDownloadName = "全局模板.json" };
        }

        [AbpAllowAnonymous, RequestSizeLimit(PlatformConsts.RequestSizeLimit)]
        public async Task<dynamic> ImportTpl()
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

                var text = Encoding.UTF8.GetString(ms.ToArray());
                var infos = JsonConvert.DeserializeObject<List<StFuncConfig>>(text);

                if (infos.Count == 0)
                {
                    throw new UserFriendlyException("前端模板列表为空，不允许导入!");
                }
                var first = infos.FirstOrDefault();
                if (string.IsNullOrEmpty(first.LevelCode) || !first.LevelCode.StartsWith("0000"))
                {
                    throw new UserFriendlyException("非全局前端模板，不允许导入!");
                }

                var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bak", "stfunc");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                var filename = Path.Combine(dir, $"全局模板_{DateTime.Now.ToString("yyMMddHHmmss")}.json");
                
                // 备份当前模板
                File.WriteAllText(filename, JsonConvert.SerializeObject(Repository.GetAll().Where(v=>v.IsUnique).ToList()));

                await Repository.HardDeleteAsync(v => v.LevelCode.StartsWith("0000") && v.IsUnique);

                foreach (var info in infos)
                {
                    await Repository.InsertAsync(info);
                }

                return new { success = true };
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);

                return new { success = false, msg = ex.Message };
            }
        }

        public async Task<bool> ExportNew(StFuncConfigDto input)
        {
            var levelcode = input.LevelCode;

            // 获取要导入的模板清单
            var roots = this.Repository.GetAllList(v => v.LevelCode.StartsWith(levelcode));

            input.LevelCode = "";

            var maxcode = this.Repository.GetAll().Where(v => string.IsNullOrEmpty(v.ParentId)).Max(v => v.LevelCode);

            maxcode = (int.Parse(maxcode.Substring(0, 4)) + 1).ToString().PadLeft(4, '0');

            input.Id = Guid.NewGuid().ToString("N");

            var list = MapperUtil.Mapper<List<StFuncConfig>>(roots);

            var root = list.FirstOrDefault(v => string.IsNullOrEmpty(v.ParentId));

            list.Remove(root);

            input.ReferUniqueId = root.ReferUniqueId;

            input.LevelCode = maxcode;

            await base.CreateAsync(input);

            var children = list.Where(v => v.ParentId == root.Id).ToList();

            for (var pp = 0; pp < children.Count; pp++)
            {
                var child = children[pp];
                child.ParentId = input.Id;
            }

            // 自动导入全局模板
            for (var p = 0; p < list.Count; p++)
            {
                var item = list[p];

                var key = Guid.NewGuid().ToString("N");
                children = list.Where(v => v.ParentId == item.Id).ToList();

                for (var pp = 0; pp < children.Count; pp++)
                {
                    var child = children[pp];
                    child.ParentId = key;
                }

                item.IsUnique = false;
                item.LevelCode = input.LevelCode + item.LevelCode.Substring(4);
                item.Id = key;
            }

            foreach (var item in list)
            {
                await base.Repository.InsertAsync(item);
            }

            return true;
        }
    }
}
