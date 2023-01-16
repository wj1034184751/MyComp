using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class add_exam_config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Em_Exam_Config",
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
                    Caption = table.Column<string>(maxLength: 128, nullable: true),
                    Decribe = table.Column<string>(maxLength: 512, nullable: true),
                    Author = table.Column<string>(maxLength: 32, nullable: true),
                    PublishTime = table.Column<DateTime>(nullable: false),
                    IsPublish = table.Column<bool>(nullable: false),
                    ExamType = table.Column<string>(maxLength: 32, nullable: true),
                    Sort = table.Column<int>(nullable: false),
                    IsFixTime = table.Column<bool>(nullable: false),
                    BeginTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    TotalTime = table.Column<int>(nullable: false),
                    IsForceSubmit = table.Column<bool>(nullable: false),
                    ExamMode = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Em_Exam_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Em_Exam_Outline_Config",
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
                    Caption = table.Column<string>(nullable: true),
                    TotalScore = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    Mid = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Em_Exam_Outline_Config", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Em_Exam_Outline_Question_Config",
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
                    Pid = table.Column<string>(maxLength: 32, nullable: true),
                    Mid = table.Column<string>(maxLength: 32, nullable: true),
                    Score = table.Column<int>(nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(maxLength: 32, nullable: true),
                    QuestionNum = table.Column<int>(nullable: false),
                    BusinessType = table.Column<string>(maxLength: 32, nullable: true),
                    TotalScore = table.Column<int>(nullable: false),
                    DifficultyDegree = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Em_Exam_Outline_Question_Config", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Em_Exam_Config");

            migrationBuilder.DropTable(
                name: "Em_Exam_Outline_Config");

            migrationBuilder.DropTable(
                name: "Em_Exam_Outline_Question_Config");
        }
    }
}
