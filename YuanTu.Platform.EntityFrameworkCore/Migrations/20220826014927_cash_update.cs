using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class cash_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "CashTrade",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefundMoney",
                table: "CashTrade",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefundStatus",
                table: "CashTrade",
                maxLength: 255,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefundTime",
                table: "CashTrade",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "CashSign",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RefundTotalCount",
                table: "CashSign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RefundTotalMoney",
                table: "CashSign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CashAmount",
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
                    LotId = table.Column<string>(maxLength: 255, nullable: false),
                    TerminalID = table.Column<string>(maxLength: 255, nullable: false),
                    IP = table.Column<string>(maxLength: 255, nullable: false),
                    IsSignout = table.Column<bool>(nullable: false),
                    TotalMoney = table.Column<int>(nullable: false),
                    InpatientWard = table.Column<string>(maxLength: 255, nullable: true),
                    Position = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashAmount", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashAmount");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "CashTrade");

            migrationBuilder.DropColumn(
                name: "RefundMoney",
                table: "CashTrade");

            migrationBuilder.DropColumn(
                name: "RefundStatus",
                table: "CashTrade");

            migrationBuilder.DropColumn(
                name: "RefundTime",
                table: "CashTrade");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "CashSign");

            migrationBuilder.DropColumn(
                name: "RefundTotalCount",
                table: "CashSign");

            migrationBuilder.DropColumn(
                name: "RefundTotalMoney",
                table: "CashSign");
        }
    }
}
