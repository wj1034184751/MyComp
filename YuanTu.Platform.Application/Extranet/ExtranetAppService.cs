using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Web.Models;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using YuanTu.Platform.POS;
using YuanTu.Platform.ST;

namespace YuanTu.Platform.Extranet
{
    /// <summary>
    /// 供外部使用
    /// </summary>
    public class ExtranetAppService : ApplicationService, IExtranetAppService
    {
        private readonly IRepository<STTerminal, string> _repositorySTTerminal;
        private readonly IRepository<STTerminalDeptMap, string> _repositorySTTerminalDeptMap;
        private readonly IRepository<PosTrade, string> _repositoryPosTrade;

        public ExtranetAppService(IRepository<STTerminal, string> repositorySTTerminal,
            IRepository<STTerminalDeptMap, string> repositorySTTerminalDeptMap,
            IRepository<PosTrade, string> repositoryPosTrade)
        {
            _repositorySTTerminal = repositorySTTerminal;
            _repositorySTTerminalDeptMap = repositorySTTerminalDeptMap;
            _repositoryPosTrade = repositoryPosTrade;
        }

        [DontWrapResult]
        public async Task<ExtranetResult<object>> GetTerminalDepts(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return ExtranetResult<object>.Fail(-1, $"参数{nameof(code)}不能为空");

            var dept = await _repositorySTTerminalDeptMap.GetAll().Join(_repositorySTTerminal.GetAll().Where(s => s.Code == code),
                s => s.TerminalId, t => t.Id, (s, t) => s).FirstOrDefaultAsync();

            if (dept == null) return ExtranetResult<object>.Fail(-1, "未找到匹配的数据");

            return ExtranetResult<object>.Success(new
            {
                dept.PriorityType,
                PriorityTypeDept = JArray.Parse(dept.PriorityTypeDept),
                dept.RestrictionType,
                RestrictionTypeDept = JArray.Parse(dept.RestrictionTypeDept)
            });
        }

        [DontWrapResult,HttpPost]
        public async Task<ExtranetResult<object>> UpdateInvoiceNo(dynamic data)
        {
            try
            {
                string platformNo = data.platformNo;
                string invoiceNo = data.invoiceNo;

                if (string.IsNullOrWhiteSpace(platformNo))
                    return ExtranetResult<object>.Fail(-1, $"参数{nameof(platformNo)}不能为空");
                if (string.IsNullOrWhiteSpace(invoiceNo))
                    return ExtranetResult<object>.Fail(-1, $"参数{nameof(invoiceNo)}不能为空");

                var m = await _repositoryPosTrade.FirstOrDefaultAsync(s => s.PlatformNo == platformNo);

                if (m == null) return ExtranetResult<object>.Fail(-1, "未找到匹配的数据");

                m.InvoiceNo = invoiceNo;
                await _repositoryPosTrade.UpdateAsync(m);

                return ExtranetResult<object>.Success(true,"更新成功");
            }
            catch (Exception ex)
            {
                NullLogger.Instance.Error(ex.ToString);
                return ExtranetResult<object>.Fail(-1, $"更新失败！原因：{ex.Message}");
            }
        }
    }
}