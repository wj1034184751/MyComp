using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020060301 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HospitalCode",
                table: "STTerminal",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SignDate",
                table: "STTerminal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "WardAreaId",
                table: "STTerminal",
                maxLength: 256,
                nullable: true); 

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "STPluginFileVersion",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AbpOrganizationUnits",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "DockMode",
                table: "AbpOrganizationUnits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalCode",
                table: "AbpOrganizationUnits",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfflineMode",
                table: "AbpOrganizationUnits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnionId",
                table: "AbpOrganizationUnits",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnionMode",
                table: "AbpOrganizationUnits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbpWardArea",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    BuildingId = table.Column<string>(maxLength: 256, nullable: true),
                    FloorId = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpWardArea", x => x.Id);
                }); 

            migrationBuilder.CreateIndex(
                name: "IX_AbpCustomEnums_ParentCode",
                table: "AbpCustomEnums",
                column: "ParentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpWardArea"); 

            migrationBuilder.DropIndex(
                name: "IX_AbpCustomEnums_ParentCode",
                table: "AbpCustomEnums");

            migrationBuilder.DropColumn(
                name: "HospitalCode",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "SignDate",
                table: "STTerminal");

            migrationBuilder.DropColumn(
                name: "WardAreaId",
                table: "STTerminal"); 

            migrationBuilder.DropColumn(
                name: "Path",
                table: "STPluginFileVersion");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "DockMode",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "HospitalCode",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "OfflineMode",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "UnionId",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "UnionMode",
                table: "AbpOrganizationUnits");
        }
    }
}
