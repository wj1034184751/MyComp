using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210805 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayTrade",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    OrgId = table.Column<long>(nullable: false),
                    OutTradeNo = table.Column<string>(maxLength: 255, nullable: true),
                    OutPayNo = table.Column<string>(maxLength: 255, nullable: true),
                    Business = table.Column<byte>(nullable: false),
                    TraceId = table.Column<string>(maxLength: 64, nullable: true),
                    Fee = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(maxLength: 32, nullable: true),
                    PatientName = table.Column<string>(maxLength: 64, nullable: true),
                    CardNo = table.Column<string>(maxLength: 64, nullable: true),
                    FeeChannel = table.Column<int>(nullable: false),
                    TradeMode = table.Column<string>(maxLength: 20, nullable: true),
                    PayType = table.Column<int>(nullable: false),
                    PayTime = table.Column<DateTime>(nullable: true),
                    TradeTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    PayAccount = table.Column<string>(maxLength: 128, nullable: true),
                    OperId = table.Column<string>(maxLength: 64, nullable: true),
                    Source = table.Column<string>(maxLength: 64, nullable: true),
                    PosDetail = table.Column<string>(nullable: true),
                    RequestContent = table.Column<string>(nullable: true),
                    ResponseContent = table.Column<string>(nullable: true),
                    DeviceInfo = table.Column<string>(maxLength: 255, nullable: true),
                    ParentCorpId = table.Column<string>(maxLength: 64, nullable: true),
                    HisCode = table.Column<string>(maxLength: 64, nullable: true),
                    FundCustodian = table.Column<string>(maxLength: 128, nullable: true),
                    DeviceMac = table.Column<string>(maxLength: 64, nullable: true),
                    DeviceIp = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayTrade", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PayTrade");
        }
    }
}
