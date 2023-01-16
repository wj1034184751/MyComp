using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20201221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermianlId",
                table: "PosConfig");

            migrationBuilder.AddColumn<string>(
                name: "TerminalIds",
                table: "PosConfig",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TerminalIds",
                table: "PosConfig");

            migrationBuilder.AddColumn<string>(
                name: "TermianlId",
                table: "PosConfig",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true);
        }
    }
}
