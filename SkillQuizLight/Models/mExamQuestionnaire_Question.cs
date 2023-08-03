namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamQuestionnaire_Question
    {
        private int tExamQuestionnaire_QuestionID { get; set; }
        private int tExamQuestionnaireID { get; set; }
        private int tExamQuestionID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mExamQuestionnaire_Question() { }
        public mExamQuestionnaire_Question(mExamQuestionnaire_Question_Display pDisplay,int pUser)
        {
            tExamQuestionnaireID = Convert.ToInt32(pDisplay.tExamQuestionnaireID);
            tExamQuestionID = Convert.ToInt32(pDisplay.tExamQuestionID);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamQuestionnaire_QuestionID(int pVal) { this.tExamQuestionnaire_QuestionID = pVal; }
        public int gettExamQuestionnaire_QuestionID() { return this.tExamQuestionnaire_QuestionID; }

        public void settExamQuestionnaireID(int pVal) { this.tExamQuestionnaireID = pVal; }
        public int gettExamQuestionnaireID() {  return this.tExamQuestionnaireID; }

        public void settExamQuestionID(int pVal) { this.tExamQuestionID = pVal; }
        public int gettExamQuestionID() { return this.tExamQuestionID; }

        public void setCreatDate(DateTime pCreationDate) { this.CreatDate = pCreationDate; }
        public DateTime getCreatDate() { return this.CreatDate; }

        public void setCreatUser(int pCreatUser) { this.CreatUser = pCreatUser; }
        public int getCreatUser() {  return this.CreatUser; }

        public void setModifDate(DateTime pModifDate) { this.ModifDate = pModifDate; }
        public DateTime getModifDate() {  return this.ModifDate; }

        public void setModifUser(int pModifUser) { this.ModifUser = pModifUser; }
        public int getModifUser() {  return this.ModifUser; }


        //Méthode
    }

}
