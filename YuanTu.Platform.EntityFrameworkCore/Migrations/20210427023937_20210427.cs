using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210427 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "NameplateId",
                table: "STSerialNo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameplateId",
                table: "STSerialNo");

            migrationBuilder.AddColumn<string>(
                name: "STNameplateId",
                table: "STSerialNo",
                type: "varchar(255) CHARACTER SET utf8mb4",
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
    }
}
