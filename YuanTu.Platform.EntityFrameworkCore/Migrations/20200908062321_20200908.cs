using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200908 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_STTemplatePart_STTemplate_TemplateId",
            //    table: "STTemplatePart");

            //migrationBuilder.DropIndex(
            //    name: "IX_STTemplatePart_TemplateId",
            //    table: "STTemplatePart");

            //migrationBuilder.AddColumn<int>(
            //    name: "TemplateType",
            //    table: "STTemplate",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "AbsolutePath",
            //    table: "STPluginFileVersion",
            //    maxLength: 1024,
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "PluginType",
            //    table: "STPluginFileVersion",
            //    maxLength: 256,
            //    nullable: true);

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "EndTime",
            //    table: "CashTrade",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime(6)",
            //    oldMaxLength: 256);

            //migrationBuilder.AddColumn<int>(
            //    name: "Timeout",
            //    table: "AbpOrganizationUnits",
            //    nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateType",
                table: "STTemplate");

            migrationBuilder.DropColumn(
                name: "AbsolutePath",
                table: "STPluginFileVersion");

            migrationBuilder.DropColumn(
                name: "PluginType",
                table: "STPluginFileVersion");

            migrationBuilder.DropColumn(
                name: "Timeout",
                table: "AbpOrganizationUnits");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "CashTrade",
                type: "datetime(6)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_STTemplatePart_TemplateId",
                table: "STTemplatePart",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_STTemplatePart_STTemplate_TemplateId",
                table: "STTemplatePart",
                column: "TemplateId",
                principalTable: "STTemplate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
