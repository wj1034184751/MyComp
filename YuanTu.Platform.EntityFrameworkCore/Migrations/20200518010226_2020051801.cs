using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020051801 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_STTerminalDetail",
                table: "STTerminalDetail");

            migrationBuilder.RenameTable(
                name: "STTerminalDetail",
                newName: "STTerminalPart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_STTerminalPart",
                table: "STTerminalPart",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "STTerminalPlugin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    TermianlId = table.Column<string>(maxLength: 256, nullable: true),
                    PluginId = table.Column<string>(maxLength: 256, nullable: true),
                    PluginName = table.Column<string>(maxLength: 256, nullable: true),
                    PluginCode = table.Column<string>(maxLength: 256, nullable: true),
                    VersionId = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STTerminalPlugin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STTerminalPluginNet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    TermianlId = table.Column<string>(maxLength: 256, nullable: true),
                    PluginId = table.Column<string>(maxLength: 256, nullable: true),
                    Port = table.Column<int>(nullable: false),
                    NetType = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STTerminalPluginNet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STTerminalPlugin");

            migrationBuilder.DropTable(
                name: "STTerminalPluginNet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_STTerminalPart",
                table: "STTerminalPart");

            migrationBuilder.RenameTable(
                name: "STTerminalPart",
                newName: "STTerminalDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_STTerminalDetail",
                table: "STTerminalDetail",
                column: "Id");
        }
    }
}
