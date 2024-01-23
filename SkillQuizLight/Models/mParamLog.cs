namespace SkillQuizLight.Models
{
    //Attributs
    public class mParamLog
    {
        private int tParamLogID { get; set; }
        private int tParamTypeLogID { get; set; }
        private string Info01 { get; set; }
        private string Info02 { get; set; }
        private string Info03 { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mParamLog() { }
        public mParamLog(mParamLog_Display pDisplay,int pUser)
        {
            tParamTypeLogID = Convert.ToInt32(pDisplay._tTypLogID);
            Info01 = pDisplay._Info01;
            Info02 = pDisplay._Info02;
            Info03 = pDisplay._Info03;
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settParamLogID(int pVal) { this.tParamLogID = pVal; }
        public int gettParamLogID() {  return this.tParamLogID; }

        public void settParamTypeLogID(int pVal) { this.tParamTypeLogID = pVal; }
        public int gettParamTypeLogID() { return this.tParamTypeLogID; }

        public void setInfo01(string pDescription) { this.Info01 = pDescription; }
        public string getInfo01() { return this.Info01; }

        public void setInfo02(string pDescription) { this.Info02 = pDescription; }
        public string getInfo02() { return this.Info02; }

        public void setInfo03(string pDescription) { this.Info03 = pDescription; }
        public string getInfo03() { return this.Info03; }

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
