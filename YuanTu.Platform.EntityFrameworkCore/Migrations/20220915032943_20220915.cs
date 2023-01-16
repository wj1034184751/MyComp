using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20220915 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankType",
                table: "PosTrade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                table: "PosTrade",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptType",
                table: "PosTrade",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientCardNo",
                table: "PosTrade",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TerminalNo",
                table: "PosTrade",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransSeq",
                table: "PosTrade",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankType",
                table: "PosTrade");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "PosTrade");

            migrationBuilder.DropColumn(
                name: "OptType",
                table: "PosTrade");

            migrationBuilder.DropColumn(
                name: "PatientCardNo",
                table: "PosTrade");

            migrationBuilder.DropColumn(
                name: "TerminalNo",
                table: "PosTrade");

            migrationBuilder.DropColumn(
                name: "TransSeq",
                table: "PosTrade");
        }
    }
}
