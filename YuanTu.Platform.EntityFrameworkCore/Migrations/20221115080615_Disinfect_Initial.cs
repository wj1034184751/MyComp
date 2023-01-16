using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class Disinfect_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisinfectId",
                table: "STTerminal",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StDisinfect",
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
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    PeriodFrequency = table.Column<string>(maxLength: 255, nullable: true),
                    PeriodTimes = table.Column<string>(maxLength: 255, nullable: true),
                    TerminalId = table.Column<string>(maxLength: 512, nullable: true),
                    DisableTime = table.Column<int>(nullable: false),
                    PlayVoice = table.Column<bool>(nullable: false),
                    VoiceText = table.Column<string>(maxLength: 255, nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StDisinfect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StDisinfectLog",
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
                    Time = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 255, nullable: true),
                    TerminalId = table.Column<string>(maxLength: 512, nullable: true),
                    PeriodFrequency = table.Column<string>(maxLength: 255, nullable: true),
                    PeriodTimes = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StDisinfectLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StDisinfect");

            migrationBuilder.DropTable(
                name: "StDisinfectLog");

            migrationBuilder.DropColumn(
                name: "DisinfectId",
                table: "STTerminal");
        }
    }
}
