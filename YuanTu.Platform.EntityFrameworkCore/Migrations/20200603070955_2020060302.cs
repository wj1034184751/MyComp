using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020060302 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HospitalCode",
                table: "AbpOrganizationUnits");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HospitalCode",
                table: "AbpOrganizationUnits",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true);
        }
    }
}
