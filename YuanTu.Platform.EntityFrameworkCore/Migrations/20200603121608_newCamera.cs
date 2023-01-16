using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class newCamera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STCamera",
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
                    Code = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    BrandId = table.Column<string>(maxLength: 256, nullable: true),
                    Model = table.Column<string>(maxLength: 256, nullable: true),
                    Port = table.Column<string>(maxLength: 256, nullable: true),
                    Baud = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STCamera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STLedScreen",
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
                    Code = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    BrandId = table.Column<string>(maxLength: 256, nullable: true),
                    Model = table.Column<string>(maxLength: 256, nullable: true),
                    Port = table.Column<string>(maxLength: 256, nullable: true),
                    Baud = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STLedScreen", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STCamera");

            migrationBuilder.DropTable(
                name: "STLedScreen");
        }
    }
}
