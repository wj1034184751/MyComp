using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories; 
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Parts;
using YuanTu.Platform.Parts.Dto;
using YuanTu.Platform.Sys;

namespace YuanTu.Platform.ST
{
    [AbpAuthorize]
    public class STCardReaderAppService : AsynPermissionAppService<STCardReader, STCardReaderDto, string, PagedSTCardReaderRequestDto, STCardReaderDto, STCardReaderDto>, ISTCardReaderAppService
    {
        private readonly IRepository<AbpAttachment, string> _repositoryAttachment;
        public STCardReaderAppService(IRepository<STCardReader, string> repository, IRepository<AbpAttachment, string> repositoryAttachment) : base(repository)
        {
            _repositoryAttachment = repositoryAttachment;
        }

        protected override IQueryable<STCardReader> CreateFilteredQuery(PagedSTCardReaderRequestDto input)
        {
            var list = Repository.GetAll().WhereIf(!input.Keyword.IsNullOrWhiteSpace(),
                x => x.Code.Contains(input.Keyword) || x.Name.Contains(input.Keyword)); 
            return list;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<STCardReaderDto>> GetAllAsync(PagedSTCardReaderRequestDto input)
        {
            var m = await base.GetAllAsync(input);
            foreach (var s in m.Items)
                s.Attachments = ObjectMapper.Map<List<AbpAttachmentDto>>(_repositoryAttachment.GetAllList(t => t.ExtendId.Equals(s.Id)));
            return m;
        }

        public override async Task<STCardReaderDto> CreateAsync(STCardReaderDto input)
        {
            try
            {
                var model = ObjectMapper.Map<STCardReader>(input);
                model.Id = input.Id = CreateSequentialGuid();

                if (input.Attachments != null && input.Attachments.Count > 0)
                {
                    foreach (var detail in input.Attachments)
                    {
                        detail.Id = CreateSequentialGuid();
                        detail.ExtendId = model.Id;
                        await _repositoryAttachment.InsertAsync(ObjectMapper.Map<AbpAttachment>(detail));
                    }
                }

                await Repository.InsertAsync(model);
                return input;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                throw;
            }
        }

        public override async Task<STCardReaderDto> UpdateAsync(STCardReaderDto input)
        {
            try
            {
                var model = await Repository.FirstOrDefaultAsync(s => s.Id.Equals(input.Id));
                MapToEntity(input, model);

                var details = input.Attachments?.Select(s =>
                {
                    s.Id = CreateSequentialGuid();
                    return s;
                }).ToList(); 

                await _repositoryAttachment.DeleteAsync(s => s.ExtendId.Equals(model.Id));

                details?.ForEach(async s => await _repositoryAttachment.InsertAsync(ObjectMapper.Map<AbpAttachment>(s)));

                await Repository.UpdateAsync(model);

                return MapToEntityDto(model);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                throw;
            }
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            await _repositoryAttachment.DeleteAsync(s => s.ExtendId.Equals(input.Id));
            await base.DeleteAsync(input);
        }
    }
}