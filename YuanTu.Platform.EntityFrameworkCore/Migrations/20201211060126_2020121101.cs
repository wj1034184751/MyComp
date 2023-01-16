using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020121101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extend",
                table: "PosConfig",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extend1",
                table: "PosConfig",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extend2",
                table: "PosConfig",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extend",
                table: "PosConfig");

            migrationBuilder.DropColumn(
                name: "Extend1",
                table: "PosConfig");

            migrationBuilder.DropColumn(
                name: "Extend2",
                table: "PosConfig");
        }
    }
}
