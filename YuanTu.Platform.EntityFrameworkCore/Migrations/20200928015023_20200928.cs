using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200928 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RunMode",
                table: "STTerminal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "IsEnable",
                table: "FireWall",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "FireWall",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunMode",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "FireWall");

            migrationBuilder.DropColumn(
                name: "Operation",
                table: "FireWall");
        }
    }
}
