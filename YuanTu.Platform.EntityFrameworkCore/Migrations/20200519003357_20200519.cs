using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200519 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STTemplateDetail");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "STTerminalPlugin",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JsonText",
                table: "STTerminalPart",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "STTemplatePart",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    PartId = table.Column<string>(maxLength: 256, nullable: true),
                    PartName = table.Column<string>(maxLength: 256, nullable: true),
                    PartType = table.Column<string>(maxLength: 256, nullable: true),
                    JsonText = table.Column<string>(nullable: true),
                    TemplateId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STTemplatePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STTemplatePart_STTemplate_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "STTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STTemplatePlugin",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    PluginId = table.Column<string>(maxLength: 256, nullable: true),
                    PluginName = table.Column<string>(maxLength: 256, nullable: true),
                    PluginCode = table.Column<string>(maxLength: 256, nullable: true),
                    VersionId = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    Path = table.Column<string>(maxLength: 1024, nullable: true),
                    TemplateId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STTemplatePlugin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STTemplatePluginNet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    PluginId = table.Column<string>(maxLength: 256, nullable: true),
                    Port = table.Column<int>(nullable: false),
                    NetType = table.Column<string>(maxLength: 256, nullable: true),
                    TemplateId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STTemplatePluginNet", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STTemplatePart_TemplateId",
                table: "STTemplatePart",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STTemplatePart");

            migrationBuilder.DropTable(
                name: "STTemplatePlugin");

            migrationBuilder.DropTable(
                name: "STTemplatePluginNet");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "STTerminalPlugin");

            migrationBuilder.DropColumn(
                name: "JsonText",
                table: "STTerminalPart");

            migrationBuilder.CreateTable(
                name: "STTemplateDetail",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    PartId = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    PartName = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    PartType = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    Remark = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    TemplateId = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STTemplateDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_STTemplateDetail_STTemplate_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "STTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STTemplateDetail_TemplateId",
                table: "STTemplateDetail",
                column: "TemplateId");
        }
    }
}
