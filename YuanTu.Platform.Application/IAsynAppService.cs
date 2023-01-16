using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using YuanTu.Platform.Sys.CustomEnums.Dto;

namespace YuanTu.Platform
{
    public interface IAsynAppService<TEntityDto, TPrimaryKey> where TEntityDto : IEntityDto<TPrimaryKey>
    {
        Task<ListResultDto<TEntityDto>> GetAllListAsync();
        Task<ListResultDto<TEntityDto>> GetAllByKey(string key, long orgId);
        Task DeleteByIds(dynamic data);
    }
}