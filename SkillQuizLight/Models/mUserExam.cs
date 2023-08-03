﻿namespace SkillQuizLight.Models
{
    //Attributs
    public class mUserExam
    {
        private int tUserExamID { get; set; }
        private DateTime Deadline { get; set; }
        private DateTime FinishedDate { get; set; }
        private string Comment { get; set; }
        private int tUserID { get; set; }
        private int ExamTest_QuestionnaireID { get; set; }
        private int ParamTestStatusID { get; set; }
        private DateTime CreatDate { get; set; }
        private int CreatUser { get; set; }
        private DateTime ModifDate { get; set; }
        private int ModifUser { get; set; }

        //Constructeurs
        public mUserExam() { }
        public mUserExam(mUserExam_Display pDisplay,int pUser)
        {
            Deadline = Convert.ToDateTime(pDisplay.Deadline);
            FinishedDate = Convert.ToDateTime(pDisplay.FinishedDate);
            Comment = pDisplay.Comment;
            tUserID = Convert.ToInt32(pDisplay.tUserID);
            ExamTest_QuestionnaireID = Convert.ToInt32(pDisplay.ExamTest_QuestionnaireID);
            ParamTestStatusID = Convert.ToInt32(pDisplay.ParamTestStatusID);
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

        public void setExamTest_QuestionnaireID(int pVal) { this.ExamTest_QuestionnaireID = pVal; }
        public int getExamTest_QuestionnaireID() { return this.ExamTest_QuestionnaireID; }

        public void setParamTestStatusID(int pVal) { this.ParamTestStatusID = pVal; }
        public int getParamTestStatusID() { return this.ParamTestStatusID; }

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