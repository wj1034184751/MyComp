using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YuanTu.Platform.SN.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.SN
{
    [AbpAuthorize]
    public class STSerialNoAppService : AsynPermissionAppService<STSerialNo, STSerialNoDto, string, PagedSTSerialNoRequestDto, STSerialNoDto, STSerialNoDto>, ISTSerialNoAppService
    {
        private readonly IRepository<STNameplate, string> _stNameplateRepository;
        public STSerialNoAppService(IRepository<STSerialNo, string> repository, IRepository<STNameplate, string> stNameplateRepository) : base(repository)
        {
            _stNameplateRepository = stNameplateRepository;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<STSerialNoDto>> GetAllAsync(PagedSTSerialNoRequestDto input)
        {
            var result = new List<STSerialNoDto>();
            var list = _stNameplateRepository.GetAll()
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                    x => x.Code.Equals(input.Keyword) || x.Name.Contains(input.Keyword))
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId).Join(
                    Repository.GetAll()
                        .WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                            x => x.SerialNo.Equals(input.Keyword))
                        .WhereIf(!input.TerminalTypeId.IsNullOrWhiteSpace(),
                            x => x.TerminalTypeId.Equals(input.TerminalTypeId))
                        .WhereIf(input.Status.HasValue,
                            x => x.Status == input.Status.Value), x => x.Id, s => s.NameplateId,
                    (x, s) => new { s, x.Code, x.Name, x.OrgId })
                .OrderBy(s => s.Code).ThenBy(s => s.s.SerialNo);

            var totalCount = await list.CountAsync();
            var pagedList = list.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            foreach (var info in pagedList)
            {
                var m = MapToEntityDto(info.s);
                m.OrgId = info.OrgId;
                m.NameplateCode = info.Code;
                m.NameplateName = info.Name;
                result.Add(m);
            }

            var dto = new PagedResultDto<STSerialNoDto>(totalCount, ObjectMapper.Map<List<STSerialNoDto>>(result));

            return dto;
        }

        public override Task<ListResultDto<STSerialNoDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = Repository.GetAll().WhereIf(!string.IsNullOrWhiteSpace(key), s => s.NameplateId.Equals(key)).Where(s => s.OrgId == orgId).ToList();
            return Task.FromResult(new ListResultDto<STSerialNoDto>(ObjectMapper.Map<List<STSerialNoDto>>(list)));
        }

        [HttpPost]
        public async Task<bool> UpdateStatus(dynamic data)
        {
            string ids = data.ids;
            string status = data.status;

            if (string.IsNullOrWhiteSpace(ids))
                throw new UserFriendlyException($"{nameof(ids)}不能为空");

            var arr = ids.Split(',');
            foreach (var s in arr)
            {
                var m = await Repository.GetAsync(s);
                m.Status = "1".Equals(status);
                await Repository.UpdateAsync(m);
            }

            return true;
        }

        [HttpPost]
        public async Task<bool> UpdateDeliveryStatus(dynamic data)
        {
            string type = data.type;
            string pid = data.pid;
            string status = data.status;
            string sync = data.sync;//是否同步更新项目状态 1-更新

            if (string.IsNullOrWhiteSpace(type))
                throw new UserFriendlyException($"{nameof(type)}不能为空");
            if (string.IsNullOrWhiteSpace(pid))
                throw new UserFriendlyException($"{nameof(pid)}不能为空");

            var arr = type.Split(',');
            var list = await Repository.GetAllListAsync(s => s.NameplateId.Equals(pid));
            var filter = list.FindAll(s => arr.Contains(s.TerminalTypeId));
            foreach (var m in filter)
            {
                m.DeliveryStatus = byte.TryParse(status, out var b) ? b : (byte)0;
                await Repository.UpdateAsync(m);
            }

            if ("1".Equals(sync))
            {
                var m = await _stNameplateRepository.GetAsync(pid);
                m.DeliveryStatus = list.Count(s => s.DeliveryStatus == 0) == list.Count ? (byte)0 : (list.Count(s => s.DeliveryStatus == 1) == list.Count ? (byte)1 : (byte)2);
            }

            return true;
        }

        [HttpPost]
        public async Task<bool> UpdateOrgId(dynamic data)
        {
            string ids = data.ids;
            string nameplateId = data.namepalteId;

            if (string.IsNullOrWhiteSpace(ids)) throw new UserFriendlyException($"{nameof(ids)}不能为空");
            if (string.IsNullOrWhiteSpace(nameplateId)) throw new UserFriendlyException($"{nameof(nameplateId)}不能为空");

            var arr = ids.Split(',');
            var list = await Repository.GetAllListAsync(s => arr.Contains(s.Id));
            foreach (var s in list)
            {
                s.NameplateId = nameplateId;
                await Repository.UpdateAsync(s);
            }

            return true;
        }

        public async Task<int> GetStartNum()
        {
            var dt = DateTime.Now;
            var list = await Repository.GetAllListAsync(s => s.OrderDate.Year == dt.Year && s.OrderDate.Month == dt.Month);
            var max = list.OrderByDescending(s => s.StartNum).FirstOrDefault()?.StartNum;
            var count = list.Count(s => s.StartNum.Equals(max));
            return (int.TryParse(max, out var n) ? n : 1) + count;
        }

        [AbpAllowAnonymous]
        public async Task<PagedResultDto<STSerialNoExDto>> GetSnDetails(PagedSTSerialNoExRequestDto input)
        {
            var result = new List<STSerialNoExDto>();
            var list = _stNameplateRepository.GetAll()
                .WhereIf(!input.Code.IsNullOrWhiteSpace(),
                    x => x.Code.Equals(input.Code) || x.Name.Contains(input.Code))
                .Join(
                    Repository.GetAll(), x => x.Id, s => s.NameplateId,
                    (x, s) => new { s, x.Code, x.Name, x.OrgId })
                .OrderBy(s => s.Code).ThenBy(s => s.s.SerialNo);

            var totalCount = await list.CountAsync();
            var pagedList = list.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();
            foreach (var info in pagedList)
            {
                var m = ObjectMapper.Map<STSerialNoExDto>(info.s);
                m.NameplateCode = info.Code;
                m.NameplateName = info.Name;
                result.Add(m);
            }

            var dto = new PagedResultDto<STSerialNoExDto>(totalCount, ObjectMapper.Map<List<STSerialNoExDto>>(result));

            return dto;
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