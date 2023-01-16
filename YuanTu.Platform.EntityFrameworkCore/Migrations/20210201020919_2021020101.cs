using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class _2021020101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Extend2",
                table: "PosConfig",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1024) CHARACTER SET utf8mb4",
                oldMaxLength: 1024,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Extend2",
                table: "PosConfig",
                type: "varchar(1024) CHARACTER SET utf8mb4",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
