using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210818 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailTotalCount",
                table: "CashSign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FailTotalMoney",
                table: "CashSign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuccessTotalCount",
                table: "CashSign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SuccessTotalMoney",
                table: "CashSign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnkownTotalCount",
                table: "CashSign",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnkownTotalMoney",
                table: "CashSign",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailTotalCount",
                table: "CashSign");

            migrationBuilder.DropColumn(
                name: "FailTotalMoney",
                table: "CashSign");

            migrationBuilder.DropColumn(
                name: "SuccessTotalCount",
                table: "CashSign");

            migrationBuilder.DropColumn(
                name: "SuccessTotalMoney",
                table: "CashSign");

            migrationBuilder.DropColumn(
                name: "UnkownTotalCount",
                table: "CashSign");

            migrationBuilder.DropColumn(
                name: "UnkownTotalMoney",
                table: "CashSign");
        }
    }
}
