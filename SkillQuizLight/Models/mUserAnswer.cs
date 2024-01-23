using System.Xml.Linq;

namespace SkillQuizLight.Models
{
    //Attributs
    public class mUserAnswer
    {
        private int tUserAnswerID { get; set; }
        private string Description { get; set; }
        private string Comment { get; set; }
        private bool IsSelectByUser { get; set; }
        private int tUserExamID { get; set; }
        private int tExamTest_QuestionnaireID { get; set; }
        private int tExamQuestionnaire_QuestionID { get; set; }
        private int tExamAnswerID { get; set; }
        private int tParamAnswerLevelID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mUserAnswer() { }
        public mUserAnswer(mUserAnswer_Display pDisplay,int pUser)
        {
            Description = pDisplay._Description;
            Comment = pDisplay._Comment;
            IsSelectByUser = Convert.ToBoolean(pDisplay._IsSelectByUser);
            tUserExamID = Convert.ToInt32(pDisplay._tUserExamID);
            tExamTest_QuestionnaireID = Convert.ToInt32(pDisplay._tExamTest_QuestionnaireID);
            tExamQuestionnaire_QuestionID = Convert.ToInt32(pDisplay._tExamQuestionnaire_QuestionID);
            tExamAnswerID = Convert.ToInt32(pDisplay._tExamAnswerID);
            tParamAnswerLevelID = Convert.ToInt32(pDisplay._tParamAnswerLevelID);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settUserDomainID(int pVal) { this.tUserAnswerID = pVal; }
        public int gettUserDomainID() {  return this.tUserAnswerID; }

        public void setDescription(string pDescription) { this.Description = pDescription; }
        public string getDescription() { return this.Description; }

        public void setComment(string pComment) { this.Comment = pComment; }
        public string getComment() { return this.Comment; }

        public void setIsSelectByUser(bool pVal) { this.IsSelectByUser = pVal; }
        public bool getIsSelectByUser() { return this.IsSelectByUser; }

        public void settUserExamID(int pVal) { this.tUserExamID = pVal; }
        public int gettUserExamID() { return this.tUserExamID; }

        public void settExamTest_QuestionnaireID(int pVal) { this.tExamTest_QuestionnaireID = pVal; }
        public int gettExamTest_QuestionnaireID() { return this.tExamTest_QuestionnaireID; }

        public void settExamQuestionnaire_QuestionID(int pVal) { this.tExamQuestionnaire_QuestionID = pVal; }
        public int gettExamQuestionnaire_QuestionID() { return this.tExamQuestionnaire_QuestionID; }

        public void settExamAnswerID(int pVal) { this.tExamAnswerID = pVal; }
        public int gettExamAnswerID() { return this.tExamAnswerID; }

        public void settParamAnswerLevelID(int pVal) { this.tParamAnswerLevelID = pVal; }
        public int gettParamAnswerLevelID() { return this.tParamAnswerLevelID; }

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
