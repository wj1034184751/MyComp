using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210705 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "STSerialNo",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "STSerialNo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "STNameplate",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "STNameplate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "STNameplate");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "STNameplate");
        }
    }
}
