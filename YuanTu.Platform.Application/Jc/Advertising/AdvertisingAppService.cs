using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Jc.Advertising.Dto;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.Jc
{
    public class AdvertisingAppService : AsynPermissionAppService<Jc_Advertising, AdvertisingDto, string, ParentCustomPagedAndSortedWithOrgDto, AdvertisingDto, AdvertisingDto>, IAdvertisingAppService
    {
        private readonly IRepository<Jc_Advertising, string> _repositoryAdvertising;
        private readonly IRepository<Jc_AdvertisingCatalog, string> _repositoryAdvertisingCatalog;
        private readonly IRepository<Jc_Advertising_Terminal, string> _repositoryAdvertisingTerminal;
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;

        public AdvertisingAppService(IRepository<Jc_Advertising, string> repository,
            IRepository<Jc_AdvertisingCatalog, string> repositoryAdvertisingCatalog,
            IRepository<Jc_Advertising_Terminal, string> repositoryAdvertisingTerminal,
            IRepository<STTerminal, string> repositorySTTerminal) : base(repository)
        {
            this._repositoryAdvertising = repository;
            this._repositoryAdvertisingCatalog = repositoryAdvertisingCatalog;
            this._repositoryAdvertisingTerminal = repositoryAdvertisingTerminal;
            this._repositorySTTerminal = repositorySTTerminal;
        }

        protected override IQueryable<Jc_Advertising> CreateFilteredQuery(ParentCustomPagedAndSortedWithOrgDto input)
        {
            input.Sorting = "  Sort ASC";

            return _repositoryAdvertising.GetAll()
                .Where(v => v.Jc_AdvertisingCatalogId == input.Mid)
                .WhereIf(!input.Keyword.IsNullOrWhiteSpace(), x => x.Caption.Contains(input.Keyword));
        }


        [ActionName("GetPage")]
        public override async Task<PagedResultDto<AdvertisingDto>> GetAllAsync(ParentCustomPagedAndSortedWithOrgDto input)
        {
            input.Sorting = "  Sort ASC";
            // input.IsActive ??= true;
            var list = await base.GetAllAsync(input);

            SetTerminal(input, list);

            return list;
        }

        private void SetTerminal(ParentCustomPagedAndSortedWithOrgDto input, PagedResultDto<AdvertisingDto> list)
        {

            foreach (var item in list.Items)
            {
                item.TerminalIds = new string[] { };
                item.TerminalCodes = new string[] { };
                if (item.IsAllMedium) continue;
                var list1 = _repositoryAdvertisingTerminal.GetAll().Where(c => c.Jc_AdvertisingId == item.Id).ToList();
                if (list1 == null || list1.Count == 0) continue;
                item.TerminalIds = list1.Select(c => c.StTerminalId).ToArray();

                var list2 = _repositorySTTerminal.GetAll().Where(c => item.TerminalIds.Contains(c.Id)).ToList();
                if (list2 == null || list2.Count == 0) continue;
                item.TerminalCodes = list2.Select(c => c.Code).ToArray();
            }
        }


        [AbpAllowAnonymous]
        public override Task<AdvertisingDto> CreateAsync(AdvertisingDto input)
        {
            var ret= base.CreateAsync(input);

            if (!input.IsAllMedium && input.TerminalIds!=null && input.TerminalIds.Length>0)
            {
                foreach(var item in input.TerminalIds)
                {
                    _repositoryAdvertisingTerminal.Insert(new Jc_Advertising_Terminal
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        StTerminalId=item,
                        Jc_AdvertisingId=input.Id
                    });
                }
            }

            return ret;
        }

        [AbpAllowAnonymous]
        [HttpPost, HttpPut]
        public override async Task<AdvertisingDto> UpdateAsync([FromBody] AdvertisingDto input)
        {
            if (string.IsNullOrWhiteSpace(input.Id)) throw new UserFriendlyException($"参数{nameof(input.Id)}为空");
            var model = await Repository.GetAsync(input.Id);
            if (model == null) throw new UserFriendlyException("数据异常，无此数据，无法执行更新");
            model.Caption = input.Caption;
            model.SndCaption = input.SndCaption;
            model.Summary = input.Summary;
            model.Content = input.Content;
            model.IsAllMedium = input.IsAllMedium;
            model.IsTop = input.IsTop;
            model.Printable = input.Printable;
            model.Downloadable = input.Downloadable;
            model.Sort = input.Sort;
            model.AttachmentType = input.AttachmentType;
            model.AttachmentTypeId = input.AttachmentTypeId;
            model.AttachmentUrl = input.AttachmentUrl;

            var m = await Repository.UpdateAsync(model);

            var list = _repositoryAdvertisingTerminal.GetAll().Where(c => c.Jc_AdvertisingId == input.Id).ToList();
            if (list.Count > 0)
            {
                foreach(var item in list)
                {
                    _repositoryAdvertisingTerminal.Delete(item);
                }
            }

            if (!input.IsAllMedium && input.TerminalIds.Length > 0)
            {
                foreach (var item in input.TerminalIds)
                {
                    _repositoryAdvertisingTerminal.Insert(new Jc_Advertising_Terminal
                    {
                        Id = Guid.NewGuid().ToString("N"),
                        StTerminalId = item,
                        Jc_AdvertisingId = input.Id
                    });
                }
            }

            return MapToEntityDto(m);
        }
    }
}
