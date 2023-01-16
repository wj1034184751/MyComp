using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20210730 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_STTerminalCustomEnum_TerminalId",
                table: "STTerminalCustomEnum",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_STTemplateCustomEnum_TemplateId",
                table: "STTemplateCustomEnum",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_STTerminalCustomEnum_TerminalId",
                table: "STTerminalCustomEnum");

            migrationBuilder.DropIndex(
                name: "IX_STTemplateCustomEnum_TemplateId",
                table: "STTemplateCustomEnum");
        }
    }
}
