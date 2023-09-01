using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillQuizLight.Migrations
{
    /// <inheritdoc />
    public partial class UpdIdDomSuDomInQuetAndTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Level",
                table: "tExamQuestion",
                newName: "ExamSubDomainID");

            migrationBuilder.AddColumn<int>(
                name: "ExamDomainID",
                table: "tExamTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExamSubDomainID",
                table: "tExamTest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExamDomainID",
                table: "tExamQuestion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExamDomainID",
                table: "tExamTest");

            migrationBuilder.DropColumn(
                name: "ExamSubDomainID",
                table: "tExamTest");

            migrationBuilder.DropColumn(
                name: "ExamDomainID",
                table: "tExamQuestion");

            migrationBuilder.RenameColumn(
                name: "ExamSubDomainID",
                table: "tExamQuestion",
                newName: "Level");
        }
    }
}
