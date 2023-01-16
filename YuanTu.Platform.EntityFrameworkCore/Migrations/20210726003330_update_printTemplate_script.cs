using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class update_printTemplate_script : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AfterScript",
                table: "PrintTemplate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeforeScript",
                table: "PrintTemplate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataSource",
                table: "PrintTemplate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AfterScript",
                table: "PrintTemplate");

            migrationBuilder.DropColumn(
                name: "BeforeScript",
                table: "PrintTemplate");

            migrationBuilder.DropColumn(
                name: "DataSource",
                table: "PrintTemplate");
        }
    }
}
