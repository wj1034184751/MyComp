using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class modify_stfuncconfig_ReferParentUniqueId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferParentUniqueId",
                table: "StFuncConfig",
                maxLength: 32,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferParentUniqueId",
                table: "StFuncConfig");
        }
    }
}
