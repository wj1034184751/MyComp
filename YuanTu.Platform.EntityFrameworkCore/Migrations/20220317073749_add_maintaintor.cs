using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class add_maintaintor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StMaintainLogs",
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
                    OrgId = table.Column<long>(nullable: false),
                    TerminalId = table.Column<string>(maxLength: 32, nullable: true),
                    TerminalCode = table.Column<string>(maxLength: 64, nullable: true),
                    OperateTime = table.Column<DateTime>(nullable: false),
                    StMaintaintorId = table.Column<string>(maxLength: 32, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    IdNo = table.Column<string>(maxLength: 32, nullable: true),
                    CardNo = table.Column<string>(maxLength: 64, nullable: true),
                    Phone = table.Column<string>(maxLength: 32, nullable: true),
                    PatientId = table.Column<string>(maxLength: 32, nullable: true),
                    SourceTypeId = table.Column<string>(maxLength: 32, nullable: true),
                    OperateTypeId = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StMaintainLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StMaintains",
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
                    OrgId = table.Column<long>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IdNo = table.Column<string>(maxLength: 32, nullable: true),
                    CardNo = table.Column<string>(maxLength: 64, nullable: true),
                    Phone = table.Column<string>(maxLength: 32, nullable: true),
                    Password = table.Column<string>(maxLength: 32, nullable: true),
                    PatientId = table.Column<string>(maxLength: 32, nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StMaintains", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StMaintainLogs");

            migrationBuilder.DropTable(
                name: "StMaintains");
        }
    }
}
