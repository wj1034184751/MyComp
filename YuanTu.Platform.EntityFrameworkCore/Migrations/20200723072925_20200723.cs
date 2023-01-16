using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200723 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "IsUsbToPort",
                table: "STScanner");

            migrationBuilder.DropColumn(
                name: "CommunicationType",
                table: "STPrinter");

            migrationBuilder.DropColumn(
                name: "IsUsbToPort",
                table: "STPrinter");

            migrationBuilder.DropColumn(
                name: "CommunicationType",
                table: "STLedScreen");

            migrationBuilder.DropColumn(
                name: "IsUsbToPort",
                table: "STLedScreen");

            migrationBuilder.DropColumn(
                name: "CommunicationType",
                table: "STKeyBoard");

            migrationBuilder.DropColumn(
                name: "IsUsbToPort",
                table: "STKeyBoard");

            migrationBuilder.DropColumn(
                name: "CommunicationType",
                table: "STCashBox");

            migrationBuilder.DropColumn(
                name: "IsUsbToPort",
                table: "STCashBox");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "STCardReader");

            migrationBuilder.DropColumn(
                name: "CommunicationType",
                table: "STCardReader");

            migrationBuilder.DropColumn(
                name: "IsUsbToPort",
                table: "STCardReader");

            migrationBuilder.DropColumn(
                name: "CardType",
                table: "STCardDispenser");

            migrationBuilder.DropColumn(
                name: "CommunicationType",
                table: "STCardDispenser");

            migrationBuilder.DropColumn(
                name: "IsUsbToPort",
                table: "STCardDispenser");

            migrationBuilder.DropColumn(
                name: "Print",
                table: "STCardDispenser");

            migrationBuilder.DropColumn(
                name: "CommunicationType",
                table: "STCamera");

            migrationBuilder.DropColumn(
                name: "IsUsbToPort",
                table: "STCamera");

            migrationBuilder.DropColumn(
                name: "UploadFlag",
                table: "MedTransData");

            migrationBuilder.DropColumn(
                name: "Channel",
                table: "MedHisTransData");

            migrationBuilder.DropColumn(
                name: "UploadFlag",
                table: "MedHisTransData");

            migrationBuilder.DropColumn(
                name: "Channel",
                table: "MedCheckExpData");

            migrationBuilder.DropColumn(
                name: "IsOpt",
                table: "MedCheckExpData");

            migrationBuilder.DropColumn(
                name: "OptExpType",
                table: "MedCheckExpData");

            migrationBuilder.DropColumn(
                name: "Channel",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "CheckErrorType",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "CheckTransType",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "DiffAllAmount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "DiffOverallAmount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "DiffSelfAmount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "HisAllCount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "MedAllCount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "PluginAllAmount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "PluginAllCount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "PluginOverallAmount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "PluginSelfAmount",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "ErrLevel",
                table: "AbpLogs");

            migrationBuilder.DropColumn(
                name: "ErrMsg",
                table: "AbpLogs");

            migrationBuilder.DropColumn(
                name: "ErrStackTrace",
                table: "AbpLogs");

            migrationBuilder.DropColumn(
                name: "ExecutionTime",
                table: "AbpLogs");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AbpLogs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
