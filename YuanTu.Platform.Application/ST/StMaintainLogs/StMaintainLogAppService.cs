using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuanTu.Platform.Jc;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.ST.StMaintainLogs.Dto;
using YuanTu.Platform.StMaintains;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.ST
{
    public class StMaintainLogAppService : AsynPermissionAppService<StMaintainLog, StMaintainLogDto, string, PagedStMaintainLogRequestDto, StMaintainLogDto, StMaintainLogDto>, IStMaintainLogAppService
    {
        private readonly IRepository<StMaintaintor, string> _repositoryMaintaintor;
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;
        private readonly IRepository<Jc_UserEnum, string> _repositoryUserEnum;

        public StMaintainLogAppService(IRepository<StMaintainLog, string> repository,
            IRepository<StMaintaintor, string> repositoryMaintaintor,
            IRepository<STTerminal, string> repositorySTTerminal,
            IRepository<Jc_UserEnum, string> repositoryUserEnum) : base(repository)
        {
            this._repositoryMaintaintor = repositoryMaintaintor;
            this._repositorySTTerminal = repositorySTTerminal;
            this._repositoryUserEnum = repositoryUserEnum;
        }

        protected override IQueryable<StMaintainLog> CreateFilteredQuery(PagedStMaintainLogRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            IQueryable<StMaintainLog> list = Repository.GetAll()
                .WhereIf(!input.Name.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Name))
                .WhereIf(!input.OperateTypeId.IsNullOrWhiteSpace(), x => x.OperateTypeId.Contains(input.OperateTypeId))
                .WhereIf(!input.StartDate.IsNullOrWhiteSpace(), x => x.OperateTime >= Convert.ToDateTime(input.StartDate))
                .WhereIf(!input.EndDate.IsNullOrWhiteSpace(), x => x.OperateTime <= Convert.ToDateTime(input.EndDate).AddDays(1));

            return list;
        }

        [DontWrapResult]
        [AbpAllowAnonymous]
        public ExtranetResult<string> CreateLog(StMaintainLogCreateDto input)
        {
            if (string.IsNullOrEmpty(input.IdNo))
            {
                return ExtranetResult<string>.Fail(-1,"身份证不能为空");
            }
            if (string.IsNullOrEmpty(input.Name))
            {
                return ExtranetResult<string>.Fail(-1, "姓名不能为空");
            }
            var terminalId = "";
            var terminal = this._repositorySTTerminal.FirstOrDefault(c=>c.Code==input.TerminalCode);
            if (terminal != null) terminalId = terminal.Id;

            var maintaintor = this._repositoryMaintaintor.FirstOrDefault(c => c.IdNo == input.IdNo);
            if (maintaintor == null)
            {
                return ExtranetResult<string>.Fail(-1, "操作失败，没查到对应的身份证信息");
            }

            if (string.IsNullOrEmpty(maintaintor.Name))
            {
                return ExtranetResult<string>.Fail(-1, "操作失败，没有维护姓名信息");
            }

            if (!maintaintor.Name.Equals(input.Name))
            {
                return ExtranetResult<string>.Fail(-1, "操作失败，姓名不一致");
            }

            var log = new StMaintainLog
            {
                Id=Guid.NewGuid().ToString("N"),
                TerminalId = terminalId,
                TerminalCode = input.TerminalCode,
                OperateTime = DateTime.Now,
                StMaintaintorId = maintaintor.Id,
                Name = maintaintor.Name,
                IdNo = maintaintor.IdNo,
                CardNo = maintaintor.CardNo,
                Phone = maintaintor.Phone,
                PatientId = maintaintor.PatientId,
                SourceTypeId = "",
                OperateTypeId = input.OperateTypeId
            };

            var id= this.Repository.InsertAndGetId(log);

            if (string.IsNullOrEmpty(id))
            {
                return ExtranetResult<string>.Fail(-1, "操作失败，插入数据库数据");
            }
            return ExtranetResult<string>.Success("");
        }


        [HttpGet, AbpAllowAnonymous]
        public async Task<IActionResult> ExportTpl(string startDate,string endDate,string name,string operateTypeId)
        {
            var list = Repository.GetAll()
                .WhereIf(!name.IsNullOrWhiteSpace(), x => x.Name.Contains(name))
                .WhereIf(!operateTypeId.IsNullOrWhiteSpace(), x => x.OperateTypeId.Contains(operateTypeId))
                .WhereIf(!startDate.IsNullOrWhiteSpace(), x => x.OperateTime >= Convert.ToDateTime(startDate))
                .WhereIf(!endDate.IsNullOrWhiteSpace(), x => x.OperateTime <= Convert.ToDateTime(endDate).AddDays(1))
                .OrderByDescending(c=>c.CreationTime)
                .ToList();

            var list1 = new List<StMaintainLogExportDto>();

            var userEnums = this._repositoryUserEnum.GetAll().Where(c => c.PrefixCode == "SY.001").ToList();

            foreach(var item in list)
            {
                var operateTypeId1 = item.OperateTypeId;
                var enums = userEnums.FirstOrDefault(c => $"{c.PrefixCode}.{c.Code}" == item.OperateTypeId);
                if (enums != null) operateTypeId1 = enums.Name;
                list1.Add(new StMaintainLogExportDto
                {
                    OperateTime = item.OperateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                    TerminalCode = item.TerminalCode,
                    Name = item.Name,
                    PatientId = item.PatientId,
                    Phone = item.Phone,
                    IdNo = item.IdNo,
                    OperateTypeId = operateTypeId1
                }
                    ); 
            }

            var datas = list1.Select(c => new {
               c.OperateTime,
               c.TerminalCode,
               c.Name,
               c.Phone,
               c.IdNo,
               c.OperateTypeId
            });

            var (fileName, filePath) = await ExcelUtil.ExportAsync(Guid.NewGuid().ToString("N"), datas, new List<string> { "操作时间", "终端编号", "操作用户", "手机号", "身份证号", "操作类型"});

            var ms = new MemoryStream();
            await using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
                await fs.CopyToAsync(ms);

            ms.Seek(0, SeekOrigin.Begin);

            var file = "操作日志";
            if (!string.IsNullOrEmpty(name)) file += "-" + name;
            if (!string.IsNullOrEmpty(operateTypeId))
            {
                var enums = userEnums.FirstOrDefault(c => $"{c.PrefixCode}.{c.Code}" == operateTypeId);
                if (enums != null) file += "-" + enums.Name;
            }

            if(!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                file += "-" + startDate+"-"+endDate;
            }

            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationOctetStream}") { FileDownloadName = $"{file}.xlsx" };
        }
    }
}