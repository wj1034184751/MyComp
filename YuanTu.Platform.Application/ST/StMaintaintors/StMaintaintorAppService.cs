using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using YuanTu.Platform.StMaintains;

namespace YuanTu.Platform.ST
{
    public class StMaintaintorAppService : AsynPermissionAppService<StMaintaintor, StMaintaintorDto, string, PagedStMaintaintorRequestDto, StMaintaintorDto, StMaintaintorDto>, IStMaintaintorAppService
    {
        public StMaintaintorAppService(IRepository<StMaintaintor, string> repository) : base(repository)
        {

        }

        [AbpAllowAnonymous]
        [HttpPost, HttpPut]
        public Task<bool> CheckExits(CheckStMaintaintorDto dto)
        {
            if (!dto.IdNo.IsNullOrWhiteSpace())
            {
                var count = Repository.GetAll().Where(v => v.IdNo == dto.IdNo).Count();

                if (count > 0)
                {
                    return Task.FromResult(true);
                }
            }

            if (!dto.Qrcode.IsNullOrWhiteSpace())
            {
                var count = Repository.GetAll().Where(x => x.IdNo == dto.Qrcode || x.CardNo == dto.Qrcode || x.Password == dto.Qrcode || x.PatientId == dto.Qrcode).Count();

                if (count > 0)
                {
                    return Task.FromResult(true);
                }
            }

            if (!dto.PatientId.IsNullOrWhiteSpace())
            {
                var count = Repository.GetAll().Where(x => x.PatientId == dto.PatientId).Count();

                if (count > 0)
                {
                    return Task.FromResult(true);
                }
            }

            if (!dto.Password.IsNullOrWhiteSpace())
            {
                var count = Repository.GetAll().Where(x => x.Password == dto.Password).Count();

                if (count > 0)
                {
                    return Task.FromResult(true);
                }
            }

            if (!dto.CardNo.IsNullOrWhiteSpace())
            {
                var count = Repository.GetAll().Where(x => x.CardNo == dto.CardNo).Count();

                if (count > 0)
                {
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(false);
        }
    }
}