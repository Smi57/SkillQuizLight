namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamDomain_SubDomain
    {
        private int tExamDomain_SubDomainID { get; set; }
        private int tExamDomainID { get; set; }
        private int tExamSubDomainID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mExamDomain_SubDomain() { }
        public mExamDomain_SubDomain(mExamDomain_SubDomain_Display pDisplay,int pUser)
        {
            tExamDomainID = Convert.ToInt32(pDisplay._ID_Domain);
            tExamSubDomainID = Convert.ToInt32(pDisplay._ID_Sub_Domain);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamDomain_SubDomainID(int pVal) { this.tExamDomain_SubDomainID = pVal; }
        public int gettExamDomain_SubDomainID() { return this.tExamDomain_SubDomainID; }

        public void settExamDomainID(int pVal) { this.tExamDomainID = pVal; }
        public int gettExamDomainID() {  return this.tExamDomainID; }

        public void settExamSubDomainID(int pVal) { this.tExamSubDomainID = pVal; }
        public int gettExamSubDomainID() { return this.tExamSubDomainID; }

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
