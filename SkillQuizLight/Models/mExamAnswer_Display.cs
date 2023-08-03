namespace SkillQuizLight.Models
{
    public class mExamAnswer_Display
    {
        public int? tExamAnswerID { get; set; }
        public bool? IsAnswerOk { get; set; }
        public string? Description { get; set; }
        public string? Comment { get; set; }
        public int? SortOrder { get; set; }
        public int? ExamQuestionID { get; set; }
        public DateTime? CreatDate { get; set; }
        public string? CreatUser { get; set; }
        public DateTime? ModifDate { get; set; }
        public string? ModifUser { get; set; }

    }
}
