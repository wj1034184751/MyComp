using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200925 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MunicipalMiCode",
                table: "AbpOrganizationUnits",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvincialMiCode",
                table: "AbpOrganizationUnits",
                maxLength: 128,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MunicipalMiCode",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "ProvincialMiCode",
                table: "AbpOrganizationUnits");
        }
    }
}
