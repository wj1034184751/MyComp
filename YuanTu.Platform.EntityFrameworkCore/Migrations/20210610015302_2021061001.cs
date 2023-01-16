using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2021061001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "STNameplate");

            migrationBuilder.AddColumn<byte>(
                name: "DeliveryStatus",
                table: "STSerialNo",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "DeliveryStatus",
                table: "STNameplate",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "DeliveryStatus",
                table: "STNameplate");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "STNameplate",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
