namespace SkillQuizLight.Models
{
    public class mUserAnswer_Display
    {
        public int? _ID { get; set; }
        public string? _Description { get; set; }
        public string? _Comment { get; set; }
        public bool? _IsSelectByUser { get; set; }
        public int? _tUserExamID { get; set; }
        public int? _tExamTest_QuestionnaireID { get; set; }
        public int? _tExamQuestionnaire_QuestionID { get; set; }
        public int? _tExamAnswerID { get; set; }
        public int? _tParamAnswerLevelID { get; set; }
    }
}
