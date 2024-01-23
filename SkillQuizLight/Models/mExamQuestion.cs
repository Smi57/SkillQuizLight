using System.Runtime.CompilerServices;

namespace SkillQuizLight.Models
{
    //Attributs
    public class mExamQuestion
    {
        private int tExamQuestionID { get; set; }
        private string Description { get; set; }
        private int Time { get; set; }
        private int Weight { get; set; }
        private string Comment { get; set; }
        private int tParamQuestionLevelID { get; set; }
        private int tExamDomainID { get; set; }
        private int tExamSubDomainID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }


        //Constructeurs
        public mExamQuestion() { }
        public mExamQuestion(mExamQuestion_Display pDisplay,int pUser)
        {
            Description = pDisplay._Description;
            Time = Convert.ToInt32(pDisplay._Time);
            Weight = Convert.ToInt32(pDisplay._Weight);
            Comment = pDisplay._Comment;
            tParamQuestionLevelID = Convert.ToInt32(pDisplay._ID_Level_Question);
            tExamDomainID = Convert.ToInt32(pDisplay._ID_Domain);
            tExamSubDomainID = Convert.ToInt32(pDisplay._ID_Sub_Domain);
            CreatDate = DateTime.Now;
            CreatUser = pUser;
            ModifDate = DateTime.Now;
            ModifUser = pUser;
        }

        //Accesseurs
        public void settExamQuestionID(int pVal) { this.tExamQuestionID = pVal; }
        public int gettExamQuestionID() {  return this.tExamQuestionID; }

        public void setDescription(string pDescription) { this.Description = pDescription; }
        public string getDescription() { return this.Description; }

        public void setTime(int pVal) { this.Time = pVal; }
        public int getTime() { return this.Time; }

        public void setWeight(int pVal) { this.Weight = pVal; }
        public int getWeight() { return this.Weight; }

        public void setComment(string pVal) { this.Comment = pVal; }
        public string getComment() { return this.Comment; }

        public void setParamQuestionLevelID(int pVal) { this.tParamQuestionLevelID = pVal; }
        public int getParamQuestionLevelID() { return this.tParamQuestionLevelID; }

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
