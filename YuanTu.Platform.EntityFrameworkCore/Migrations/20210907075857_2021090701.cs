using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2021090701 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rule",
                table: "STTerminalCustomEnum",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rule",
                table: "STTemplateCustomEnum",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rule",
                table: "AbpCustomEnums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rule",
                table: "STTerminalCustomEnum");

            migrationBuilder.DropColumn(
                name: "Rule",
                table: "STTemplateCustomEnum");

            migrationBuilder.DropColumn(
                name: "Rule",
                table: "AbpCustomEnums");
        }
    }
}
