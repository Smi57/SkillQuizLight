using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillQuizLight.Migrations
{
    /// <inheritdoc />
    public partial class UpD_AddAllModDt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tExamAnswer");

            migrationBuilder.DropTable(
                name: "tExamDomain");

            migrationBuilder.DropTable(
                name: "tExamDomain_SubDomain");

            migrationBuilder.DropTable(
                name: "tExamQuestion");

            migrationBuilder.DropTable(
                name: "tExamQuestion_Answer");

            migrationBuilder.DropTable(
                name: "tExamQuestionnaire");

            migrationBuilder.DropTable(
                name: "tExamQuestionnaire_Question");

            migrationBuilder.DropTable(
                name: "tExamSubDomain");

            migrationBuilder.DropTable(
                name: "tExamTest");

            migrationBuilder.DropTable(
                name: "tExamTest_Questionnaire");

            migrationBuilder.DropTable(
                name: "tParamAnswerLevel");

            migrationBuilder.DropTable(
                name: "tParamLang");

            migrationBuilder.DropTable(
                name: "tParamQuestionLevel");

            migrationBuilder.DropTable(
                name: "tParamTestStatus");

            migrationBuilder.DropTable(
                name: "tParamUserType");

            migrationBuilder.DropTable(
                name: "tUserAnswer");

            migrationBuilder.DropTable(
                name: "tUserExam");

            migrationBuilder.DropTable(
                name: "tUserQuestion");

            migrationBuilder.CreateTable(
                name: "tExamAnswer",
                columns: table => new
                {
                    tExamAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAnswerOk = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    ExamQuestionID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamAnswer", x => x.tExamAnswerID);
                });

            migrationBuilder.CreateTable(
                name: "tExamDomain",
                columns: table => new
                {
                    tExamDomainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamDomain", x => x.tExamDomainID);
                });

            migrationBuilder.CreateTable(
                name: "tExamDomain_SubDomain",
                columns: table => new
                {
                    tExamDomain_SubDomainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tExamDomainID = table.Column<int>(type: "int", nullable: false),
                    tExamSubDomainID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamDomain_SubDomain", x => x.tExamDomain_SubDomainID);
                });

            migrationBuilder.CreateTable(
                name: "tExamQuestion",
                columns: table => new
                {
                    tExamQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParamQuestionLevelID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamQuestion", x => x.tExamQuestionID);
                });

            migrationBuilder.CreateTable(
                name: "tExamQuestion_Answer",
                columns: table => new
                {
                    tExamQuestion_AnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tExamQuestionID = table.Column<int>(type: "int", nullable: false),
                    tExamAnswerID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamQuestion_Answer", x => x.tExamQuestion_AnswerID);
                });

            migrationBuilder.CreateTable(
                name: "tExamQuestionnaire",
                columns: table => new
                {
                    tExamQuestionnaireID = table.Column<int>(type: "int", nullable: false)
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
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamQuestionnaire", x => x.tExamQuestionnaireID);
                });

            migrationBuilder.CreateTable(
                name: "tExamQuestionnaire_Question",
                columns: table => new
                {
                    tExamQuestionnaire_QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tExamQuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    tExamQuestionID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamQuestionnaire_Question", x => x.tExamQuestionnaire_QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "tExamSubDomain",
                columns: table => new
                {
                    tExamSubDomainID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamSubDomain", x => x.tExamSubDomainID);
                });

            migrationBuilder.CreateTable(
                name: "tExamTest",
                columns: table => new
                {
                    tExamTestID = table.Column<int>(type: "int", nullable: false)
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
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamTest", x => x.tExamTestID);
                });

            migrationBuilder.CreateTable(
                name: "tExamTest_Questionnaire",
                columns: table => new
                {
                    tExamTest_QuestionnaireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tExamTestID = table.Column<int>(type: "int", nullable: false),
                    tExamQuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExamTest_Questionnaire", x => x.tExamTest_QuestionnaireID);
                });

            migrationBuilder.CreateTable(
                name: "tParamAnswerLevel",
                columns: table => new
                {
                    tParamAnswerLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbPoint = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tParamAnswerLevel", x => x.tParamAnswerLevelID);
                });

            migrationBuilder.CreateTable(
                name: "tParamLang",
                columns: table => new
                {
                    tParamLangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tParamLang", x => x.tParamLangID);
                });

            migrationBuilder.CreateTable(
                name: "tParamQuestionLevel",
                columns: table => new
                {
                    tParamQuestionLevelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NbPoint = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tParamQuestionLevel", x => x.tParamQuestionLevelID);
                });

            migrationBuilder.CreateTable(
                name: "tParamTestStatus",
                columns: table => new
                {
                    tParamTestStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tParamTestStatus", x => x.tParamTestStatusID);
                });

            migrationBuilder.CreateTable(
                name: "tParamUserType",
                columns: table => new
                {
                    tParamUserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tParamUserType", x => x.tParamUserTypeID);
                });


            migrationBuilder.CreateTable(
                name: "tUserAnswer",
                columns: table => new
                {
                    tUserAnswerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    UserExamID = table.Column<int>(type: "int", nullable: false),
                    ExamTest_QuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestionnaire_QuestionID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestion_AnswerID = table.Column<int>(type: "int", nullable: false),
                    ParamAnswerLevelID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUserAnswer", x => x.tUserAnswerID);
                });

            migrationBuilder.CreateTable(
                name: "tUserExam",
                columns: table => new
                {
                    tUserExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tUserID = table.Column<int>(type: "int", nullable: false),
                    ExamTest_QuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    ParamTestStatusID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUserExam", x => x.tUserExamID);
                });

            migrationBuilder.CreateTable(
                name: "tUserQuestion",
                columns: table => new
                {
                    tUserQuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOpen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserExamID = table.Column<int>(type: "int", nullable: false),
                    ExamTest_QuestionnaireID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestionnaire_QuestionID = table.Column<int>(type: "int", nullable: false),
                    ExamQuestion_AnswerID = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatUser = table.Column<int>(type: "int", nullable: false),
                    ModifDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tUserQuestion", x => x.tUserQuestionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
