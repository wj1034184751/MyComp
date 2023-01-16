using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2021042601 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SnBlock",
                table: "STNameplate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SnBlock",
                table: "STNameplate",
                type: "longtext CHARACTER SET utf8mb4",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");
        }
    }
}
