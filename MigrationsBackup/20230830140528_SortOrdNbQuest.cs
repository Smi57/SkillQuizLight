using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillQuizLight.Migrations
{
    /// <inheritdoc />
    public partial class SortOrdNbQuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "tUserAnswer");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "tExamTest");

            migrationBuilder.DropColumn(
                name: "NbQuestion",
                table: "tExamQuestionnaire");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "tExamQuestionnaire");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "tExamAnswer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "tUserAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "tExamTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NbQuestion",
                table: "tExamQuestionnaire",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "tExamQuestionnaire",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "tExamAnswer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
