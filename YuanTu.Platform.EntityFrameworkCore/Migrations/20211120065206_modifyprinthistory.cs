using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class modifyprinthistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdCardNo",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SsCardNo",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StTerminalId",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCardNo",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "SsCardNo",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "StTerminalId",
                table: "STPrintHistory");
        }
    }
}
