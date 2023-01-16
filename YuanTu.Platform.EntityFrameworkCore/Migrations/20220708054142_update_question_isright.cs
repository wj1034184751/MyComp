using Microsoft.EntityFrameworkCore.Migrations;

namespace YuanTu.Platform.Migrations
{
    public partial class update_question_isright : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Em_Question");

            migrationBuilder.AddColumn<string>(
                name: "Answers",
                table: "Em_Question",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "Em_Question",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRight",
                table: "Em_Question",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Solution",
                table: "Em_Question",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answers",
                table: "Em_Question");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "Em_Question");

            migrationBuilder.DropColumn(
                name: "IsRight",
                table: "Em_Question");

            migrationBuilder.DropColumn(
                name: "Solution",
                table: "Em_Question");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Em_Question",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true);
        }
    }
}
