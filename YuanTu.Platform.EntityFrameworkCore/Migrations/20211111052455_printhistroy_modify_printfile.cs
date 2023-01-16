using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class printhistroy_modify_printfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrintTemplateCode",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "PrintTemplateName",
                table: "STPrintHistory");

            migrationBuilder.AddColumn<string>(
                name: "PrintFile",
                table: "STPrintHistory",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrintFile",
                table: "STPrintHistory");

            migrationBuilder.AddColumn<string>(
                name: "PrintTemplateCode",
                table: "STPrintHistory",
                type: "varchar(128) CHARACTER SET utf8mb4",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrintTemplateName",
                table: "STPrintHistory",
                type: "varchar(128) CHARACTER SET utf8mb4",
                maxLength: 128,
                nullable: true);
        }
    }
}
