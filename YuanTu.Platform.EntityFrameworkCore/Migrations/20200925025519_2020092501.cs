using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020092501 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServerUrl",
                table: "AbpOrganizationUnits",
                maxLength: 512,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServerUrl",
                table: "AbpOrganizationUnits");
        }
    }
}
