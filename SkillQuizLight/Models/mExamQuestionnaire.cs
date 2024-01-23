namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamQuestionnaire
    {
        private int tExamQuestionnaireID { get; set; }
        private string Description { get; set; }
        private int TotalTime { get; set; }
        private int TotalPoint { get; set; }
        private int Weight { get; set; }
        private string Comment { get; set; }
        private int tExamDomainID { get; set; }
        private int tExamSubDomainID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mExamQuestionnaire() { }
        public mExamQuestionnaire(mExamQuestionnaire_Display pDisplay,int pUser)
        {
            Description = pDisplay._Description;
            TotalTime = Convert.ToInt32(pDisplay._TotalTime);
            TotalPoint = Convert.ToInt32(pDisplay._TotalPoint);
            Weight = Convert.ToInt32(pDisplay._Weight);
            Comment = pDisplay._Comment;
            tExamDomainID = Convert.ToInt32(pDisplay._ID_Domain);
            tExamSubDomainID = Convert.ToInt32(pDisplay._ID_Sub_Domain);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamQuestionnaireID(int pVal) { this.tExamQuestionnaireID = pVal; }
        public int gettExamQuestionnaireID() {  return this.tExamQuestionnaireID; }

        public void setDescription(string pDescription) { this.Description = pDescription; }
        public string getDescription() { return this.Description; }

        public void setTotalTime(int pVal) { this.TotalTime = pVal; }
        public int getTotalTime() { return this.TotalTime; }

        public void setTotalPoint(int pVal) { this.TotalPoint = pVal; }
        public int getTotalPoint() { return this.TotalPoint; }

        public void setWeight(int pVal) { this.Weight = pVal; }
        public int getWeight() { return this.Weight; }

        public void setComment(string pComment) { this.Comment = pComment; }
        public string getComment() { return this.Comment; }

        public void setExamDomainID(int pVal) { this.tExamDomainID = pVal; }
        public int getExamDomainID() { return this.tExamDomainID; }

        public void setExamSubDomainID(int pVal) { this.tExamSubDomainID = pVal; }
        public int getExamSubDomainID() { return this.tExamSubDomainID; }

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
