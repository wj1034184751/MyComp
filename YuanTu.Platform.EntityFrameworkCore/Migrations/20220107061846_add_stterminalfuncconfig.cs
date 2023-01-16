using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class add_stterminalfuncconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StFuncConfigId",
                table: "STTerminal",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReferUniqueId",
                table: "StFuncConfig",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.CreateTable(
                name: "StTerminalFuncConfig",
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
                    ParentId = table.Column<string>(nullable: true),
                    TermianlId = table.Column<string>(maxLength: 255, nullable: true),
                    Code = table.Column<string>(maxLength: 128, nullable: false),
                    LevelCode = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 255, nullable: true),
                    StFuncItemConfigId = table.Column<string>(maxLength: 32, nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    Enable = table.Column<bool>(nullable: false),
                    ComponentType = table.Column<int>(nullable: false),
                    SyncMode = table.Column<bool>(nullable: false),
                    ReadOnly = table.Column<int>(nullable: false),
                    ReferUniqueId = table.Column<string>(maxLength: 32, nullable: false),
                    ReferRootId = table.Column<string>(maxLength: 32, nullable: false),
                    ReferSourceId = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StTerminalFuncConfig", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StTerminalFuncConfig");

            migrationBuilder.DropColumn(
                name: "StFuncConfigId",
                table: "STTerminal");

            migrationBuilder.AlterColumn<string>(
                name: "ReferUniqueId",
                table: "StFuncConfig",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);
        }
    }
}
