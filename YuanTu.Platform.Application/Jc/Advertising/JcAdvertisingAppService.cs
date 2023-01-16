
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Cash.Dto;
using System.Collections.Generic;
using YuanTu.Platform.Jc.Advertising.Dto;
using YuanTu.Platform.ST;
using Abp.Web.Models;

namespace YuanTu.Platform.Jc
{
    public class JcAdvertisingAppService : AsynPermissionAppService<Jc_Advertising, JcAdvertisingDto, string, PagedAdvertisingRequestDto, JcAdvertisingDto, JcAdvertisingDto>, IJcAdvertisingAppService
    {
        private readonly IRepository<Jc_Advertising, string> _repositoryAdvertising;
        private readonly IRepository<Jc_AdvertisingCatalog, string> _repositoryAdvertisingCatalog;
        private readonly IRepository<Jc_Advertising_Terminal, string> _repositoryAdvertisingTerminal;
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;
        public JcAdvertisingAppService(IRepository<Jc_Advertising, string> repository,
            IRepository<Jc_AdvertisingCatalog, string> repositoryAdvertisingCatalog,
            IRepository<Jc_Advertising_Terminal, string> repositoryAdvertisingTerminal,
            IRepository<STTerminal, string> repositorySTTerminal)
            : base(repository)
        {
            this._repositoryAdvertising = repository;
            this._repositoryAdvertisingCatalog = repositoryAdvertisingCatalog;
            this._repositoryAdvertisingTerminal = repositoryAdvertisingTerminal;
            this._repositorySTTerminal = repositorySTTerminal;
        }

        protected override IQueryable<Jc_Advertising> CreateFilteredQuery(PagedAdvertisingRequestDto input)
        {
            var terminalId = this._repositorySTTerminal.FirstOrDefault(c=>c.Code==input.TerminalCode)?.Id;
            if (string.IsNullOrEmpty(terminalId)) terminalId = string.Empty;

            var ids = this._repositoryAdvertisingTerminal.GetAll().Where(c => c.StTerminalId == terminalId).Select(c => c.Jc_AdvertisingId).ToArray();

            var catalogId = this._repositoryAdvertisingCatalog.FirstOrDefault(c => c.Code == input.CatalogCode)?.Id;
            if (string.IsNullOrEmpty(catalogId)) catalogId = string.Empty;
            input.Sorting = " Sort ASC";
            return _repositoryAdvertising.GetAll()
                .Where(c=>c.Jc_AdvertisingCatalogId==catalogId)
                .Where(c=>c.IsAllMedium || ids.Contains(c.Id));
        }

        [AbpAllowAnonymous]
        [ActionName("GetAll")]
        public override Task<ListResultDto<JcAdvertisingDto>> GetAllListAsync()
        {
            return base.GetAllListAsync();
        }

        [AbpAllowAnonymous]
        [ActionName("GetPage")]
        [DontWrapResult]
        public override Task<PagedResultDto<JcAdvertisingDto>> GetAllAsync(PagedAdvertisingRequestDto input)
        {
            return base.GetAllAsync(input);
        }
    }
}
