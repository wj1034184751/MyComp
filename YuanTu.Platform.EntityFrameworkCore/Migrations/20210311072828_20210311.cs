using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GatewayTemplateId",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "GatewayTemplateName",
                table: "STTerminal");

            migrationBuilder.AddColumn<string>(
                name: "ConfigCode",
                table: "STTerminal",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfigCode",
                table: "AbpWardArea",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfigCode",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "ConfigCode",
                table: "AbpWardArea");

            migrationBuilder.AddColumn<int>(
                name: "GatewayTemplateId",
                table: "STTerminal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GatewayTemplateName",
                table: "STTerminal",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true);
        }
    }
}
