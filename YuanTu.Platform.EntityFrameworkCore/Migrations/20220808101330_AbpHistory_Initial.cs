using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class AbpHistory_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDate",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDeptName",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDoctCode",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDoctName",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDoctPhone",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckDate",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckDesc",
                table: "STPrintHistory",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckGuide",
                table: "STPrintHistory",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckResult",
                table: "STPrintHistory",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckStatus",
                table: "STPrintHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "STPrintHistory",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNo",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspecDeptName",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspecDoctCode",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspecDoctName",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspecTime",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportIntranetUrl",
                table: "STPrintHistory",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportName",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "STPrintHistory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportType",
                table: "STPrintHistory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportUrl",
                table: "STPrintHistory",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "STPrintHistory",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suggestion",
                table: "STPrintHistory",
                maxLength: 100,
                nullable: true);

           
 
         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.DropColumn(
                name: "Age",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "AuditDate",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "AuditDeptName",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "AuditDoctCode",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "AuditDoctName",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "AuditDoctPhone",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "CheckDate",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "CheckDesc",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "CheckGuide",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "CheckResult",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "CheckStatus",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "IdNo",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "InspecDeptName",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "InspecDoctCode",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "InspecDoctName",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "InspecTime",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "ReportIntranetUrl",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "ReportName",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "ReportUrl",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "Suggestion",
                table: "STPrintHistory");
        }
    }
}
