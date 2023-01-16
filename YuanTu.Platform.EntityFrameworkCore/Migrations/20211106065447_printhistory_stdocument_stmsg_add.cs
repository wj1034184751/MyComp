using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class printhistory_stdocument_stmsg_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrintHistory",
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
                    PrinterTypeId = table.Column<string>(maxLength: 32, nullable: true),
                    PrinterName = table.Column<string>(maxLength: 128, nullable: true),
                    STTerminalId = table.Column<string>(maxLength: 32, nullable: true),
                    BID = table.Column<string>(maxLength: 255, nullable: true),
                    IP = table.Column<string>(maxLength: 32, nullable: true),
                    Input = table.Column<string>(nullable: true),
                    PrintTemplateId = table.Column<string>(maxLength: 32, nullable: true),
                    PrintTemplateCode = table.Column<string>(maxLength: 128, nullable: true),
                    PrintTemplateName = table.Column<string>(maxLength: 128, nullable: true),
                    PageCount = table.Column<int>(nullable: false),
                    PaperSize = table.Column<string>(maxLength: 32, nullable: true),
                    ReportTime = table.Column<DateTime>(nullable: false),
                    PrintTime = table.Column<DateTime>(nullable: false),
                    BusinessTypeId = table.Column<string>(maxLength: 32, nullable: true),
                    TraceId = table.Column<string>(maxLength: 64, nullable: true),
                    PatientId = table.Column<string>(maxLength: 64, nullable: true),
                    PatientName = table.Column<string>(maxLength: 128, nullable: true),
                    IDCardNo = table.Column<string>(maxLength: 32, nullable: true),
                    SSCardNo = table.Column<string>(maxLength: 32, nullable: true),
                    IsPrinted = table.Column<bool>(nullable: false),
                    Dept_Id = table.Column<string>(nullable: true),
                    ReceiptTypeId = table.Column<string>(nullable: true),
                    PrintFailMsg = table.Column<string>(maxLength: 2048, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STDocument",
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
                    STDocumentCatalogId = table.Column<string>(maxLength: 32, nullable: false),
                    Caption = table.Column<string>(maxLength: 128, nullable: false),
                    Labels = table.Column<string>(maxLength: 128, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ClickNum = table.Column<int>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    IsSetTop = table.Column<bool>(nullable: false),
                    SetTopTime = table.Column<DateTime>(nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STDocumentCatalog",
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
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    STLanguageId = table.Column<string>(maxLength: 32, nullable: true),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STDocumentCatalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STMsgCatalog",
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
                    Prefix = table.Column<string>(maxLength: 2, nullable: false),
                    LevelCode = table.Column<string>(maxLength: 32, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Sort = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STMsgCatalog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "STMsgs",
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
                    STMsgCatalogId = table.Column<string>(maxLength: 32, nullable: false),
                    Code = table.Column<string>(maxLength: 8, nullable: false),
                    Reason = table.Column<string>(maxLength: 255, nullable: true),
                    Solution = table.Column<string>(maxLength: 255, nullable: true),
                    Link = table.Column<string>(maxLength: 255, nullable: true),
                    Field = table.Column<string>(maxLength: 255, nullable: true),
                    Script = table.Column<string>(maxLength: 2048, nullable: true),
                    STLanguageId = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STMsgs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrintHistory");

            migrationBuilder.DropTable(
                name: "STDocument");

            migrationBuilder.DropTable(
                name: "STDocumentCatalog");

            migrationBuilder.DropTable(
                name: "STMsgCatalog");

            migrationBuilder.DropTable(
                name: "STMsgs");
        }
    }
}
