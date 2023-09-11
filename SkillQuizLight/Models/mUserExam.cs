namespace SkillQuizLight.Models
{
    //Attributs
    public class mUserExam
    {
        private int tUserExamID { get; set; }
        private DateTime Deadline { get; set; }
        private DateTime FinishedDate { get; set; }
        private string Comment { get; set; }
        private int tUserID { get; set; }
        private int tExamTestID { get; set; }
        private int tParamTestStatusID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mUserExam() { }
        public mUserExam(mUserExam_Display pDisplay,int pUser)
        {
            Deadline = Convert.ToDateTime(pDisplay._Dead_line);
            FinishedDate = Convert.ToDateTime(pDisplay._Finished_Date);
            Comment = pDisplay._Comment;
            tUserID = Convert.ToInt32(pDisplay._ID_User);
            tExamTestID = Convert.ToInt32(pDisplay._ID_Test);
            tParamTestStatusID = Convert.ToInt32(pDisplay._ID_Test_Status);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;

        }

        //Accesseurs
        public void settUserExamID(int pVal) { this.tUserExamID = pVal; }
        public int gettUserExamID() {  return this.tUserExamID; }

        public void setDeadline(DateTime pVal) { this.Deadline = pVal; }
        public DateTime getDeadline() { return this.Deadline; }

        public void setFinishedDate(DateTime pVal) { this.FinishedDate = pVal; }
        public DateTime getFinishedDate() { return this.FinishedDate; }

        public void setComment(string pVal) { this.Comment = pVal; }
        public string getComment() { return this.Comment; }

        public void settUserID(int pVal) { this.tUserID = pVal; }
        public int gettUserID() { return this.tUserID; }

        public void setExamTestID(int pVal) { this.tExamTestID = pVal; }
        public int getExamTestID() { return this.tExamTestID; }

        public void setParamTestStatusID(int pVal) { this.tParamTestStatusID = pVal; }
        public int getParamTestStatusID() { return this.tParamTestStatusID; }

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
