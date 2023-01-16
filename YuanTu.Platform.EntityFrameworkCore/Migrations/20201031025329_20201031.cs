using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20201031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Protectable",
                table: "STTerminalPlugin",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Protectable",
                table: "STTemplatePlugin",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Protectable",
                table: "STTerminalPlugin");

            migrationBuilder.DropColumn(
                name: "Protectable",
                table: "STTemplatePlugin");
        }
    }
}
