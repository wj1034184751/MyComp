using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class medical_update_0519 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedTransStatistics",
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
                    AreaCode = table.Column<string>(maxLength: 32, nullable: true),
                    HospId = table.Column<string>(maxLength: 64, nullable: true),
                    TerminalNo = table.Column<string>(maxLength: 64, nullable: true),
                    MedicareType = table.Column<string>(maxLength: 8, nullable: true),
                    SuccessCount = table.Column<int>(nullable: false),
                    FailCount = table.Column<int>(nullable: false),
                    SuccessAmt = table.Column<decimal>(nullable: false),
                    FailAmt = table.Column<decimal>(nullable: false),
                    Transdate = table.Column<string>(maxLength: 20, nullable: true),
                    Memo = table.Column<string>(maxLength: 200, nullable: true),
                    Extend = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedTransStatistics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedTransStatistics");
        }
    }
}
