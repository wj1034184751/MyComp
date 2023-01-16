using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210610 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryModel",
                table: "STSerialNo",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderModel",
                table: "STSerialNo",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "STNameplate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "PreDeliveryDate",
                table: "STNameplate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "STNameplate",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryModel",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "OrderModel",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "STNameplate");

            migrationBuilder.DropColumn(
                name: "PreDeliveryDate",
                table: "STNameplate");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "STNameplate");
        }
    }
}
