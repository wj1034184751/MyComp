using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Json;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.ST.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.ST
{
    /// <summary>
    /// 文件版本服务类
    /// </summary>
    public class STPluginFileVersionAppService : AsynPermissionAppService<STPluginFileVersion, STPluginFileVersionDto, string, PagedSTPluginFileVersionDto, STPluginFileVersionDto, STPluginFileVersionDto>
        , ISTPluginFileVersionAppService
    {
        private readonly IRepository<AbpCustomEnum, string> _repositoryEnum;
        private readonly IRepository<STPluginFolder, string> _repositoryFolder;
        private readonly IRepository<STTerminal, string> _repositoryTerminal;
        private readonly IRepository<STTerminalPlugin, string> _repositoryPlugin;
        private readonly IRepository<STTerminalPluginNet, string> _repositoryPluginNet;
        private readonly IRepository<STTemplatePlugin, string> _repositoryTPlugin;
        private readonly IRepository<STTemplatePluginNet, string> _repositoryTPluginNet;

        private IDictionary<string, int> _pluginPorts;
        public IDictionary<string, int> PluginPorts =>
            _pluginPorts ??= new Dictionary<string, int>
            {
                {"adapter", 12600},
                {"hardware", 12601},
                {"system", 12602},
                {"pos", 12603},
                {"medical", 12604},
                {"face", 12605},
                {"newface", 12605},
                {"gateway", 12606},
                {"his", 12607},
                {"payment", 12608},
                {"identity", 12610},
                {"temperature", 12611},
            };


        /// <summary>
        /// 构造函数
        /// </summary>
        public STPluginFileVersionAppService(IRepository<STPluginFileVersion, string> repository, IRepository<STPluginFolder, string> repositoryFolder, IRepository<AbpCustomEnum, string> repositoryEnum, IRepository<STTerminal, string> repositoryTerminal, IRepository<STTerminalPlugin, string> repositoryPlugin, IRepository<STTerminalPluginNet, string> repositoryPluginNet, IRepository<STTemplatePlugin, string> repositoryTPlugin, IRepository<STTemplatePluginNet, string> repositoryTPluginNet) : base(repository)
        {
            _repositoryEnum = repositoryEnum;
            _repositoryFolder = repositoryFolder;
            _repositoryTerminal = repositoryTerminal;
            _repositoryPlugin = repositoryPlugin;
            _repositoryPluginNet = repositoryPluginNet;
            _repositoryTPlugin = repositoryTPlugin;
            _repositoryTPluginNet = repositoryTPluginNet;
        }

        protected override IQueryable<STPluginFileVersion> CreateFilteredQuery(PagedSTPluginFileVersionDto input)
        {
            input.Sorting = "CreationTime desc";
            return Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.FolderId.Equals(input.Keyword))
                .Where(s => s.OrgId == input.OrgId);
        }
         
        [ActionName("GetPage")]
        public override async Task<PagedResultDto<STPluginFileVersionDto>> GetAllAsync(PagedSTPluginFileVersionDto input)
        {
            return await base.GetAllAsync(input);
        }

        public override async Task<STPluginFileVersionDto> CreateAsync(STPluginFileVersionDto input)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(input.Path) && Path.GetInvalidPathChars().Any(c => input.Path.Contains(c)))
                    throw new UserFriendlyException("文件路径包含非法字符");

                if (!string.IsNullOrWhiteSpace(input.AbsolutePath) && Path.GetInvalidPathChars().Any(c => input.AbsolutePath.Contains(c)))
                    throw new UserFriendlyException("文件绝对路径包含非法字符");

                LoadData(input);

                var m = await base.CreateAsync(input);

                await AddTerminalPlugin(input, m);
                await AddTemplatePlugin(input, m);

                return m;
            }
            catch (Exception ex)
            {
                Logger.Error("发布插件失败", ex);
                throw new UserFriendlyException(ex.Message);
            }
        }

        /// <summary>
        /// 添加终端插件信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private async Task AddTerminalPlugin(STPluginFileVersionDto input, STPluginFileVersionDto m)
        {
            try
            {
                if (input.TerminalIds != null)
                {
                    var infos = await _repositoryPlugin.GetAllListAsync(s => input.TerminalIds.Contains(s.TermianlId) && s.PluginCode.Equals(m.PluginCode));
                    if (infos != null && infos.Count > 0)
                    {
                        var ids = infos.Select(s => s.Id).ToArray();
                        await _repositoryPluginNet.DeleteAsync(s => input.TerminalIds.Contains(s.TermianlId) && ids.Contains(s.PluginId));
                        await _repositoryPlugin.DeleteAsync(s => ids.Contains(s.Id));
                    }

                    foreach (var id in input.TerminalIds)
                    {
                        var n = new STTerminalPlugin
                        {
                            Id = CreateSequentialGuid(),
                            TermianlId = id,
                            Enabled = true,
                            PluginId = m.FolderId,
                            PluginName = input.PluginName,
                            PluginCode = m.PluginCode,
                            VersionId = m.Id,
                            Version = m.Version,
                        };
                        var net = new STTerminalPluginNet
                        {
                            Id = CreateSequentialGuid(),
                            TermianlId = id,
                            PluginId = n.Id,
                            NetType = "HTTP",
                            Port = input.Port
                        };
                        await _repositoryPluginNet.InsertAsync(net);
                        await _repositoryPlugin.InsertAsync(n);

                        await UpdateTerminal(id);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
            }
        }

        private async Task UpdateTerminal(string id)
        {
            try
            {
                var st = await _repositoryTerminal.GetAsync(id);
                st.IsUpdated = false;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
            }
        }

        /// <summary>
        /// 添加模板插件信息
        /// </summary>
        /// <param name="input"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        private async Task AddTemplatePlugin(STPluginFileVersionDto input, STPluginFileVersionDto m)
        {
            try
            {
                if (input.TemplateIds != null)
                {
                    var infos = await _repositoryTPlugin.GetAllListAsync(s => input.TemplateIds.Contains(s.TemplateId) && s.PluginCode.Equals(m.PluginCode));
                    if (infos != null && infos.Count > 0)
                    {
                        var ids = infos.Select(s => s.Id).ToArray();
                        await _repositoryTPluginNet.DeleteAsync(s => input.TemplateIds.Contains(s.TemplateId) && ids.Contains(s.PluginId));
                        await _repositoryTPlugin.DeleteAsync(s => ids.Contains(s.Id));
                    }

                    foreach (var id in input.TemplateIds)
                    {
                        var n = new STTemplatePlugin
                        {
                            Id = CreateSequentialGuid(),
                            TemplateId = id,
                            Enabled = true,
                            PluginId = m.FolderId,
                            PluginName = input.PluginName,
                            PluginCode = m.PluginCode,
                            VersionId = m.Id,
                            Version = m.Version,
                        };
                        var net = new STTemplatePluginNet
                        {
                            Id = CreateSequentialGuid(),
                            TemplateId = id,
                            PluginId = n.Id,
                            NetType = "HTTP",
                            Port = input.Port
                        };
                        await _repositoryTPluginNet.InsertAsync(net);
                        await _repositoryTPlugin.InsertAsync(n);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
            }
        }

        /// <summary>
        /// 装配数据
        /// </summary>
        /// <param name="input"></param>
        private void LoadData(STPluginFileVersionDto input)
        {
            //设置版本号
            SetVersion(input, out var oldVersion);
            //生成文件目录结构
            SetJsonText(input, oldVersion);
        }

        /// <summary>
        /// 生成文件目录结构
        /// </summary>
        /// <param name="input"></param>
        /// <param name="oldVersion"></param>
        private void SetJsonText(STPluginFileVersionDto input, STPluginFileVersion oldVersion)
        {
            var enums = new List<AbpCustomEnum>();
            var info = _repositoryEnum.Get(input.FolderId);
            enums.Add(info);

            GetSuperior(enums, info, input.PluginCode);

            var dic = GetFileTree(enums);

            var root = dic[input.PluginCode];
            GetChild(root, enums, dic);

            if (oldVersion != null)
            {
                var old = oldVersion.JsonText.FromJsonString<STPluginDirectoryDto>();

                Merge(root, old);
            }
            input.JsonText = root.ToJsonString(true);
        }

        private static void Merge(STPluginDirectoryDto root, STPluginDirectoryDto old)
        {
            if (old?.Children == null) return;
            foreach (var oldChild in old.Children)
            {
                var b = root.Children.Find(s => s.Id.Equals(oldChild.Id));
                if (b != null)
                {
                    Merge(b, oldChild);
                }
                else
                {
                    if (!root.Children.Any(s => s.Name.Equals(oldChild.Name)))
                        root.Children.Add(oldChild);
                }
            }
        }

        /// <summary>
        /// 获取目录树
        /// </summary>
        /// <param name="enums"></param>
        /// <returns></returns>
        private Dictionary<string, STPluginDirectoryDto> GetFileTree(List<AbpCustomEnum> enums)
        {
            var dic = new Dictionary<string, STPluginDirectoryDto>();
            var all = new List<STPluginFolder>();
            var dirs = new List<STPluginDirectoryDto>();
            var ids = new List<string>();
            //获取指定字典以及父级节点的所有文件夹和文件
            enums.Reverse();
            foreach (var item in enums)
            {
                ids.Add(item.Id);
                dic.Add(item.Code, new STPluginDirectoryDto { Id = item.Id, Name = item.Name, FolderType = FolderType.Parent });
            }

            var list = _repositoryFolder.GetAllList(s => ids.Contains(s.ExtendId));
            if (list != null && list.Count > 0)
            {
                var a = list.Where(s => s.ExtendId.Equals(ids[0]) && !string.IsNullOrWhiteSpace(s.FileId)).ToList();
                var b = list.Except(a).ToList();
                var c = b.Where(s => !string.IsNullOrWhiteSpace(s.FileId)).Select(s => s.Name);
                a.RemoveAll(s => c.Contains(s.Name));
                all.AddRange(a);
                all.AddRange(b);
            }
            //过滤出文件 
            var filterFiles = all.Where(s => !string.IsNullOrWhiteSpace(s.FileId)).OrderByDescending(s => s.CreationTime);

            //按文件父节点分组以便组成父子节点
            var groups = filterFiles.GroupBy(s => s.ParentId);
            foreach (var group in groups)
            {
                var p = all.Find(s => s.Id.Equals(@group.Key));
                if (p == null) continue;

                var temp = dirs.Find(s => s.Id.Equals(p.Id));
                var a = temp ?? new STPluginDirectoryDto { Id = p.Id, Name = p.Name, ParentId = p.ParentId };

                foreach (var s in @group)
                    a.Children.Add(new STPluginDirectoryDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        FileSize = s.FileSize,
                        HashCode = s.HashCode,
                        FileId = s.Id,
                        ParentId = s.ParentId,
                        Path = s.FilePath,
                        CreationTime = s.CreationTime
                    });
                //向上查找当前节点的父级节点
                GetParent(a, dirs, all);
            }

            //装配所有字典节点的子节点
            foreach (var dir in dic)
            {
                foreach (var dto in dirs.FindAll(s => s.ParentId.Equals(dir.Value.Id)).Where(dto => !dir.Value.Children.Contains(dto)))
                {
                    if (dir.Value.Children.Contains(dto)) continue;
                    dir.Value.Children.Add(dto);
                }

                var files = filterFiles.Where(s => s.ParentId.Equals(dir.Value.Id)).Select(s => new STPluginDirectoryDto()
                { Id = s.Id, Name = s.Name, FileSize = s.FileSize, HashCode = s.HashCode, FileId = s.Id, Path = s.FilePath, CreationTime = s.CreationTime });

                foreach (var file in files)
                {
                    if (dir.Value.Children.Contains(file)) continue;
                    dir.Value.Children.Add(file);
                }
            }

            return dic;
        }

        /// <summary>
        /// 向上查找当前节点的父级节点
        /// </summary>
        /// <param name="current"></param>
        /// <param name="parent"></param>
        /// <param name="all"></param>
        private void GetParent(STPluginDirectoryDto current, List<STPluginDirectoryDto> parent, List<STPluginFolder> all)
        {
            var a = parent.Find(s => s.Id.Equals(current.ParentId));
            if (a == null)
            {
                var p = all.Find(s => s.Id.Equals(current.ParentId));
                if (p == null)
                {
                    if (!parent.Contains(current))
                        parent.Add(current);

                    return;
                }
                a = new STPluginDirectoryDto { Id = p.Id, Name = p.Name, ParentId = p.ParentId };
                if (!parent.Any(s => s.Id.Equals(a.Id)))
                    parent.Add(a);
            }
            if (!a.Children.Contains(current))
                a.Children.Add(current);

            GetParent(a, parent, all);
        }

        /// <summary>
        /// 组合成父子结构
        /// </summary>
        /// <param name="prev"></param>
        /// <param name="enums"></param>
        /// <param name="dic"></param>
        private void GetChild(STPluginDirectoryDto prev, List<AbpCustomEnum> enums, Dictionary<string, STPluginDirectoryDto> dic)
        {
            var info = enums.Find(s => s.ParentId.Equals(prev.Id));
            if (info == null) return;

            GetChild(dic[info.Code], enums, dic);

            if (!prev.Children.Contains(dic[info.Code]))
                prev.Children.Add(dic[info.Code]);
        }

        /// <summary>
        /// 向上查找字典数据上级
        /// </summary>
        /// <param name="enums"></param>
        /// <param name="current"></param>
        /// <param name="code"></param>
        private void GetSuperior(List<AbpCustomEnum> enums, AbpCustomEnum current, string code)
        {
            if (current.Code.Equals(code)) return;
            var info = _repositoryEnum.Get(current.ParentId);
            enums.Add(info);
            GetSuperior(enums, info, code);
        }

        /// <summary>
        /// 设置版本号
        /// </summary>
        /// <param name="input"></param>
        /// <param name="model"></param>
        private void SetVersion(STPluginFileVersionDto input, out STPluginFileVersion model)
        {
            model = Repository.GetAll().Where(s => s.FolderId.Equals(input.FolderId))
               .OrderByDescending(s => s.CreationTime).FirstOrDefault();

            var now = DateTime.Now.ToString("yyyy.MM.dd");
            if (model == null)
            {
                input.Version = $"{now}.01";
            }
            else
            {
                var index = model.Version.LastIndexOf('.');
                var date = model.Version.Substring(0, index);
                var num = model.Version.Substring(index + 1);
                input.Version = date.Equals(now) ? $"{date}.{(Convert.ToInt32(num) + 1).ToString().PadLeft(2, '0')}" : $"{now}.01";
            }
        }

        public override Task<ListResultDto<STPluginFileVersionDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = Repository.GetAll().WhereIf(!key.IsNullOrWhiteSpace(), s => s.FolderId.Equals(key)).Where(s => s.OrgId == orgId).OrderByDescending(s => s.CreationTime).ToList();
            var dto = ObjectMapper.Map<List<STPluginFileVersionDto>>(list);
            return Task.FromResult(new ListResultDto<STPluginFileVersionDto>(dto));
        }

        public async Task<string> GetFileListAsync(string id)
        {
            var info = await Repository.GetAsync(id);
            return info.JsonText;
        }

        [HttpPost]
        public async Task<bool> RollbackVersionAsync(dynamic data)
        {
            string id = data.id, version = data.version, terminalIds = data.terminalIds, pluginId = data.pluginId;
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(version) ||
                string.IsNullOrWhiteSpace(terminalIds) || string.IsNullOrWhiteSpace(pluginId))
                throw new UserFriendlyException("参数不能为空");

            var ids = terminalIds.Split(',');
            var plugins = await _repositoryPlugin.GetAllListAsync(s => ids.Contains(s.TermianlId) && s.PluginId.Equals(pluginId));
            if (plugins.Count == 0) return false;

            foreach (var plugin in plugins)
            {
                plugin.VersionId = id;
                plugin.Version = version;
                await _repositoryPlugin.UpdateAsync(plugin);
            }
            return true;
        }

        /// <summary>
        /// 根据节点删除版本号
        /// </summary> 
        public override async Task DeleteByIds(dynamic data)
        {
            string ids = data.ids;
            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"参数{nameof(ids)}不能为空");

            var orgId = long.TryParse((string)data.orgId, out var o) ? o : 0;
            //删除模板和终端版本数据
            var v = await Repository.GetAllListAsync(s => s.FolderId.Equals(ids) && s.OrgId == orgId);
            var versions = v.Select(s => s.Id);

            var p = await _repositoryPlugin.GetAllListAsync(s => versions.Contains(s.VersionId));
            var t = await _repositoryTPlugin.GetAllListAsync(s => versions.Contains(s.VersionId));

            var plugins = p.Select(s => s.Id);
            var tplugins = t.Select(s => s.Id);

            var terminals = p.Select(s => s.TermianlId).Distinct();
            var templates = t.Select(s => s.TemplateId).Distinct();

            var pluginCode = p.FirstOrDefault()?.PluginCode.ToLower();
            var port = !string.IsNullOrWhiteSpace(pluginCode) && PluginPorts.ContainsKey(pluginCode) ? PluginPorts[pluginCode] : 0;

            await _repositoryPluginNet.DeleteAsync(s => plugins.Contains(s.PluginId));
            await _repositoryTPluginNet.DeleteAsync(s => tplugins.Contains(s.PluginId));
            await _repositoryPlugin.DeleteAsync(s => versions.Contains(s.VersionId));
            await _repositoryTPlugin.DeleteAsync(s => versions.Contains(s.VersionId));

            await Repository.DeleteAsync(s => s.FolderId.Equals(ids) && s.OrgId == orgId);

            //生成空版本 
            await CreateEmptyVersion(v, terminals, templates, port);
        }

        private async Task CreateEmptyVersion(List<STPluginFileVersion> v, IEnumerable<string> terminals, IEnumerable<string> templates, int port)
        {
            if (v.Count == 0) return;

            var info = ObjectMapper.Map<STPluginFileVersionDto>(v.LastOrDefault());
            var dir = info.JsonText.FromJsonString<STPluginDirectoryDto>();
            if (dir != null) dir.Children = null;
            info.JsonText = dir?.ToJsonString(true);
            info.PluginName = dir?.Name;
            info.TerminalIds = terminals.ToArray();
            info.TemplateIds = templates.ToArray();
            info.CreationTime = DateTime.Now;
            info.Port = port;
            info.Remark = "系统自动生成，用于向下兼容。";

            //设置版本号
            SetVersion(info, out var oldVersion);

            var m = await base.CreateAsync(info);

            await AddTerminalPlugin(info, m);
            await AddTemplatePlugin(info, m);
        }
    }
}
