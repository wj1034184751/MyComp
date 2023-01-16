using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2021042502 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameplateCode",
                table: "STSerialNo",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "STNameplate",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameplateCode",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "STNameplate");
        }
    }
}
