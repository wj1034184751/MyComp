using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMock",
                table: "STTerminalPlugin",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDebug",
                table: "STTerminal",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMock",
                table: "STTemplatePlugin",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMock",
                table: "STTerminalPlugin");

            migrationBuilder.DropColumn(
                name: "IsDebug",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "IsMock",
                table: "STTemplatePlugin");
        }
    }
}
