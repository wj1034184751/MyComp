using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020102001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVoiceEnable",
                table: "STTerminal",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rate",
                table: "STTerminal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VoiceType",
                table: "STTerminal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Volumn",
                table: "STTerminal",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVoiceEnable",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "VoiceType",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "Volumn",
                table: "STTerminal");
        }
    }
}
