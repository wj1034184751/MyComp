using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020092201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEnable",
                table: "AppAuth");

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "AppAuth",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "AppAuth");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnable",
                table: "AppAuth",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
