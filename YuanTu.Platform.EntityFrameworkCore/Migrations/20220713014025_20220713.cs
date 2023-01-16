using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20220713 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {  
            migrationBuilder.CreateTable(
                name: "STTerminalDeptMap",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    OrgId = table.Column<long>(nullable: false),
                    TerminalId = table.Column<string>(maxLength: 32, nullable: false),
                    PriorityType = table.Column<byte>(nullable: false),
                    PriorityTypeDept = table.Column<string>(maxLength: 4000, nullable: true),
                    RestrictionType = table.Column<byte>(nullable: false),
                    RestrictionTypeDept = table.Column<string>(maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STTerminalDeptMap", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropTable(
                name: "STTerminalDeptMap");
        }
    }
}
