using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class medical_upd_525 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "MedTransData",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "MedHisTransData",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "MedTransData");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "MedHisTransData");
        }
    }
}
