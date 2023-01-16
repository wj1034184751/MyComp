using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200829 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CashSign",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    LotId = table.Column<string>(maxLength: 256, nullable: false),
                    TerminalID = table.Column<string>(maxLength: 256, nullable: false),
                    IP = table.Column<string>(maxLength: 256, nullable: false),
                    MAC = table.Column<string>(maxLength: 256, nullable: false),
                    SignoutTime = table.Column<DateTime>(nullable: true),
                    IsSignout = table.Column<bool>(nullable: false),
                    OrgId = table.Column<string>(maxLength: 256, nullable: false),
                    ReportedMoney = table.Column<int>(nullable: false),
                    TotalMoney = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    TotalCount = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashSign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashTrade",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 256, nullable: false),
                    StatusText = table.Column<string>(maxLength: 256, nullable: false),
                    TotalMoney = table.Column<int>(nullable: false),
                    PatientId = table.Column<string>(maxLength: 256, nullable: false),
                    PatientName = table.Column<string>(maxLength: 256, nullable: false),
                    CurrentMoney = table.Column<int>(nullable: false),
                    LotId = table.Column<string>(maxLength: 256, nullable: false),
                    TerminalID = table.Column<string>(maxLength: 256, nullable: false),
                    IP = table.Column<string>(maxLength: 256, nullable: false),
                    MAC = table.Column<string>(maxLength: 256, nullable: false),
                    EndTime = table.Column<DateTime>(maxLength: 256, nullable: false),
                    Extend = table.Column<string>(nullable: true),
                    OrgId = table.Column<string>(nullable: true),
                    TraceId = table.Column<string>(maxLength: 256, nullable: false),
                    RechargeId = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTrade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CashTradeDetail",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CashTradeId = table.Column<string>(maxLength: 256, nullable: false),
                    Money = table.Column<int>(nullable: false),
                    LotId = table.Column<string>(maxLength: 256, nullable: false),
                    OrgId = table.Column<string>(maxLength: 256, nullable: false),
                    TraceId = table.Column<string>(maxLength: 256, nullable: false),
                    RechargeId = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashTradeDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashSign");

            migrationBuilder.DropTable(
                name: "CashTrade");

            migrationBuilder.DropTable(
                name: "CashTradeDetail");
        }
    }
}
