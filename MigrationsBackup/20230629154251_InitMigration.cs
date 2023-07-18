using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillQuizLight.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamAnswer",
                columns: table => new
                {
                    ExamAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAnswerOk = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ExamQuestionID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamAnswer", x => x.ExamAnswerID);
                });

            migrationBuilder.CreateTable(
                name: "ExamDomain",
                columns: table => new
                {
                    ExamDomainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamDomain", x => x.ExamDomainID);
                });

            migrationBuilder.CreateTable(
                name: "ExamDomain_SubDomain",
                columns: table => new
                {
                    ExamDomain_SubDomainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamDomainID = table.Column<int>(type: "int", nullable: false),
                    ExamSubDomainID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamDomain_SubDomain", x => x.ExamDomain_SubDomainID);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion",
                columns: table => new
                {
                    ExamQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParamQuestionLevelID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion", x => x.ExamQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestion_Answer",
                columns: table => new
                {
                    ExamQuestion_AnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamQuestionID = table.Column<int>(type: "int", nullable: false),
                    ExamAnswerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestion_Answer", x => x.ExamQuestion_AnswerID);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestionnaire",
                columns: table => new
                {
                    ExamQuestionnaireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbQuestion = table.Column<int>(type: "int", nullable: false),
                    TotalTime = table.Column<int>(type: "int", nullable: false),
                    TotalPoint = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ExamDomainID = table.Column<int>(type: "int", nullable: false),
                    ExamSubDomainID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestionnaire", x => x.ExamQuestionnaireID);
                });

            migrationBuilder.CreateTable(
                name: "ExamQuestionnaire_Question",
                columns: table => new
                {
                    ExamQuestionnaire_QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamQuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamQuestionnaire_Question", x => x.ExamQuestionnaire_QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "ExamSubDomain",
                columns: table => new
                {
                    ExamSubDomainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSubDomain", x => x.ExamSubDomainID);
                });

            migrationBuilder.CreateTable(
                name: "ExamTest",
                columns: table => new
                {
                    ExamTestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWithChrono = table.Column<bool>(type: "bit", nullable: false),
                    IsQuestionRevise = table.Column<bool>(type: "bit", nullable: false),
                    NbQuestionRevise = table.Column<int>(type: "int", nullable: false),
                    TotalTime = table.Column<int>(type: "int", nullable: false),
                    TotalPoint = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTest", x => x.ExamTestID);
                });

            migrationBuilder.CreateTable(
                name: "ExamTest_Questionnaire",
                columns: table => new
                {
                    ExamTest_QuestionnaireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamTestID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestionnaireID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTest_Questionnaire", x => x.ExamTest_QuestionnaireID);
                });

            migrationBuilder.CreateTable(
                name: "ParamAnswerLevel",
                columns: table => new
                {
                    ParamAnswerLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbPoint = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamAnswerLevel", x => x.ParamAnswerLevelID);
                });

            migrationBuilder.CreateTable(
                name: "ParamLang",
                columns: table => new
                {
                    ParamLangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamLang", x => x.ParamLangID);
                });

            migrationBuilder.CreateTable(
                name: "ParamQuestionLevel",
                columns: table => new
                {
                    ParamQuestionLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbPoint = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamQuestionLevel", x => x.ParamQuestionLevelID);
                });

            migrationBuilder.CreateTable(
                name: "ParamTestStatus",
                columns: table => new
                {
                    ParamTestStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamTestStatus", x => x.ParamTestStatusID);
                });

            migrationBuilder.CreateTable(
                name: "ParamUsrType",
                columns: table => new
                {
                    UsrTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParamUsrType", x => x.UsrTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Usr",
                columns: table => new
                {
                    UsrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ParamLangID = table.Column<int>(type: "int", nullable: false),
                    ParamUsrTypeID = table.Column<int>(type: "int", nullable: false),
                    IsActivate = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsrID = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsrID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usr", x => x.UsrID);
                });

            migrationBuilder.CreateTable(
                name: "UsrAnswer",
                columns: table => new
                {
                    UsrAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    UsrExamID = table.Column<int>(type: "int", nullable: false),
                    ExamTest_QuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestionnaire_QuestionID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestion_AnswerID = table.Column<int>(type: "int", nullable: false),
                    ParamAnswerLevelID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsrAnswer", x => x.UsrAnswerID);
                });

            migrationBuilder.CreateTable(
                name: "UsrExam",
                columns: table => new
                {
                    UsrExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsrID = table.Column<int>(type: "int", nullable: false),
                    ExamTest_QuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    ParamTestStatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsrExam", x => x.UsrExamID);
                });

            migrationBuilder.CreateTable(
                name: "UsrQuestion",
                columns: table => new
                {
                    UsrQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOpen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsrExamID = table.Column<int>(type: "int", nullable: false),
                    ExamTest_QuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestionnaire_QuestionID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestion_AnswerID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUsr = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUsr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsrQuestion", x => x.UsrQuestionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamAnswer");

            migrationBuilder.DropTable(
                name: "ExamDomain");

            migrationBuilder.DropTable(
                name: "ExamDomain_SubDomain");

            migrationBuilder.DropTable(
                name: "ExamQuestion");

            migrationBuilder.DropTable(
                name: "ExamQuestion_Answer");

            migrationBuilder.DropTable(
                name: "ExamQuestionnaire");

            migrationBuilder.DropTable(
                name: "ExamQuestionnaire_Question");

            migrationBuilder.DropTable(
                name: "ExamSubDomain");

            migrationBuilder.DropTable(
                name: "ExamTest");

            migrationBuilder.DropTable(
                name: "ExamTest_Questionnaire");

            migrationBuilder.DropTable(
                name: "ParamAnswerLevel");

            migrationBuilder.DropTable(
                name: "ParamLang");

            migrationBuilder.DropTable(
                name: "ParamQuestionLevel");

            migrationBuilder.DropTable(
                name: "ParamTestStatus");

            migrationBuilder.DropTable(
                name: "ParamUsrType");

            migrationBuilder.DropTable(
                name: "Usr");

            migrationBuilder.DropTable(
                name: "UsrAnswer");

            migrationBuilder.DropTable(
                name: "UsrExam");

            migrationBuilder.DropTable(
                name: "UsrQuestion");
        }
    }
}
