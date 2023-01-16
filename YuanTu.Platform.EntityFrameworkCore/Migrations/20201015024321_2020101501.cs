using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020101501 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "STTerminal");

            migrationBuilder.AddColumn<string>(
                name: "BID",
                table: "STTerminal",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BID",
                table: "STTerminal");

            migrationBuilder.AddColumn<string>(
                name: "BoardId",
                table: "STTerminal",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true);
        }
    }
}
