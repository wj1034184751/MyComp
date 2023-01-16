using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2020080401 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STECG",
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
                    CommunicationType = table.Column<string>(nullable: true),
                    Port = table.Column<string>(maxLength: 256, nullable: true),
                    IsUsbToPort = table.Column<bool>(nullable: false),
                    Baud = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STECG", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STHeightAndWeight",
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
                    CommunicationType = table.Column<string>(nullable: true),
                    Port = table.Column<string>(maxLength: 256, nullable: true),
                    IsUsbToPort = table.Column<bool>(nullable: false),
                    Baud = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STHeightAndWeight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STOther",
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
                    CommunicationType = table.Column<string>(nullable: true),
                    Port = table.Column<string>(maxLength: 256, nullable: true),
                    IsUsbToPort = table.Column<bool>(nullable: false),
                    Baud = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOther", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STOximeter",
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
                    CommunicationType = table.Column<string>(nullable: true),
                    Port = table.Column<string>(maxLength: 256, nullable: true),
                    IsUsbToPort = table.Column<bool>(nullable: false),
                    Baud = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STOximeter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STSphygmomanometer",
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
                    CommunicationType = table.Column<string>(nullable: true),
                    Port = table.Column<string>(maxLength: 256, nullable: true),
                    IsUsbToPort = table.Column<bool>(nullable: false),
                    Baud = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STSphygmomanometer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STThermometer",
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
                    CommunicationType = table.Column<string>(nullable: true),
                    Port = table.Column<string>(maxLength: 256, nullable: true),
                    IsUsbToPort = table.Column<bool>(nullable: false),
                    Baud = table.Column<string>(maxLength: 256, nullable: true),
                    Version = table.Column<string>(maxLength: 256, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STThermometer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STECG");

            migrationBuilder.DropTable(
                name: "STHeightAndWeight");

            migrationBuilder.DropTable(
                name: "STOther");

            migrationBuilder.DropTable(
                name: "STOximeter");

            migrationBuilder.DropTable(
                name: "STSphygmomanometer");

            migrationBuilder.DropTable(
                name: "STThermometer");
        }
    }
}
