using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class addPrinter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDoubleTray",
                table: "STPrinter",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IsPrintPaperSize",
                table: "STPrinter",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsPrinterType",
                table: "STPrinter",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDoubleTray",
                table: "STPrinter");

            migrationBuilder.DropColumn(
                name: "IsPrintPaperSize",
                table: "STPrinter");

            migrationBuilder.DropColumn(
                name: "IsPrinterType",
                table: "STPrinter");
        }
    }
}
