namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamQuestion_Answer
    {
        public int tExamQuestion_AnswerID { get; set; }
        public int tExamQuestionID { get; set; }
        public int tExamAnswerID { get; set; }
        public DateTime CreatDate { get; set; }
        public int CreatUser { get; set; }
        public DateTime ModifDate { get; set; }
        public int ModifUser { get; set; }

        //Constructeurs
        public mExamQuestion_Answer() { }
        public mExamQuestion_Answer(mExamQuestion_Answer_Display pDisplay,int pUser)
        {
            tExamQuestionID = Convert.ToInt32(pDisplay._ID_Question);
            tExamAnswerID = Convert.ToInt32(pDisplay._ID_Answer);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamQuestion_AnswerID(int pVal) { this.tExamQuestion_AnswerID = pVal; }
        public int gettExamQuestion_AnswerID() {  return this.tExamQuestion_AnswerID; }

        public void settExamQuestionID(int pDescription) { this.tExamQuestionID = pDescription; }
        public int gettExamQuestionID() { return this.tExamQuestionID; }

        public void settExamAnswerID(int pDescription) { this.tExamAnswerID = pDescription; }
        public int gettExamAnswerID() { return this.tExamAnswerID; }

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
