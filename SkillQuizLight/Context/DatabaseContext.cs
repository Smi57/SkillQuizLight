using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SkillQuizLight.Models;
using SkillQuizLight.Context;

namespace SkillQuizLight.Context
{
    public class Db_SkillQuizLight : DbContext
    {
        public Db_SkillQuizLight()
        {
        }

        public Db_SkillQuizLight(DbContextOptions<Db_SkillQuizLight> options) : base(options)
        {
        }

        public DbSet<tUser> tUser { get; set; }
        public DbSet<tUserAnswer> tUserAnswer { get; set; }
        public DbSet<tUserExam> tUserExam { get; set; }
        public DbSet<tUserQuestion> tUserQuestion { get; set; }
        public DbSet<tParamAnswerLevel> tParamAnswerLevel { get; set; }
        public DbSet<tParamLang> tParamLang { get; set; }
        public DbSet<tParamLog> tParamLog { get; set; }
        public DbSet<tParamQuestionLevel> tParamQuestionLevel { get; set; }
        public DbSet<tParamTestStatus> tParamTestStatus { get; set; }
        public DbSet<tParamTypeLog> tParamTypeLog { get; set; }
        public DbSet<tParamUserType> tParamUserType { get; set; }
        public DbSet<tExamAnswer> tExamAnswer { get; set; }
        public DbSet<tExamDomain_SubDomain> tExamDomain_SubDomain { get; set; }
        public DbSet<tExamDomain> tExamDomain { get; set; }
        public DbSet<tExamQuestion> tExamQuestion { get; set; }
        public DbSet<tExamQuestion_Answer> tExamQuestion_Answer { get; set; }
        public DbSet<tExamQuestionnaire> tExamQuestionnaire { get; set; }
        public DbSet<tExamQuestionnaire_Question> tExamQuestionnaire_Question { get; set; }
        public DbSet<tExamSubDomain> tExamSubDomain { get; set; }
        public DbSet<tExamTest> tExamTest { get; set; }
        public DbSet<tExamTest_Questionnaire> tExamTest_Questionnaire { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=LAP-2017-SMI\\SQLEXPRESS;Database=_Db_SkillQuizLight;Trusted_connection=true;Encrypt=False");
    }
}
