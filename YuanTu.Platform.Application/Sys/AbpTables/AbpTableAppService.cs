using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Sys.AbpTables.Dto; 

namespace YuanTu.Platform.Sys.AbpTables
{
    [AbpAuthorize]
    public class AbpTableAppService : AsynPermissionAppService<AbpTable, AbpTableDto, string, PagedAbpTableRequestDto, AbpTableDto, AbpTableDto>, IAbpTableAppService
    {
        IRepository<AbpColumn, string> RepositoryAbpColumn { get; set; }
        public AbpTableAppService(IRepository<AbpTable, string> repository,
            IRepository<AbpColumn, string> repositoryColumn)
            : base(repository)
        {
            this.RepositoryAbpColumn = repositoryColumn;
        }

        public override Task<AbpTableDto> CreateAsync(AbpTableDto input)
        {
            return base.CreateAsync(input);
        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<AbpTableDto>> GetAllAsync(PagedAbpTableRequestDto input)
        {
            input.MaxResultCount = int.MaxValue;
            input.Sorting = "Sort";
            return base.GetAllAsync(input);
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<AbpTableDto>> GetAllListAsync()
        {
            var list = await base.GetAllListAsync();
            return new ListResultDto<AbpTableDto>(list.Items.OrderBy(s => s.Sort).ToList());
        }

        public override Task DeleteAsync(EntityDto<string> input)
        {
            RepositoryAbpColumn.Delete(v => v.AbpTableId == input.Id);

            return base.DeleteAsync(input);
        }
    }
}