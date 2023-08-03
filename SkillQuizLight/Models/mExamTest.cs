namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamTest
    {
        private int tExamTestID { get; set; }
        private string Description { get; set; }
        private bool IsWithChrono { get; set; }
        private bool IsQuestionRevise { get; set; }
        private int NbQuestionRevise { get; set; }
        private int TotalTime { get; set; }
        private int TotalPoint { get; set; }
        private string Comment { get; set; }
        private int SortOrder { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mExamTest() { }
        public mExamTest(mExamTest_Display pDisplay,int pUser)
        {
            Description = pDisplay.Description;
            IsWithChrono = Convert.ToBoolean(pDisplay.IsWithChrono);
            IsQuestionRevise = Convert.ToBoolean(pDisplay.IsQuestionRevise);
            NbQuestionRevise = Convert.ToInt32(pDisplay.NbQuestionRevise);
            TotalTime = Convert.ToInt32(pDisplay.TotalTime);
            TotalPoint = Convert.ToInt32(pDisplay.TotalPoint);
            Comment = pDisplay.Comment;
            SortOrder = Convert.ToInt32(pDisplay.SortOrder);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamTestID(int pVal) { this.tExamTestID = pVal; }
        public int gettExamTestID() {  return this.tExamTestID; }

        public void setDescription(string pDescription) { this.Description = pDescription; }
        public string getDescription() { return this.Description; }

        public void setIsWithChrono(bool pVal) { this.IsWithChrono = pVal; }
        public bool getIsWithChronoD() { return this.IsWithChrono; }

        public void setIsQuestionRevise(bool pVal) { this.IsQuestionRevise = pVal; }
        public bool getIsQuestionRevise() { return this.IsQuestionRevise; }

        public void setNbQuestionRevise(int pVal) { this.NbQuestionRevise = pVal; }
        public int getNbQuestionRevise() { return this.NbQuestionRevise; }

        public void setTotalTime(int pVal) { this.TotalTime = pVal; }
        public int getTotalTime() { return this.TotalTime; }

        public void setTotalPoint(int pVal) { this.TotalPoint = pVal; }
        public int getTotalPoint() { return this.TotalPoint; }

        public void setComment(string pVal) { this.Comment = pVal; }
        public string getComment() { return this.Comment; }

        public void setSortOrder(int pVal) { this.SortOrder = pVal; }
        public int getSortOrder() { return this.SortOrder; }

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
