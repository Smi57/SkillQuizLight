namespace SkillQuizLight.Models
{
    public class mUserExam_Display
    {
        public int? tUserExamID { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? FinishedDate { get; set; }
        public string? Comment { get; set; }
        public int? tUserID { get; set; }
        public int? ExamTest_QuestionnaireID { get; set; }
        public int? ParamTestStatusID { get; set; }
        public DateTime? CreatDate { get; set; }
        public int? CreatUser { get; set; }
        public DateTime? ModifDate { get; set; }
        public int? ModifUser { get; set; }
    }
}
