using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using YuanTu.Platform.Dept;
using YuanTu.Platform.Dept.Dto;
using YuanTu.Platform.ST.Dto;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STTerminalDeptMapAppService : AsynPermissionAppService<STTerminalDeptMap, STTerminalDeptMapDto, string, PagedSTTerminalDeptMapRequestDto, STTerminalDeptMapDto, STTerminalDeptMapDto>, ISTTerminalDeptMapAppService
    {
        private readonly IRepository<AdDept, long> _repositoryAdDept;
        public STTerminalDeptMapAppService(IRepository<STTerminalDeptMap, string> repository, IRepository<AdDept, long> repositoryAdDept) : base(repository)
        {
            _repositoryAdDept = repositoryAdDept;
        }

        public async Task<bool> BatchAdd(List<STTerminalDeptMapDto> infos)
        {
            try
            {
                var terminalIds = infos.Select(s => s.TerminalId);
                await Repository.DeleteAsync(s => terminalIds.Contains(s.TerminalId));

                var list = ObjectMapper.Map<List<STTerminalDeptMap>>(infos);
                foreach (var entity in list)
                {
                    entity.Id = CreateSequentialGuid();
                    await Repository.InsertAsync(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                return false;
            }
        }

        public async Task<List<AdDeptDto>> GetDepts(string corpId)
        {
            var list = long.TryParse(corpId, out var ss)
                ? await _repositoryAdDept.GetAllListAsync(s => s.CorpId == ss)
                : await _repositoryAdDept.GetAllListAsync();
            return ObjectMapper.Map<List<AdDeptDto>>(list);
        }
    }
}