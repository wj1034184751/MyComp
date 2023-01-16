using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class modify_terminalid_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TermianlId",
                table: "StTerminalFuncConfig");

            migrationBuilder.AddColumn<string>(
                name: "TerminalId",
                table: "StTerminalFuncConfig",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "StTerminalFuncConfig");

            migrationBuilder.AddColumn<string>(
                name: "TermianlId",
                table: "StTerminalFuncConfig",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: true);
        }
    }
}
