using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Net.MimeTypes;
using YuanTu.Platform.POS.Dto;
using YuanTu.Platform.Utilities;

namespace YuanTu.Platform.POS
{
    [AbpAuthorize]
    public class PosTradeAppService : AsynPermissionAppService<PosTrade, PosTradeDto, string, PagedPosTradeRequestDto, PosTradeDto, PosTradeDto>, IPosTradeAppService
    {
        public PosTradeAppService(IRepository<PosTrade, string> repository) : base(repository)
        {
        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<PosTradeDto>> GetAllAsync(PagedPosTradeRequestDto input)
        {
            input.Sorting = "CreationTime desc";
            return base.GetAllAsync(input);
        }

        protected override IQueryable<PosTrade> CreateFilteredQuery(PagedPosTradeRequestDto input)
        {
            return Repository.GetAll()
                .WhereIf(!input.PatientId.IsNullOrWhiteSpace(), x => x.PatientId == input.PatientId)
                .WhereIf(!input.Pid.IsNullOrWhiteSpace(), x => x.IdNo == input.Pid)
                .WhereIf(!input.PlatformNo.IsNullOrWhiteSpace(), x => x.PlatformNo == input.PlatformNo)
                .WhereIf(!input.PatientName.IsNullOrWhiteSpace(), x => x.PatientName == input.PatientName)
                .WhereIf(!input.StartTime.IsNullOrWhiteSpace(), x => x.FinishTime >= Convert.ToDateTime($"{input.StartTime} 00:00:00"))
                .WhereIf(!input.EndTime.IsNullOrWhiteSpace(), x => x.FinishTime <= Convert.ToDateTime($"{input.EndTime} 23:59:59"))
                .WhereIf(input.OrgId.HasValue, x => x.OrgId == input.OrgId);
        }

        [AbpAllowAnonymous]
        public override Task<PosTradeDto> CreateAsync(PosTradeDto input)
        {
            return base.CreateAsync(input);
        }

        [AbpAllowAnonymous]
        public override Task<PosTradeDto> UpdateAsync(PosTradeDto input)
        {
            return base.UpdateAsync(input);
        }


        [HttpPost, AbpAllowAnonymous]
        public async Task<IActionResult> ExportAsync(dynamic data)
        {
            string startTime = data.startTime;
            string endTime = data.endTime;

            var list = Repository.GetAll()
                .WhereIf(!startTime.IsNullOrWhiteSpace(), x => x.FinishTime >= Convert.ToDateTime($"{startTime} 00:00:00"))
                .WhereIf(!endTime.IsNullOrWhiteSpace(), x => x.FinishTime <= Convert.ToDateTime($"{endTime} 23:59:59"))
                .Where(x => x.PayState == 252 && x.TradeType == 0)
                .OrderByDescending(x => x.FinishTime)
                .ToList();

            var datas = list.Select(x =>
            {
                var bank = x.BankType.HasValue ? ((BankTypes)x.BankType.Value).GetEnumDescription() : string.Empty;
                var amount = (x.Amount / 100d).ToString("F4");
                var termNo = !string.IsNullOrWhiteSpace(x.TerminalNo) ? x.TerminalNo : x.Source;
                var optType = x.OptType.HasValue ? ((OptTypes) x.OptType.Value).GetEnumDescription() : string.Empty;
                return new
                {
                    x.PatientId,
                    x.PatientName,
                    termNo,
                    x.PatientCardNo,
                    x.PlatformNo,
                    x.TransSeq,
                    BankPayNo = EncryptUtil.UDecrypt(x.BankPayNo),
                    x.MerchantID,
                    x.TerminalID,
                    BankType = x.BankType.HasValue ? ((BankTypes)x.BankType).ToString() : "",
                    Bank = bank,
                    x.CardNo,
                    Amount = amount,
                    PayState = "成功",
                    FinishTime = x.FinishTime?.ToString("yyyy-MM-dd HH:mm:ss"),
                    x.InvoiceNo,
                    optType
                };
            });

            var (fileName, filePath) = await ExcelUtil.ExportAsync(null, datas, new List<string> { "ID", "姓名", "终端编号","就诊卡号", "支付流水号", "银行流水号", "交易参考号", "商户号", "终端号", "银行代码", "交易银行", "交易卡号", "交易金额", "交易状态", "交易日期", "收据号" ,"业务类型"});

            var ms = new MemoryStream();
            await using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 65536, FileOptions.Asynchronous | FileOptions.SequentialScan))
                await fs.CopyToAsync(ms);

            ms.Seek(0, SeekOrigin.Begin);

            if (File.Exists(filePath)) File.Delete(filePath);

            return new FileStreamResult(ms, $"{MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet}") { FileDownloadName = fileName };
        }
    }

    #region 银行类型

    public enum BankTypes
    {
        [Description("中国银联")]
        CUP,                                                            // 银联
        [Description("工商银行")]
        ICBC,                                                           // 工商银行
        [Description("农业银行")]
        ABC,                                                            // 农业银行
        [Description("建设银行")]
        CCB,                                                            // 建设银行
        [Description("中国银行")]
        BOC,                                                            // 中国银行
        [Description("民生银行")]
        CMBC,                                                         // 民生银行
        [Description("农商行")]
        RCB,                                                            // 农商行
        [Description("温州银行")]
        WZCB,                                                         // 温州银行
        [Description("中信银行")]
        CITIC,                                                          // 中信银行
        [Description("招商银行")]
        CMB,                                                           // 招商银行
        [Description("兴业银行")]
        CIB,                                                             // 兴业银行
        [Description("国家开发银行")]
        CDB,                                                           // 国家开发银行
        [Description("北京市商业银行")]
        BCCB,                                                         // 北京市商业银行
        [Description("汇丰银行")]
        HSBC,                                                         // 汇丰银行
        [Description("中国人民银行")]
        PBC,                                                           // 中国人民银行
        [Description("安徽农信")]
        RCC,                                                           // 安徽农信
        [Description("中国光大")]
        CEB,                                                           // 中国光大
        [Description("交通银行")]
        BCM,                                                         // 交通银行
        [Description("民生卡或市民卡")]
        MSSM,                                                      // 民生卡或市民卡
        [Description("贵州银行")]
        BOGZ,                                                       //贵州银行
        [Description("甘肃银行")]
        BOGS,                                                       //甘肃银行
        [Description("虚拟")]
        VIRTUAL = 98,                                          // 虚拟
        [Description("聚合银行")]
        BANKS = 99,                                             // 聚合银行
    }

    #endregion

    #region 业务类型枚举

    /// <summary>
    /// 业务类型枚举，与网关对应
    /// </summary>
    public enum OptTypes
    {
        [Description("未知业务")]
        UNKNOWN = -1,
        [Description("门诊充值")]
        RECHARGE = 1,
        [Description("门诊缴费")]
        PAYMENT = 2,
        [Description("门诊挂号")]
        REG = 3,
        [Description("住院充值")]
        RESIDENT_RECHARGE = 4,
        [Description("退费")]
        REFUND = 5,
        [Description("预约")]
        APPOINT = 6,
        [Description("预约取号")]
        TAKENO = 7,
        [Description("建档发卡")]
        ISSUE_CARD = 8,
        [Description("出院结算")]
        OUTHOS_SETTLEMENT = 9,
        [Description("视频问诊")]
        VIDEO_INQUIRY = 11,
        [Description("图文问诊")]
        GRAPHIC_INQUIRY = 11,
        [Description("保险")]
        INSURANCE = 13,
        [Description("购物")]
        SHOPPING_ONLINE = 14,
        [Description("转账")]
        TRANSFER_ACCOUNT = 15,
        [Description("预约停车")]
        APPOINT_PARK = 16,
        [Description("停车")]
        PARK = 17,
        [Description("视频问诊挂号")]
        VIDEO_INQUIRY_REG = 18,
        [Description("发放病历本")]
        PUT_MEDICAL_RECORD = 21,
        [Description("预交金退余额")]
        ADVANCE_REFUND_BALANCE = 22,
        [Description("体检缴费")]
        HEALTH_EXAMINATION = 23,
        [Description("病案缴费")]
        MEDICAL_RECORD = 24,
        [Description("药房缴费")]
        PHARMACY_PAYMENT = 25,
        [Description("诊间结算")]
        CLINIC_SETTLEMENT = 26,
        [Description("病历复制")]
        MEDICAL_CASE_COPY = 27,
        [Description("处方缴费")]
        RECIPE_PAYMENT = 28,
        [Description("门诊签到")]
        SIGN = 31,
        [Description("检验检查")]
        INSPECTION = 32,
        [Description("门诊取药")]
        DISPENSARY = 33,
        [Description("补打")]
        MAKE_UP = 34,
        [Description("查询信息")]
        QUERY_INFO = 35,//刷脸使用业务，自助机不能识别的具体业务类型默认传这个
        [Description("胶片打印")]
        FILM_PRINT = 36,
        [Description("医院超市")]
        HOSPITAL_SUPERMARKET = 37,
        [Description("营养膳食")]
        NUTRITIONAL_DIET = 38,
        [Description("医后付还款")]
        CREDITPAY_REPAYMENT = 39,
        [Description("床旁结算")]
        BEDSIDE_SETTLEMENT = 40,
        [Description("病理收费")]
        PATHOLOGY_PAYMENT = 41,
        [Description("报销窗口")]
        REIMBURSEMENT_WINDOW = 42,
        [Description("交通费用")]
        TRANSPORT_CONSUME = 43,
    }

    #endregion
}