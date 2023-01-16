using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class Abp_up_Record : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "AuditDate",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "AuditDeptName",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "AuditDoctCode",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "AuditDoctName",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "AuditDoctPhone",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "CheckDate",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "CheckDesc",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "CheckGuide",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "CheckResult",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "CheckStatus",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "IdNo",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "InspecDeptName",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "InspecDoctCode",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "InspecDoctName",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "InspecTime",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "ReportIntranetUrl",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "ReportName",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "ReportStatus",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "ReportUrl",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "Suggestion",
                table: "STReportRecord");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportTime",
                table: "STReportRecord",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportId",
                table: "STReportRecord",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "STReportRecord",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "STReportRecord",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessId",
                table: "STReportRecord",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessTypeId",
                table: "STReportRecord",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeptId",
                table: "STReportRecord",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdCardNo",
                table: "STReportRecord",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Input",
                table: "STReportRecord",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrinted",
                table: "STReportRecord",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PageCount",
                table: "STReportRecord",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaperSize",
                table: "STReportRecord",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrintFailMsg",
                table: "STReportRecord",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrintFile",
                table: "STReportRecord",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrintHistoryId",
                table: "STReportRecord",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrintStatusDesc",
                table: "STReportRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrintTemplateId",
                table: "STReportRecord",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrintTime",
                table: "STReportRecord",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrinterName",
                table: "STReportRecord",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrinterTypeId",
                table: "STReportRecord",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SsCardNo",
                table: "STReportRecord",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StTerminalId",
                table: "STReportRecord",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TraceId",
                table: "STReportRecord",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportId",
                table: "STPrintHistory",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(32) CHARACTER SET utf8mb4",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PrintTime",
                table: "STPrintHistory",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Diagnosis",
                table: "STPrintHistory",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100) CHARACTER SET utf8mb4",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrintCount",
                table: "STPrintHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrintType",
                table: "STPrintHistory",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessId",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "BusinessTypeId",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "IdCardNo",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "Input",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "IsPrinted",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PageCount",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PaperSize",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrintFailMsg",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrintFile",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrintHistoryId",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrintStatusDesc",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrintTemplateId",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrintTime",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrinterName",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrinterTypeId",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "SsCardNo",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "StTerminalId",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "TraceId",
                table: "STReportRecord");

            migrationBuilder.DropColumn(
                name: "PrintCount",
                table: "STPrintHistory");

            migrationBuilder.DropColumn(
                name: "PrintType",
                table: "STPrintHistory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReportTime",
                table: "STReportRecord",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ReportId",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientName",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDate",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDeptName",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDoctCode",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDoctName",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditDoctPhone",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckDate",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckDesc",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckGuide",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckResult",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CheckStatus",
                table: "STReportRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdNo",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspecDeptName",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspecDoctCode",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspecDoctName",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InspecTime",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportIntranetUrl",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportName",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportStatus",
                table: "STReportRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportType",
                table: "STReportRecord",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReportUrl",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suggestion",
                table: "STReportRecord",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReportId",
                table: "STPrintHistory",
                type: "varchar(32) CHARACTER SET utf8mb4",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PrintTime",
                table: "STPrintHistory",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diagnosis",
                table: "STPrintHistory",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2048,
                oldNullable: true);
        }
    }
}
