using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _20200624 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthUserData",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Sex = table.Column<byte>(nullable: false),
                    IdNo = table.Column<string>(maxLength: 32, nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    Height = table.Column<string>(maxLength: 32, nullable: true),
                    Weight = table.Column<string>(maxLength: 32, nullable: true),
                    Fat = table.Column<string>(maxLength: 32, nullable: true),
                    SaO2 = table.Column<string>(maxLength: 32, nullable: true),
                    Temperature = table.Column<string>(maxLength: 32, nullable: true),
                    BloodPressure = table.Column<string>(maxLength: 32, nullable: true),
                    Pulse = table.Column<string>(maxLength: 32, nullable: true),
                    Ecg = table.Column<string>(maxLength: 32, nullable: true),
                    HtTime = table.Column<int>(nullable: false),
                    SaO2Time = table.Column<int>(nullable: false),
                    TempTime = table.Column<int>(nullable: false),
                    BpTime = table.Column<int>(nullable: false),
                    FatTime = table.Column<int>(nullable: false),
                    EcgTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthUserData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthUserData_IdNo",
                table: "HealthUserData",
                column: "IdNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthUserData");
        }
    }
}
