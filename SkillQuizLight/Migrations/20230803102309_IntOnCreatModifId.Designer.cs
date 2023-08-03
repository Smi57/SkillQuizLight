﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillQuizLight.Context;

#nullable disable

namespace SkillQuizLight.Migrations
{
    [DbContext(typeof(Db_SkillQuizLight))]
    [Migration("20230803102309_IntOnCreatModifId")]
    partial class IntOnCreatModifId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkillQuizLight.Models.tExamAnswer", b =>
                {
                    b.Property<int>("tExamAnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamAnswerID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExamQuestionID")
                        .HasColumnType("int");

                    b.Property<bool>("IsAnswerOk")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("tExamAnswerID");

                    b.ToTable("tExamAnswer");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamDomain", b =>
                {
                    b.Property<int>("tExamDomainID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamDomainID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.HasKey("tExamDomainID");

                    b.ToTable("tExamDomain");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamDomain_SubDomain", b =>
                {
                    b.Property<int>("tExamDomain_SubDomainID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamDomain_SubDomainID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("tExamDomainID")
                        .HasColumnType("int");

                    b.Property<int>("tExamSubDomainID")
                        .HasColumnType("int");

                    b.HasKey("tExamDomain_SubDomainID");

                    b.ToTable("tExamDomain_SubDomain");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamQuestion", b =>
                {
                    b.Property<int>("tExamQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamQuestionID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("ParamQuestionLevelID")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("tExamQuestionID");

                    b.ToTable("tExamQuestion");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamQuestion_Answer", b =>
                {
                    b.Property<int>("tExamQuestion_AnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamQuestion_AnswerID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("tExamAnswerID")
                        .HasColumnType("int");

                    b.Property<int>("tExamQuestionID")
                        .HasColumnType("int");

                    b.HasKey("tExamQuestion_AnswerID");

                    b.ToTable("tExamQuestion_Answer");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamQuestionnaire", b =>
                {
                    b.Property<int>("tExamQuestionnaireID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamQuestionnaireID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExamDomainID")
                        .HasColumnType("int");

                    b.Property<int>("ExamSubDomainID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("NbQuestion")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("TotalPoint")
                        .HasColumnType("int");

                    b.Property<int>("TotalTime")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("tExamQuestionnaireID");

                    b.ToTable("tExamQuestionnaire");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamQuestionnaire_Question", b =>
                {
                    b.Property<int>("tExamQuestionnaire_QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamQuestionnaire_QuestionID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("tExamQuestionID")
                        .HasColumnType("int");

                    b.Property<int>("tExamQuestionnaireID")
                        .HasColumnType("int");

                    b.HasKey("tExamQuestionnaire_QuestionID");

                    b.ToTable("tExamQuestionnaire_Question");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamSubDomain", b =>
                {
                    b.Property<int>("tExamSubDomainID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamSubDomainID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.HasKey("tExamSubDomainID");

                    b.ToTable("tExamSubDomain");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamTest", b =>
                {
                    b.Property<int>("tExamTestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamTestID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsQuestionRevise")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWithChrono")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("NbQuestionRevise")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("TotalPoint")
                        .HasColumnType("int");

                    b.Property<int>("TotalTime")
                        .HasColumnType("int");

                    b.HasKey("tExamTestID");

                    b.ToTable("tExamTest");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tExamTest_Questionnaire", b =>
                {
                    b.Property<int>("tExamTest_QuestionnaireID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tExamTest_QuestionnaireID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("tExamQuestionnaireID")
                        .HasColumnType("int");

                    b.Property<int>("tExamTestID")
                        .HasColumnType("int");

                    b.HasKey("tExamTest_QuestionnaireID");

                    b.ToTable("tExamTest_Questionnaire");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tParamAnswerLevel", b =>
                {
                    b.Property<int>("tParamAnswerLevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tParamAnswerLevelID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("NbPoint")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("tParamAnswerLevelID");

                    b.ToTable("tParamAnswerLevel");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tParamLang", b =>
                {
                    b.Property<int>("tParamLangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tParamLangID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.HasKey("tParamLangID");

                    b.ToTable("tParamLang");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tParamQuestionLevel", b =>
                {
                    b.Property<int>("tParamQuestionLevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tParamQuestionLevelID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("NbPoint")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("tParamQuestionLevelID");

                    b.ToTable("tParamQuestionLevel");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tParamTestStatus", b =>
                {
                    b.Property<int>("tParamTestStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tParamTestStatusID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.HasKey("tParamTestStatusID");

                    b.ToTable("tParamTestStatus");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tParamUserType", b =>
                {
                    b.Property<int>("tParamUserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tParamUserTypeID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.HasKey("tParamUserTypeID");

                    b.ToTable("tParamUserType");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tUser", b =>
                {
                    b.Property<int>("tUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tUserID"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUserID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivate")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUserID")
                        .HasColumnType("int");

                    b.Property<int>("ParamLangID")
                        .HasColumnType("int");

                    b.Property<int>("ParamUserTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("tUserID");

                    b.ToTable("tUser");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tUserAnswer", b =>
                {
                    b.Property<int>("tUserAnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tUserAnswerID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExamQuestion_AnswerID")
                        .HasColumnType("int");

                    b.Property<int>("ExamQuestionnaire_QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("ExamTest_QuestionnaireID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("ParamAnswerLevelID")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<int>("UserExamID")
                        .HasColumnType("int");

                    b.HasKey("tUserAnswerID");

                    b.ToTable("tUserAnswer");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tUserExam", b =>
                {
                    b.Property<int>("tUserExamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tUserExamID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExamTest_QuestionnaireID")
                        .HasColumnType("int");

                    b.Property<DateTime>("FinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<int>("ParamTestStatusID")
                        .HasColumnType("int");

                    b.Property<int>("tUserID")
                        .HasColumnType("int");

                    b.HasKey("tUserExamID");

                    b.ToTable("tUserExam");
                });

            modelBuilder.Entity("SkillQuizLight.Models.tUserQuestion", b =>
                {
                    b.Property<int>("tUserQuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("tUserQuestionID"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatUser")
                        .HasColumnType("int");

                    b.Property<int>("ExamQuestion_AnswerID")
                        .HasColumnType("int");

                    b.Property<int>("ExamQuestionnaire_QuestionID")
                        .HasColumnType("int");

                    b.Property<int>("ExamTest_QuestionnaireID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModifUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOpen")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserExamID")
                        .HasColumnType("int");

                    b.HasKey("tUserQuestionID");

                    b.ToTable("tUserQuestion");
                });
#pragma warning restore 612, 618
        }
    }
}