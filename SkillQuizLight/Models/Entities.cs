using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SkillQuizLight.Models
{
    public class tUser
    {
        public int tUserID { get; set; }
        //[Column(TypeName = "varchar(50)")]
        public string Login { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public virtual string Password { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int AccessFailedCount { get; set; }
        public int ParamLangID { get; set; }
        public int ParamUserTypeID { get; set; }
        public bool IsActivate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUserID { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUserID { get; set; }
    }

    public class tUserAnswer
    {
        public int tUserAnswerID { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int SortOrder { get; set; }
        public int UserExamID { get; set; }
        public int ExamTest_QuestionnaireID { get; set; }
        public int ExamQuestionnaire_QuestionID { get; set; }
        public int ExamQuestion_AnswerID { get; set; }
        public int ParamAnswerLevelID { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tUserExam
    {
        public int tUserExamID { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime FinishedDate { get; set; }
        public string Comment { get; set; }
        public int tUserID { get; set; }
        public int ExamTest_QuestionnaireID { get; set; }
        public int ParamTestStatusID { get; set; }
    }
    public class tUserQuestion
    {
        public int tUserQuestionID { get; set; }
        public DateTime TimeOpen { get; set; }
        public int UserExamID { get; set; }
        public int ExamTest_QuestionnaireID { get; set; }
        public int ExamQuestionnaire_QuestionID { get; set; }
        public int ExamQuestion_AnswerID { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tParamAnswerLevel
    {
        public int tParamAnswerLevelID { get; set; }
        public string Description { get; set; }
        public int NbPoint { get; set; }
        public int Weight { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tParamLang
    {
        public int tParamLangID { get; set; }
        public string Description { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tParamQuestionLevel
    {
        public int tParamQuestionLevelID { get; set; }
        public string Description { get; set; }
        public int NbPoint { get; set; }
        public int Weight { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tParamTestStatus
    {
        public int tParamTestStatusID { get; set; }
        public string Description { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tParamUserType
    {
        public int tParamUserTypeID { get; set; }
        public string Description { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tExamAnswer
    {
        public int tExamAnswerID { get; set; }
        public bool IsAnswerOk { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public int SortOrder { get; set; }
        public int ExamQuestionID { get; set; }
        public DateTime CreatDate { get; set; }
        public string CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public string ModifUser { get; set; }
    }
    public class tExamDomain_SubDomain
    {
        public int tExamDomain_SubDomainID { get; set; }
        public int tExamDomainID { get; set; }
        public int tExamSubDomainID { get; set; }
    }
    public class tExamDomain
    {
        public int tExamDomainID { get; set; }
        public string Description { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tExamQuestion
    {
        public int tExamQuestionID { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Time { get; set; }
        public int Weight { get; set; }
        public string Comment { get; set; }
        public int ParamQuestionLevelID { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tExamQuestion_Answer
    {
        public int tExamQuestion_AnswerID { get; set; }
        public int tExamQuestionID { get; set; }
        public int tExamAnswerID { get; set; }
    }
    public class tExamQuestionnaire
    {
        public int tExamQuestionnaireID { get; set; }
        public string Description { get; set; }
        public int NbQuestion { get; set; }
        public int TotalTime { get; set; }
        public int TotalPoint { get; set; }
        public int Weight { get; set; }
        public string Comment { get; set; }
        public int SortOrder { get; set; }
        public int ExamDomainID { get; set; }
        public int ExamSubDomainID { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tExamQuestionnaire_Question
    {
        public int tExamQuestionnaire_QuestionID { get; set; }
        public int tExamQuestionnaireID { get; set; }
        public int tExamQuestionID { get; set; }
    }
    public class tExamSubDomain
    {
        public int tExamSubDomainID { get; set; }
        public string Description { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tExamTest
    {
        public int tExamTestID { get; set; }
        public string Description { get; set; }
        public bool IsWithChrono { get; set; }
        public bool IsQuestionRevise { get; set; }
        public int NbQuestionRevise { get; set; }
        public int TotalTime { get; set; }
        public int TotalPoint { get; set; }
        public string Comment { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }
    }
    public class tExamTest_Questionnaire
    {
        public int tExamTest_QuestionnaireID { get; set; }
        public int tExamTestID { get; set; }
        public int tExamQuestionnaireID { get; set; }
    }
}