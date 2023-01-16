using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class posAddTraceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TraceId",
                table: "UnionTransData",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_HospitalId",
                table: "AbpOrganizationUnits",
                column: "HospitalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AbpOrganizationUnits_HospitalId",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "TraceId",
                table: "UnionTransData");
        }
    }
}
