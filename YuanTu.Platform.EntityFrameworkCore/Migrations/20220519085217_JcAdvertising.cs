using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class JcAdvertising : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jc_Advertising",
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
                    Jc_AdvertisingCatalogId = table.Column<string>(maxLength: 32, nullable: false),
                    Caption = table.Column<string>(maxLength: 64, nullable: false),
                    SndCaption = table.Column<string>(maxLength: 64, nullable: true),
                    Labels = table.Column<string>(maxLength: 128, nullable: true),
                    Summary = table.Column<string>(maxLength: 512, nullable: true),
                    Carousel = table.Column<string>(nullable: true),
                    AttachmentTypeId = table.Column<string>(maxLength: 32, nullable: true),
                    AttachmentUrl = table.Column<string>(maxLength: 255, nullable: true),
                    AttachmentType = table.Column<string>(maxLength: 32, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ClickNum = table.Column<int>(nullable: false),
                    AdStatus = table.Column<string>(maxLength: 32, nullable: true),
                    AdStrategy = table.Column<string>(maxLength: 32, nullable: true),
                    AdMedium = table.Column<string>(maxLength: 32, nullable: true),
                    IsAllMedium = table.Column<bool>(nullable: false),
                    AdPage = table.Column<string>(maxLength: 32, nullable: true),
                    AdPos = table.Column<string>(maxLength: 32, nullable: true),
                    IsTop = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: true),
                    CheckTime = table.Column<DateTime>(nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    Printable = table.Column<bool>(nullable: false),
                    Downloadable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jc_Advertising", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jc_Advertising_Terminal",
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
                    Jc_AdvertisingId = table.Column<string>(maxLength: 32, nullable: false),
                    StTerminalId = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jc_Advertising_Terminal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jc_AdvertisingCatalog",
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
                    ParentId = table.Column<string>(nullable: true),
                    LevelCode = table.Column<string>(maxLength: 32, nullable: false),
                    Code = table.Column<string>(maxLength: 6, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    LanguageId = table.Column<string>(maxLength: 32, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jc_AdvertisingCatalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jc_UserEnum",
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
                    ParentId = table.Column<string>(nullable: true),
                    Code = table.Column<string>(maxLength: 128, nullable: false),
                    PrefixCode = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2048, nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    PinYin = table.Column<string>(maxLength: 128, nullable: true),
                    WuBi = table.Column<string>(maxLength: 128, nullable: true),
                    Tyzjm = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jc_UserEnum", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jc_Advertising");

            migrationBuilder.DropTable(
                name: "Jc_Advertising_Terminal");

            migrationBuilder.DropTable(
                name: "Jc_AdvertisingCatalog");

            migrationBuilder.DropTable(
                name: "Jc_UserEnum");
        }
    }
}
