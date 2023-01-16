using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _202009240942 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Task",
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
                    TaskName = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<string>(maxLength: 10, nullable: true),
                    TriggerId = table.Column<string>(maxLength: 256, nullable: true),
                    OperationId = table.Column<string>(maxLength: 256, nullable: true),
                    NextStartTime = table.Column<DateTime>(nullable: false),
                    LastStartTime = table.Column<DateTime>(nullable: false),
                    LastStartResult = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskDetail",
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
                    StartPlan = table.Column<string>(maxLength: 100, nullable: true),
                    StartTime = table.Column<DateTime>(maxLength: 100, nullable: false),
                    EndTime = table.Column<DateTime>(maxLength: 100, nullable: false),
                    Interval = table.Column<string>(maxLength: 100, nullable: true),
                    Unit = table.Column<string>(maxLength: 100, nullable: true),
                    DetailWeek = table.Column<string>(maxLength: 100, nullable: true),
                    DetailMonth = table.Column<string>(maxLength: 100, nullable: true),
                    IsDelay = table.Column<bool>(nullable: false),
                    DelayTime = table.Column<string>(maxLength: 100, nullable: true),
                    IsRepeat = table.Column<string>(maxLength: 100, nullable: true),
                    RepeatInterval = table.Column<string>(maxLength: 100, nullable: true),
                    RepeatLastTime = table.Column<string>(maxLength: 100, nullable: true),
                    IsImplement = table.Column<bool>(maxLength: 100, nullable: false),
                    ExpireTime = table.Column<DateTime>(nullable: false),
                    IsEnable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskOperation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Operation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    FileExt = table.Column<string>(nullable: true),
                    ServerPath = table.Column<string>(nullable: true),
                    FileSize = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    HashCode = table.Column<string>(nullable: true),
                    LocalPath = table.Column<string>(nullable: true),
                    Params = table.Column<string>(nullable: true),
                    StartFrom = table.Column<string>(nullable: true),
                    TaskId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskTrigger",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartPlan = table.Column<string>(maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TaskId = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Frequency = table.Column<string>(maxLength: 50, nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    Interval = table.Column<string>(maxLength: 10, nullable: true),
                    IntervalUnit = table.Column<string>(maxLength: 10, nullable: true),
                    DetailWeek = table.Column<string>(maxLength: 256, nullable: true),
                    DetailMonth = table.Column<string>(maxLength: 256, nullable: true),
                    ExpectTime = table.Column<DateTime>(nullable: false),
                    IsDelay = table.Column<bool>(nullable: false),
                    Delay = table.Column<string>(maxLength: 10, nullable: true),
                    DelayUnit = table.Column<string>(maxLength: 10, nullable: true),
                    IsRepeat = table.Column<bool>(nullable: false),
                    RepeatInterval = table.Column<string>(maxLength: 10, nullable: true),
                    RepeatIntervalUnit = table.Column<string>(maxLength: 10, nullable: true),
                    RepeatLastTime = table.Column<string>(maxLength: 10, nullable: true),
                    DetailMonthDay = table.Column<string>(nullable: true),
                    PerUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTrigger", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TaskDetail");

            migrationBuilder.DropTable(
                name: "TaskOperation");

            migrationBuilder.DropTable(
                name: "TaskTrigger");
        }
    }
}
