using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210716 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Maintainer",
                table: "AbpOrganizationUnits",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "AbpOrganizationUnits",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maintainer",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "AbpOrganizationUnits");
        }
    }
}
