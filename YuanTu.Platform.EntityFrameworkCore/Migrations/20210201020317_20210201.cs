using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AbpOrganizationUnits_HospitalId",
                table: "AbpOrganizationUnits");

            migrationBuilder.AlterColumn<string>(
                name: "Extend1",
                table: "PosConfig",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1024) CHARACTER SET utf8mb4",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Extend",
                table: "PosConfig",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1024) CHARACTER SET utf8mb4",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_HospitalId_Code",
                table: "AbpOrganizationUnits",
                columns: new[] { "HospitalId", "Code" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AbpOrganizationUnits_HospitalId_Code",
                table: "AbpOrganizationUnits");

            migrationBuilder.AlterColumn<string>(
                name: "Extend1",
                table: "PosConfig",
                type: "varchar(1024) CHARACTER SET utf8mb4",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Extend",
                table: "PosConfig",
                type: "varchar(1024) CHARACTER SET utf8mb4",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_HospitalId",
                table: "AbpOrganizationUnits",
                column: "HospitalId",
                unique: true);
        }
    }
}
