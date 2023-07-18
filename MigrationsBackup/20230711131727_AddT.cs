using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillQuizLight.Migrations
{
    /// <inheritdoc />
    public partial class AddT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsrQuestion",
                table: "UsrQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsrExam",
                table: "UsrExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsrAnswer",
                table: "UsrAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usr",
                table: "Usr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParamUsrType",
                table: "ParamUsrType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParamTestStatus",
                table: "ParamTestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParamQuestionLevel",
                table: "ParamQuestionLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParamLang",
                table: "ParamLang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParamAnswerLevel",
                table: "ParamAnswerLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamTest_Questionnaire",
                table: "ExamTest_Questionnaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamTest",
                table: "ExamTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamSubDomain",
                table: "ExamSubDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestionnaire_Question",
                table: "ExamQuestionnaire_Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestionnaire",
                table: "ExamQuestionnaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestion_Answer",
                table: "ExamQuestion_Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamDomain_SubDomain",
                table: "ExamDomain_SubDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamDomain",
                table: "ExamDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExamAnswer",
                table: "ExamAnswer");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "CreatDate",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "CreatUsrID",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "IsActivate",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "ModifDate",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "ModifUsrID",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "ParamLangID",
                table: "Usr");

            migrationBuilder.DropColumn(
                name: "ParamUsrTypeID",
                table: "Usr");

            migrationBuilder.RenameTable(
                name: "UsrQuestion",
                newName: "tUsrQuestion");

            migrationBuilder.RenameTable(
                name: "UsrExam",
                newName: "tUsrExam");

            migrationBuilder.RenameTable(
                name: "UsrAnswer",
                newName: "tUsrAnswer");

            migrationBuilder.RenameTable(
                name: "Usr",
                newName: "tUsr");

            migrationBuilder.RenameTable(
                name: "ParamUsrType",
                newName: "tParamUsrType");

            migrationBuilder.RenameTable(
                name: "ParamTestStatus",
                newName: "tParamTestStatus");

            migrationBuilder.RenameTable(
                name: "ParamQuestionLevel",
                newName: "tParamQuestionLevel");

            migrationBuilder.RenameTable(
                name: "ParamLang",
                newName: "tParamLang");

            migrationBuilder.RenameTable(
                name: "ParamAnswerLevel",
                newName: "tParamAnswerLevel");

            migrationBuilder.RenameTable(
                name: "ExamTest_Questionnaire",
                newName: "tExamTest_Questionnaire");

            migrationBuilder.RenameTable(
                name: "ExamTest",
                newName: "tExamTest");

            migrationBuilder.RenameTable(
                name: "ExamSubDomain",
                newName: "tExamSubDomain");

            migrationBuilder.RenameTable(
                name: "ExamQuestionnaire_Question",
                newName: "tExamQuestionnaire_Question");

            migrationBuilder.RenameTable(
                name: "ExamQuestionnaire",
                newName: "tExamQuestionnaire");

            migrationBuilder.RenameTable(
                name: "ExamQuestion_Answer",
                newName: "tExamQuestion_Answer");

            migrationBuilder.RenameTable(
                name: "ExamQuestion",
                newName: "tExamQuestion");

            migrationBuilder.RenameTable(
                name: "ExamDomain_SubDomain",
                newName: "tExamDomain_SubDomain");

            migrationBuilder.RenameTable(
                name: "ExamDomain",
                newName: "tExamDomain");

            migrationBuilder.RenameTable(
                name: "ExamAnswer",
                newName: "tExamAnswer");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "tUsr",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tUsrQuestion",
                table: "tUsrQuestion",
                column: "UsrQuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tUsrExam",
                table: "tUsrExam",
                column: "UsrExamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tUsrAnswer",
                table: "tUsrAnswer",
                column: "UsrAnswerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tUsr",
                table: "tUsr",
                column: "UsrID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tParamUsrType",
                table: "tParamUsrType",
                column: "UsrTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tParamTestStatus",
                table: "tParamTestStatus",
                column: "ParamTestStatusID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tParamQuestionLevel",
                table: "tParamQuestionLevel",
                column: "ParamQuestionLevelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tParamLang",
                table: "tParamLang",
                column: "ParamLangID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tParamAnswerLevel",
                table: "tParamAnswerLevel",
                column: "ParamAnswerLevelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamTest_Questionnaire",
                table: "tExamTest_Questionnaire",
                column: "ExamTest_QuestionnaireID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamTest",
                table: "tExamTest",
                column: "ExamTestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamSubDomain",
                table: "tExamSubDomain",
                column: "ExamSubDomainID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamQuestionnaire_Question",
                table: "tExamQuestionnaire_Question",
                column: "ExamQuestionnaire_QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamQuestionnaire",
                table: "tExamQuestionnaire",
                column: "ExamQuestionnaireID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamQuestion_Answer",
                table: "tExamQuestion_Answer",
                column: "ExamQuestion_AnswerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamQuestion",
                table: "tExamQuestion",
                column: "ExamQuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamDomain_SubDomain",
                table: "tExamDomain_SubDomain",
                column: "ExamDomain_SubDomainID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamDomain",
                table: "tExamDomain",
                column: "ExamDomainID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tExamAnswer",
                table: "tExamAnswer",
                column: "ExamAnswerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tUsrQuestion",
                table: "tUsrQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tUsrExam",
                table: "tUsrExam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tUsrAnswer",
                table: "tUsrAnswer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tUsr",
                table: "tUsr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tParamUsrType",
                table: "tParamUsrType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tParamTestStatus",
                table: "tParamTestStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tParamQuestionLevel",
                table: "tParamQuestionLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tParamLang",
                table: "tParamLang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tParamAnswerLevel",
                table: "tParamAnswerLevel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamTest_Questionnaire",
                table: "tExamTest_Questionnaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamTest",
                table: "tExamTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamSubDomain",
                table: "tExamSubDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamQuestionnaire_Question",
                table: "tExamQuestionnaire_Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamQuestionnaire",
                table: "tExamQuestionnaire");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamQuestion_Answer",
                table: "tExamQuestion_Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamQuestion",
                table: "tExamQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamDomain_SubDomain",
                table: "tExamDomain_SubDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamDomain",
                table: "tExamDomain");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tExamAnswer",
                table: "tExamAnswer");

            migrationBuilder.RenameTable(
                name: "tUsrQuestion",
                newName: "UsrQuestion");

            migrationBuilder.RenameTable(
                name: "tUsrExam",
                newName: "UsrExam");

            migrationBuilder.RenameTable(
                name: "tUsrAnswer",
                newName: "UsrAnswer");

            migrationBuilder.RenameTable(
                name: "tUsr",
                newName: "Usr");

            migrationBuilder.RenameTable(
                name: "tParamUsrType",
                newName: "ParamUsrType");

            migrationBuilder.RenameTable(
                name: "tParamTestStatus",
                newName: "ParamTestStatus");

            migrationBuilder.RenameTable(
                name: "tParamQuestionLevel",
                newName: "ParamQuestionLevel");

            migrationBuilder.RenameTable(
                name: "tParamLang",
                newName: "ParamLang");

            migrationBuilder.RenameTable(
                name: "tParamAnswerLevel",
                newName: "ParamAnswerLevel");

            migrationBuilder.RenameTable(
                name: "tExamTest_Questionnaire",
                newName: "ExamTest_Questionnaire");

            migrationBuilder.RenameTable(
                name: "tExamTest",
                newName: "ExamTest");

            migrationBuilder.RenameTable(
                name: "tExamSubDomain",
                newName: "ExamSubDomain");

            migrationBuilder.RenameTable(
                name: "tExamQuestionnaire_Question",
                newName: "ExamQuestionnaire_Question");

            migrationBuilder.RenameTable(
                name: "tExamQuestionnaire",
                newName: "ExamQuestionnaire");

            migrationBuilder.RenameTable(
                name: "tExamQuestion_Answer",
                newName: "ExamQuestion_Answer");

            migrationBuilder.RenameTable(
                name: "tExamQuestion",
                newName: "ExamQuestion");

            migrationBuilder.RenameTable(
                name: "tExamDomain_SubDomain",
                newName: "ExamDomain_SubDomain");

            migrationBuilder.RenameTable(
                name: "tExamDomain",
                newName: "ExamDomain");

            migrationBuilder.RenameTable(
                name: "tExamAnswer",
                newName: "ExamAnswer");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Usr",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Usr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatDate",
                table: "Usr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatUsrID",
                table: "Usr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActivate",
                table: "Usr",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Usr",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifDate",
                table: "Usr",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifUsrID",
                table: "Usr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParamLangID",
                table: "Usr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParamUsrTypeID",
                table: "Usr",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsrQuestion",
                table: "UsrQuestion",
                column: "UsrQuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsrExam",
                table: "UsrExam",
                column: "UsrExamID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsrAnswer",
                table: "UsrAnswer",
                column: "UsrAnswerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usr",
                table: "Usr",
                column: "UsrID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParamUsrType",
                table: "ParamUsrType",
                column: "UsrTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParamTestStatus",
                table: "ParamTestStatus",
                column: "ParamTestStatusID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParamQuestionLevel",
                table: "ParamQuestionLevel",
                column: "ParamQuestionLevelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParamLang",
                table: "ParamLang",
                column: "ParamLangID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParamAnswerLevel",
                table: "ParamAnswerLevel",
                column: "ParamAnswerLevelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamTest_Questionnaire",
                table: "ExamTest_Questionnaire",
                column: "ExamTest_QuestionnaireID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamTest",
                table: "ExamTest",
                column: "ExamTestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamSubDomain",
                table: "ExamSubDomain",
                column: "ExamSubDomainID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestionnaire_Question",
                table: "ExamQuestionnaire_Question",
                column: "ExamQuestionnaire_QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestionnaire",
                table: "ExamQuestionnaire",
                column: "ExamQuestionnaireID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestion_Answer",
                table: "ExamQuestion_Answer",
                column: "ExamQuestion_AnswerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamQuestion",
                table: "ExamQuestion",
                column: "ExamQuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamDomain_SubDomain",
                table: "ExamDomain_SubDomain",
                column: "ExamDomain_SubDomainID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamDomain",
                table: "ExamDomain",
                column: "ExamDomainID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExamAnswer",
                table: "ExamAnswer",
                column: "ExamAnswerID");
        }
    }
}
