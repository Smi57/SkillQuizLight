namespace SkillQuizLight.Models
{
    //Attributs
    public class mUserQuestion
    {
        private int tUserQuestionID { get; set; }
        private int TimeOpen { get; set; }
        private int tUserExamID { get; set; }
        private int tExamTest_QuestionnaireID { get; set; }
        private int tExamQuestionnaire_QuestionID { get; set; }
        private int tExamQuestionID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mUserQuestion() { }
        public mUserQuestion(mUserQuestion_Display pDisplay,int pUser)
        {
            TimeOpen = Convert.ToInt32(pDisplay._TimeOpen);
            tUserExamID = Convert.ToInt32(pDisplay._tUserExamID);
            tExamTest_QuestionnaireID = Convert.ToInt32(pDisplay._tExamTest_QuestionnaireID);
            tExamQuestionnaire_QuestionID = Convert.ToInt32(pDisplay._tExamQuestionnaire_QuestionID);
            tExamQuestionID = Convert.ToInt32(pDisplay._tExamQuestionID);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settUserQuestionID(int pVal) { this.tUserQuestionID = pVal; }
        public int gettUserQuestionID() {  return this.tUserQuestionID; }

        public void setTimeOpen(int pVal) { this.TimeOpen = pVal; }
        public int getTimeOpen() { return this.TimeOpen; }

        public void settUserExamID(int pVal) { this.tUserExamID = pVal; }
        public int gettUserExamID() { return this.tUserExamID; }

        public void settExamTest_QuestionnaireID(int pVal) { this.tExamTest_QuestionnaireID = pVal; }
        public int gettExamTest_QuestionnaireID() { return this.tExamTest_QuestionnaireID; }

        public void settExamQuestionnaire_QuestionID(int pVal) { this.tExamQuestionnaire_QuestionID = pVal; }
        public int gettExamQuestionnaire_QuestionID() { return this.tExamQuestionnaire_QuestionID; }

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
