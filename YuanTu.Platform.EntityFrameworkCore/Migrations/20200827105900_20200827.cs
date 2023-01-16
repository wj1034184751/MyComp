using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200827 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "UnionTransData",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "UnionConfigData",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STThermometer",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STTerminalPluginNet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STTerminalPlugin",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "STTerminalPlugin",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STTerminalPart",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STTerminal",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STTemplatePluginNet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STTemplatePlugin",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "STTemplatePlugin",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STTemplatePart",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STTemplate",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STSphygmomanometer",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STScanner",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STPrinter",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STPluginFolder",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STPluginFileVersion",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STPluginDetail",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STPlugin",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STOximeter",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STOther",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STLedScreen",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STKeyBoard",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STHeightAndWeight",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STECG",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "CashType",
                table: "STCashBox",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STCashBox",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "STCardReader",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STCardReader",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STCardDispenser",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "STCamera",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "MedTransStatistics",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "MedTransData",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "MedSigninfo",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "MedHisTransData",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "MedCheckExpData",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "MedCheckAccountinfo",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "HealthUserData",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "HealthConfig",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpZipLog",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpWardArea",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpTables",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpMenus",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpMenuFunc",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpLogs",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpCustomEnums",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpColumns",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OrgId",
                table: "AbpAttachment",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "UnionTransData");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "UnionConfigData");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STThermometer");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STTerminalPluginNet");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STTerminalPlugin");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "STTerminalPlugin");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STTerminalPart");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STTemplatePluginNet");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STTemplatePlugin");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "STTemplatePlugin");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STTemplatePart");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STTemplate");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STSphygmomanometer");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STScanner");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STPrinter");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STPluginFolder");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STPluginFileVersion");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STPluginDetail");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STPlugin");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STOximeter");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STOther");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STLedScreen");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STKeyBoard");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STHeightAndWeight");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STECG");

            migrationBuilder.DropColumn(
                name: "CashType",
                table: "STCashBox");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STCashBox");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STCardReader");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STCardDispenser");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "STCamera");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "MedTransStatistics");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "MedTransData");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "MedSigninfo");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "MedHisTransData");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "MedCheckExpData");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "MedCheckAccountinfo");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "HealthUserData");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "HealthConfig");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpZipLog");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpWardArea");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpTables");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpMenus");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpMenuFunc");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpLogs");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpCustomEnums");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpColumns");

            migrationBuilder.DropColumn(
                name: "OrgId",
                table: "AbpAttachment");

            migrationBuilder.AlterColumn<string>(
                name: "CardType",
                table: "STCardReader",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
