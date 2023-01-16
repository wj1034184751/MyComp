using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20220719 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.CreateTable(
                name: "AdDeptExt",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DeptId = table.Column<long>(nullable: false),
                    GenderRestrictionType = table.Column<byte>(nullable: false),
                    MinAge = table.Column<int>(nullable: false),
                    MaxAge = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdDeptExt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdDoctExt",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DoctId = table.Column<long>(nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdDoctExt", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropTable(
                name: "AdDeptExt");

            migrationBuilder.DropTable(
                name: "AdDoctExt"); 
        }
    }
}
