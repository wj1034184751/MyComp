using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.EntityFrameworkCore;
using YuanTu.Platform.ST;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.StFuncConfigs
{
    public class StTerminalFuncConfigAppService : AsynPermissionAppService<StTerminalFuncConfig, StTerminalFuncConfigDto, string, PagedStTerminalFuncConfigRequestDto, StTerminalFuncConfigDto, StTerminalFuncConfigDto>, IStTerminalFuncConfigAppService
    {
        IRepository<StFuncConfig, string> RepositoryStFuncConfig = null;
        IRepository<STTerminal, string> RepositoryStTerminal = null;
        IDbContextProvider<PlatformDbContext> _db = null;

        public StTerminalFuncConfigAppService(IRepository<StTerminalFuncConfig, string> repository
            , IRepository<StFuncConfig, string> repositoryStFuncConfig
            , IRepository<STTerminal, string> repositoryStTerminal
            , IDbContextProvider<PlatformDbContext> db) : base(repository)
        {
            this.RepositoryStFuncConfig = repositoryStFuncConfig;
            this.RepositoryStTerminal = repositoryStTerminal;
            _db = db;
        }

        protected override IQueryable<StTerminalFuncConfig> CreateFilteredQuery(PagedStTerminalFuncConfigRequestDto input)
        {
            input.Sorting = " Sort";
            return this.Repository.GetAll()
                .Where(v => string.IsNullOrEmpty(v.ParentId));
        }

        public async override Task DeleteAsync(EntityDto<string> input)
        {
            var item = await base.GetEntityByIdAsync(input.Id);

            await this.Repository.DeleteAsync(v => v.LevelCode.StartsWith(item.LevelCode));
        }

        public async Task<ListResultDto<StTerminalFuncConfigDto>> GetTreeData(TreeStTerminalFuncConfigRequestDto input)
        {
            List<StTerminalFuncConfig> res = new List<StTerminalFuncConfig>();
            if (string.IsNullOrEmpty(input.Pid))
            {
                throw new UserFriendlyException("终端未设置，获取节点失败");
            }
            else
            {
                res = await this.Repository.GetAllListAsync(v => v.TerminalId == input.Pid);
            }

            return new ListResultDto<StTerminalFuncConfigDto>(ObjectMapper.Map<List<StTerminalFuncConfigDto>>(res.OrderBy(v => v.Sort)));
        }

        //public override Task<StTerminalFuncConfigDto> CreateAsync(StTerminalFuncConfigDto input)
        //{
        //    // 设置层级码
        //    if (!input.IsUnique)
        //    {
        //        var roots = this.Repository.GetAllList(v => v.LevelCode.StartsWith("0000"));
        //        if (roots.Count == 0)
        //        {
        //            throw new UserFriendlyException("请先维护全局模板!");
        //        }

        //        var levelcode = string.Empty;

        //        if (!string.IsNullOrEmpty(input.ParentId))
        //        {
        //            var parent = this.Repository.Get(input.ParentId);
        //            if (parent != null)
        //            {
        //                levelcode = parent.LevelCode;
        //            }
        //            else
        //            {
        //                input.ParentId = string.Empty;
        //            }
        //        }

        //        var maxcode = string.Empty;

        //        if (string.IsNullOrEmpty(input.ParentId))
        //        {
        //            maxcode = this.Repository.GetAll().Where(v => string.IsNullOrEmpty(v.ParentId)).Max(v => v.LevelCode);
        //        }
        //        else
        //        {
        //            maxcode = this.Repository.GetAll().Where(v => v.ParentId == input.ParentId).Max(v => v.LevelCode);
        //        }

        //        if (string.IsNullOrEmpty(maxcode))
        //            maxcode = "0000";

        //        maxcode = maxcode.Substring(maxcode.Length - 4);

        //        input.LevelCode = levelcode + (int.Parse(maxcode) + 1).ToString().PadLeft(4, '0');

        //        // 判断是否新增模板
        //        if (string.IsNullOrEmpty(input.ParentId))
        //        {
        //            input.Id = Guid.NewGuid().ToString("N");

        //            var list = MapperUtil.Mapper<List<StTerminalFuncConfig>>(roots);

        //            var root = list.FirstOrDefault(v => string.IsNullOrEmpty(v.ParentId));

        //            list.Remove(root);

        //            input.ReferUniqueId = root.Id;

        //            var children = list.Where(v => v.ParentId == root.Id).ToList();

        //            for (var pp = 0; pp < children.Count; pp++)
        //            {
        //                var child = children[pp];
        //                child.ParentId = input.Id;
        //            }

        //            // 自动导入全局模板
        //            for (var p = 0; p < list.Count; p++)
        //            {
        //                var item = list[p];

        //                var key = Guid.NewGuid().ToString("N");
        //                children = list.Where(v => v.ParentId == item.Id).ToList();

        //                for (var pp = 0; pp < children.Count; pp++)
        //                {
        //                    var child = children[pp];
        //                    child.ParentId = key;
        //                }

        //                item.ReferUniqueId = item.Id;
        //                item.LevelCode = input.LevelCode + item.LevelCode.Substring(4);
        //                item.Id = key;
        //            }

        //            foreach (var item in list)
        //            {
        //                base.Repository.Insert(item);
        //            }
        //        }
        //    }

        //    return base.CreateAsync(input);
        //}

        /// <summary>
        /// 同步模板
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<bool> Apply(ApplyDto dto)
        {
            Write("begin");
            // 获取前端模板
            var source = RepositoryStFuncConfig.GetAll().Where(v => v.LevelCode.StartsWith(dto.LevelCode)).OrderBy(v => v.LevelCode).ToList();

            var updates = new List<StTerminalFuncConfig>();
            var inserts = new List<StTerminalFuncConfig>();
            var deletes = new List<StTerminalFuncConfig>();

            foreach (var terminalId in dto.TerminalIds)
            {
                Write($"{terminalId} in");

                SyncData(source, dto.LevelCode, terminalId, deletes, updates, inserts);

                Write($"{terminalId} out");
            }

            Write("end");

            _db.GetDbContext().BulkUpdate(updates);

            _db.GetDbContext().BulkInsert(inserts);

            _db.GetDbContext().BulkDelete(deletes);

            return await Task.FromResult(true);
        }

        void Write(string content)
        {
            //File.AppendAllText("db.log", $"{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffffff")} {content}\r\n");
        }

        /// <summary>
        /// 同步全局模板
        /// </summary>
        /// <param name="source"></param>
        /// <param name="levelcode"></param>
        private void SyncData(List<StFuncConfig> source, string levelcode, string terminalId, List<StTerminalFuncConfig> deletes, List<StTerminalFuncConfig> updates, List<StTerminalFuncConfig> inserts)
        {
            var rootId = source.FirstOrDefault(v => string.IsNullOrEmpty(v.ParentId)).Id;

            Write($"{terminalId} in get");
            var targets = Repository.GetAll().Where(v => v.TerminalId == terminalId).ToList();
            Write($"{terminalId} out get");

            var exits = targets.ToList();

            // 应用不同模板前删除前模板
            if (targets.Count > 0 && targets.Count(v => v.ReferRootId != rootId) > 0)
            {
                //this.Repository.HardDeleteAsync(v => v.TerminalId == terminalId);

                deletes.AddRange(targets);
                
                Write($"{terminalId} in update stfuncConfigId");

                RepositoryStTerminal.Update(terminalId, (s) => { s.StFuncConfigId = rootId; });

                Write($"{terminalId} out update stfuncConfigId");
                targets = new List<StTerminalFuncConfig>();
            }
            else
            {
                if (targets.Count == 0)
                {
                    RepositoryStTerminal.Update(terminalId, (s) => { s.StFuncConfigId = rootId; });
                }

                // 移除无效明细
                foreach (var target in exits)
                {
                    bool exist = false;
                    foreach (var item in source)
                    {
                        if (target.ReferSourceId == item.Id)
                        {
                            exist = true;
                            break;
                        }
                    }

                    if (!exist)
                    {
                        Write($"{terminalId} in delete stterminalfuncConfigId");

                        //await this.Repository.HardDeleteAsync(v => v.Id == target.Id);

                        deletes.Add(target);

                        Write($"{terminalId} out delete stterminalfuncConfigId");

                        targets.Remove(target);
                    }
                }
            }

            Write($"{terminalId} in update&insert stterminalfuncConfigId");

            foreach (var item in source)
            {
                bool isExist = false;
                StTerminalFuncConfig one = new StTerminalFuncConfig();
                one.Id = Guid.NewGuid().ToString("N");

                foreach (var target in targets)
                {
                    if (item.Id == target.ReferSourceId)
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
                one.ReferUniqueId = item.ReferUniqueId;
                one.ReferParentUniqueId = item.ReferParentUniqueId;
                one.ReferRootId = rootId;
                one.TerminalId = terminalId;
                one.LevelCode = item.LevelCode;

                // 判定是否覆盖模式
                if (item.SyncMode || item.ReadOnly == 2)
                {
                    one.Value = item.Value;
                }

                if (!isExist)
                {
                    var target = targets.Where(v => v.ReferSourceId == item.ParentId).FirstOrDefault();
                    if (target != null)
                    {
                        one.ParentId = target.Id;
                    }

                    one.ReferSourceId = item.Id;

                    one.Value = item.Value;

                    inserts.Add(one);

                    targets.Add(one);
                }
                else
                {
                    if ((one.LastModificationTime ?? one.CreationTime) < (item.LastModificationTime ?? item.CreationTime))
                    {
                        // 更新层级码
                        one.LevelCode = one.LevelCode.Substring(0, 4) + item.LevelCode.Substring(4);
                        //await Repository.UpdateAsync(one);

                        // 判断结构是否发生变化
                        if (one.ReferParentUniqueId != item.ReferParentUniqueId)
                        {
                            one.ParentId = targets.FirstOrDefault(v => v.ReferUniqueId == item.ReferParentUniqueId).Id;
                        }

                        updates.Add(one);
                    }
                }
            }

            Write($"{terminalId} out update&insert stterminalfuncConfigId");
        }

        /// <summary>
        /// 同步模板
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<bool> SaveConfig(List<StTerminalFuncConfig> list)
        {
            foreach (var one in list)
            {
                await Repository.UpdateAsync(one);
            }

            return true;
        }

        /// <summary>
        /// 下载设备功能模板
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<List<StTerminalFuncConfig>> GetAllByTerminalId(string terminalId)
        {
            // 获取全局模板
            return await Task.FromResult(this.Repository.GetAll().Where(v => v.TerminalId == terminalId).OrderBy(v => v.LevelCode).ToList());
        }
    }
}
