using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20220519 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonitorHospitalId",
                table: "AbpOrganizationUnits",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "MedTradedData",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(nullable: false),
            //        CreationTime = table.Column<DateTime>(nullable: false),
            //        CreatorUserId = table.Column<long>(nullable: true),
            //        LastModificationTime = table.Column<DateTime>(nullable: true),
            //        LastModifierUserId = table.Column<long>(nullable: true),
            //        IsDeleted = table.Column<bool>(nullable: false),
            //        DeleterUserId = table.Column<long>(nullable: true),
            //        DeletionTime = table.Column<DateTime>(nullable: true),
            //        TenantId = table.Column<int>(nullable: true),
            //        Remark = table.Column<string>(nullable: true),
            //        OrgId = table.Column<long>(nullable: false),
            //        PrePayTraceId = table.Column<string>(maxLength: 128, nullable: true),
            //        PayTraceId = table.Column<string>(maxLength: 128, nullable: true),
            //        RefundTraceId = table.Column<string>(maxLength: 128, nullable: true),
            //        CorrectTraceId = table.Column<string>(maxLength: 128, nullable: true),
            //        PersonNo = table.Column<string>(maxLength: 64, nullable: true),
            //        Name = table.Column<string>(maxLength: 64, nullable: true),
            //        PersonId = table.Column<string>(maxLength: 64, nullable: true),
            //        PatientId = table.Column<string>(maxLength: 64, nullable: true),
            //        MdtrtId = table.Column<string>(maxLength: 64, nullable: true),
            //        IptOptNo = table.Column<string>(maxLength: 64, nullable: true),
            //        SendMsgId = table.Column<string>(maxLength: 64, nullable: true),
            //        SettleId = table.Column<string>(maxLength: 64, nullable: true),
            //        ChrgBchNo = table.Column<string>(maxLength: 64, nullable: true),
            //        InsuType = table.Column<string>(maxLength: 8, nullable: true),
            //        PersonType = table.Column<string>(maxLength: 8, nullable: true),
            //        SettleTime = table.Column<DateTime>(nullable: false),
            //        MdtrtCertType = table.Column<string>(maxLength: 8, nullable: true),
            //        MedType = table.Column<string>(maxLength: 8, nullable: true),
            //        MedFeeSumamt = table.Column<decimal>(nullable: false),
            //        PsnCashPay = table.Column<decimal>(nullable: false),
            //        PsnAcctPay = table.Column<decimal>(nullable: false),
            //        FundPaySumamt = table.Column<decimal>(nullable: false),
            //        TradeType = table.Column<string>(maxLength: 8, nullable: true),
            //        TradeStatus = table.Column<string>(maxLength: 8, nullable: true),
            //        InData2201 = table.Column<string>(nullable: true),
            //        OutData2201 = table.Column<string>(nullable: true),
            //        InData2202 = table.Column<string>(nullable: true),
            //        OutData2202 = table.Column<string>(nullable: true),
            //        InData2203 = table.Column<string>(nullable: true),
            //        OutData2203 = table.Column<string>(nullable: true),
            //        InData2204 = table.Column<string>(nullable: true),
            //        OutData2204 = table.Column<string>(nullable: true),
            //        InData2205 = table.Column<string>(nullable: true),
            //        OutData2205 = table.Column<string>(nullable: true),
            //        InData2206 = table.Column<string>(nullable: true),
            //        OutData2206 = table.Column<string>(nullable: true),
            //        InData2207 = table.Column<string>(nullable: true),
            //        OutData2207 = table.Column<string>(nullable: true),
            //        InData2208 = table.Column<string>(nullable: true),
            //        OutData2208 = table.Column<string>(nullable: true),
            //        InData2601 = table.Column<string>(nullable: true),
            //        OutData2601 = table.Column<string>(nullable: true),
            //        InData2401 = table.Column<string>(nullable: true),
            //        OutData2401 = table.Column<string>(nullable: true),
            //        InData2402 = table.Column<string>(nullable: true),
            //        OutData2402 = table.Column<string>(nullable: true),
            //        InData2404 = table.Column<string>(nullable: true),
            //        OutData2404 = table.Column<string>(nullable: true),
            //        InData2405 = table.Column<string>(nullable: true),
            //        OutData2405 = table.Column<string>(nullable: true),
            //        InData2301 = table.Column<string>(nullable: true),
            //        OutData2301 = table.Column<string>(nullable: true),
            //        InData2302 = table.Column<string>(nullable: true),
            //        OutData2302 = table.Column<string>(nullable: true),
            //        InData2303 = table.Column<string>(nullable: true),
            //        OutData2303 = table.Column<string>(nullable: true),
            //        InData2304 = table.Column<string>(nullable: true),
            //        OutData2304 = table.Column<string>(nullable: true),
            //        InData2305 = table.Column<string>(nullable: true),
            //        OutData2305 = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_MedTradedData", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "MedTradedData");

            migrationBuilder.DropColumn(
                name: "MonitorHospitalId",
                table: "AbpOrganizationUnits");
        }
    }
}
