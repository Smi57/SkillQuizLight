namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamTest_Questionnaire
    {
        private int tExamTest_QuestionnaireID { get; set; }
        private int tExamTestID { get; set; }
        private int tExamQuestionnaireID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mExamTest_Questionnaire() { }
        public mExamTest_Questionnaire(mExamTest_Questionnaire_Display pDisplay,int pUser)
        {
            tExamTestID = Convert.ToInt32(pDisplay._ID_Test);
            tExamQuestionnaireID = Convert.ToInt32(pDisplay._ID_Questionnaire);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamTest_QuestionnaireID(int pVal) { this.tExamTest_QuestionnaireID = pVal; }
        public int gettExamTest_QuestionnaireID() {  return this.tExamTest_QuestionnaireID; }

        public void settExamTestID(int pVal) { this.tExamTestID = pVal; }
        public int gettExamTestID() { return this.tExamTestID; }

        public void settExamQuestionnaireID(int pVal) { this.tExamQuestionnaireID = pVal; }
        public int gettExamQuestionnaireID() { return this.tExamQuestionnaireID; }

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
