using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020092802 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Delay",
                table: "STTerminalPlugin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FixedTime",
                table: "STTerminalPlugin",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartMode",
                table: "STTerminalPlugin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Delay",
                table: "STTemplatePlugin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FixedTime",
                table: "STTemplatePlugin",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartMode",
                table: "STTemplatePlugin",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delay",
                table: "STTerminalPlugin");

            migrationBuilder.DropColumn(
                name: "FixedTime",
                table: "STTerminalPlugin");

            migrationBuilder.DropColumn(
                name: "StartMode",
                table: "STTerminalPlugin");

            migrationBuilder.DropColumn(
                name: "Delay",
                table: "STTemplatePlugin");

            migrationBuilder.DropColumn(
                name: "FixedTime",
                table: "STTemplatePlugin");

            migrationBuilder.DropColumn(
                name: "StartMode",
                table: "STTemplatePlugin");
        }
    }
}
