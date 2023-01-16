using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2021062801 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SnCode",
                table: "STTerminal");

            migrationBuilder.AddColumn<string>(
                name: "SerialNo",
                table: "STTerminal",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "STTerminal");

            migrationBuilder.AddColumn<string>(
                name: "SnCode",
                table: "STTerminal",
                type: "varchar(20) CHARACTER SET utf8mb4",
                maxLength: 20,
                nullable: true);
        }
    }
}
