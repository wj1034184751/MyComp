using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2021042602 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameplateCode",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "NameplateId",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "NameplateName",
                table: "STSerialNo");

            migrationBuilder.AddColumn<string>(
                name: "STNameplateId",
                table: "STSerialNo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_STSerialNo_STNameplateId",
                table: "STSerialNo",
                column: "STNameplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_STSerialNo_STNameplate_STNameplateId",
                table: "STSerialNo",
                column: "STNameplateId",
                principalTable: "STNameplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_STSerialNo_STNameplate_STNameplateId",
                table: "STSerialNo");

            migrationBuilder.DropIndex(
                name: "IX_STSerialNo_STNameplateId",
                table: "STSerialNo");

            migrationBuilder.DropColumn(
                name: "STNameplateId",
                table: "STSerialNo");

            migrationBuilder.AddColumn<string>(
                name: "NameplateCode",
                table: "STSerialNo",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameplateId",
                table: "STSerialNo",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameplateName",
                table: "STSerialNo",
                type: "varchar(255) CHARACTER SET utf8mb4",
                maxLength: 255,
                nullable: true);
        }
    }
}
