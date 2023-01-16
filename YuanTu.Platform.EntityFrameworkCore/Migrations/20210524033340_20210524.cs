using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210524 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "CameraType",
                table: "STCamera",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "STCamera",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MonikerString",
                table: "STCamera",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CameraType",
                table: "STCamera");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "STCamera");

            migrationBuilder.DropColumn(
                name: "MonikerString",
                table: "STCamera");
        }
    }
}
