using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020091801 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "FireWall",
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
                 Name = table.Column<string>(maxLength: 32, nullable: true),
                 Range = table.Column<string>(maxLength: 32, nullable: true),
                 Path = table.Column<string>(maxLength: 128, nullable: true),
                 Deal = table.Column<string>(maxLength: 32, nullable: true),
                 LocalAddress = table.Column<string>(maxLength: 32, nullable: true),
                 LocalPort = table.Column<string>(maxLength: 32, nullable: true),
                 RemoteAddress = table.Column<string>(maxLength: 32, nullable: true),
                 RemotePort = table.Column<string>(maxLength: 32, nullable: true),
                 Rules = table.Column<string>(maxLength: 32, nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_FireWall", x => x.Id);
             });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "FireWall");
        }
    }
}
