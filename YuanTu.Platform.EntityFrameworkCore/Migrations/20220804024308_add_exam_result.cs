using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class add_exam_result : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Em_Exam_Result",
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
                    ExaminerId = table.Column<long>(maxLength: 32, nullable: false),
                    TotalScore = table.Column<int>(nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    Em_Exam_ConfigId = table.Column<string>(nullable: false),
                    IsPractice = table.Column<bool>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Caption = table.Column<string>(maxLength: 128, nullable: false),
                    Examiner = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Em_Exam_Result", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Em_Exam_Result_Outline",
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
                    Em_Exam_Outline_ConfigId = table.Column<string>(nullable: false),
                    Caption = table.Column<string>(maxLength: 1024, nullable: false),
                    TotalScore = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Mid = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Em_Exam_Result_Outline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Em_Exam_Result_Outline_Question",
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
                    Em_QuestionId = table.Column<string>(maxLength: 32, nullable: false),
                    Mid = table.Column<string>(maxLength: 32, nullable: false),
                    Pid = table.Column<string>(maxLength: 32, nullable: false),
                    ConfirmAnswer = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Em_Exam_Result_Outline_Question", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Em_Exam_Result");

            migrationBuilder.DropTable(
                name: "Em_Exam_Result_Outline");

            migrationBuilder.DropTable(
                name: "Em_Exam_Result_Outline_Question");
        }
    }
}
