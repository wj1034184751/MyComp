using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class addPrintReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BID",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "Dept_Id",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "IDCardNo",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "IP",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "ReceiptTypeId",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "SSCardNo",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "STTerminalId",
                table: "STPrintHistory");

            migrationBuilder.AddColumn<string>(
                name: "DeptId",
                table: "STPrintHistory",
                maxLength: 64,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StPrintReport",
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
                    PrinterTypeId = table.Column<string>(maxLength: 32, nullable: true),
                    PersonTime = table.Column<long>(nullable: false),
                    TotalPages = table.Column<long>(nullable: false),
                    TotalPagesInA4 = table.Column<long>(nullable: false),
                    TotalPagesInA5 = table.Column<long>(nullable: false),
                    TotalPagesInReceipt = table.Column<long>(nullable: false),
                    PrinterName = table.Column<string>(maxLength: 128, nullable: true),
                    StTerminalId = table.Column<string>(maxLength: 32, nullable: true),
                    ReportTimelyType = table.Column<int>(nullable: false),
                    BusinessTypeId = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StPrintReport", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StPrintReport");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "STPrintHistory");

            migrationBuilder.AddColumn<string>(
                name: "BID",
                table: "STPrintHistory",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dept_Id",
                table: "STPrintHistory",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IDCardNo",
                table: "STPrintHistory",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IP",
                table: "STPrintHistory",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiptTypeId",
                table: "STPrintHistory",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SSCardNo",
                table: "STPrintHistory",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "STTerminalId",
                table: "STPrintHistory",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: true);
        }
    }
}
