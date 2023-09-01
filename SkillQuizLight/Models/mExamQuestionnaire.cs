namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamQuestionnaire
    {
        private int tExamDomainID { get; set; }
        private string Description { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mExamQuestionnaire() { }
        public mExamQuestionnaire(mExamQuestionnaire_Display pDisplay,int pUser)
        {
            Description = pDisplay._Description;
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamDomainID(int pVal) { this.tExamDomainID = pVal; }
        public int gettExamDomainID() {  return this.tExamDomainID; }

        public void setDescription(string pDescription) { this.Description = pDescription; }
        public string getDescription() { return this.Description; }

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
