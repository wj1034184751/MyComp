using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20201029 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMedEnable",
                table: "AbpOrganizationUnits");

            migrationBuilder.AddColumn<int>(
                name: "McReadMode",
                table: "AbpOrganizationUnits",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "McReadMode",
                table: "AbpOrganizationUnits");

            migrationBuilder.AddColumn<bool>(
                name: "IsMedEnable",
                table: "AbpOrganizationUnits",
                type: "tinyint(1)",
                nullable: true);
        }
    }
}
