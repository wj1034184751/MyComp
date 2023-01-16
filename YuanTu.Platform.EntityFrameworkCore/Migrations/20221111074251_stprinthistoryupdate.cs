using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class stprinthistoryupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
           

            migrationBuilder.AddColumn<string>(
                name: "DeptCode",
                table: "STReportRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "STReportRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptCode",
                table: "StPrintReport",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "StPrintReport",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TotalPagesCustom",
                table: "StPrintReport",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DeptCode",
                table: "STPrintHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptName",
                table: "STPrintHistory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeptCode",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "DeptCode",
                table: "StPrintReport");

            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "StPrintReport");

            migrationBuilder.DropColumn(
                name: "TotalPagesCustom",
                table: "StPrintReport");

            migrationBuilder.DropColumn(
                name: "DeptCode",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "DeptName",
                table: "STPrintHistory");
 
        }
    }
}
