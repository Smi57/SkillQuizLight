namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamAnswer
    {
        private int tExamAnswerID { get; set; }
        private bool IsAnswerOk { get; set; }
        private string Description { get; set; }
        private string Comment { get; set; }
        private int SortOrder { get; set; }
        private int ExamQuestionID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mExamAnswer() { }
        public mExamAnswer(mExamAnswer_Display pDisplay,int pUser)
        {
            IsAnswerOk = Convert.ToBoolean(pDisplay._IsAnswerOk);
            Description = pDisplay._Description;
            Comment = pDisplay._Comment;
            SortOrder = Convert.ToInt32(pDisplay._Sort_Order);
            ExamQuestionID = Convert.ToInt32(pDisplay._ID_Question);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamDomainID(int pVal) { this.tExamAnswerID = pVal; }
        public int gettExamDomainID() {  return this.tExamAnswerID; }

        public void setIsAnswerOk(bool pVal) { this.IsAnswerOk = pVal; }
        public bool getIsAnswerOk() { return this.IsAnswerOk; }

        public void setDescription(string pDescription) { this.Description = pDescription; }
        public string getDescription() { return this.Description; }

        public void setComment(string pVal) { this.Comment = pVal; }
        public string getComment() { return this.Comment; }

        public void setSortOrder(int pVal) { this.SortOrder = pVal; }
        public int getSortOrder() { return this.SortOrder; }

        public void setExamQuestionID(int pVal) { this.ExamQuestionID = pVal; }
        public int getExamQuestionID() { return this.ExamQuestionID; }

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
