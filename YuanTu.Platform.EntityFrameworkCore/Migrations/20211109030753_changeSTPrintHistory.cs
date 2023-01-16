using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class changeSTPrintHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PrintHistory",
                table: "PrintHistory");

            migrationBuilder.RenameTable(
                name: "PrintHistory",
                newName: "STPrintHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_STPrintHistory",
                table: "STPrintHistory",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_STPrintHistory",
                table: "STPrintHistory");

            migrationBuilder.RenameTable(
                name: "STPrintHistory",
                newName: "PrintHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrintHistory",
                table: "PrintHistory",
                column: "Id");
        }
    }
}
