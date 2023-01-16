using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200518 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_STTerminalDetail_STTerminal_TerminalId",
                table: "STTerminalDetail");

            migrationBuilder.DropTable(
                name: "STTerminalFolder");

            migrationBuilder.DropIndex(
                name: "IX_STTerminalDetail_TerminalId",
                table: "STTerminalDetail");

            migrationBuilder.DropColumn(
                name: "PluginId",
                table: "STTerminalDetail");

            migrationBuilder.DropColumn(
                name: "PluginName",
                table: "STTerminalDetail");

            migrationBuilder.DropColumn(
                name: "PluginType",
                table: "STTerminalDetail");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "STTerminalDetail");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "STTerminalDetail");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "STTerminalDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PluginId",
                table: "STTerminalDetail",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PluginName",
                table: "STTerminalDetail",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PluginType",
                table: "STTerminalDetail",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminalId",
                table: "STTerminalDetail",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "STTerminalDetail",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VersionId",
                table: "STTerminalDetail",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "STTerminalFolder",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ExtendId = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: false),
                    ParentId = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Remark = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STTerminalFolder", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STTerminalDetail_TerminalId",
                table: "STTerminalDetail",
                column: "TerminalId");

            migrationBuilder.AddForeignKey(
                name: "FK_STTerminalDetail_STTerminal_TerminalId",
                table: "STTerminalDetail",
                column: "TerminalId",
                principalTable: "STTerminal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
