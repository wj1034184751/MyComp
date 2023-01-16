using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class update20201010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskVsTerminal",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TaskId = table.Column<string>(nullable: true),
                    TriggerId = table.Column<string>(nullable: true),
                    OperationId = table.Column<string>(nullable: true),
                    TerminalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskVsTerminal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskVsTerminal");
        }
    }
}
