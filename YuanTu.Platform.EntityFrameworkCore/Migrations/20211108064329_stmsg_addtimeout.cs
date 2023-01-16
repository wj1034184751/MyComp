using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class stmsg_addtimeout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "STMsgType",
                table: "STMsgs",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Timeout",
                table: "STMsgs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "STMsgType",
                table: "STMsgs");

            migrationBuilder.DropColumn(
                name: "Timeout",
                table: "STMsgs");
        }
    }
}
