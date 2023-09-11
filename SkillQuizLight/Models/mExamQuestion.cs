﻿using System.Runtime.CompilerServices;

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
        private int ParamQuestionLevelID { get; set; }
        private int ExamDomainID { get; set; }
        private int ExamSubDomainID { get; set; }
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
            ParamQuestionLevelID = Convert.ToInt32(pDisplay._ID_Level_Question);
            ExamDomainID = Convert.ToInt32(pDisplay._ID_Domain);
            ExamSubDomainID = Convert.ToInt32(pDisplay._ID_Sub_Domain);
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

        public void setParamQuestionLevelID(int pVal) { this.ParamQuestionLevelID = pVal; }
        public int getParamQuestionLevelID() { return this.ParamQuestionLevelID; }

        public void setExamDomainID(int pVal) { this.ExamDomainID = pVal; }
        public int getExamDomainID() { return this.ExamDomainID; }

        public void setExamSubDomainID(int pVal) { this.ExamSubDomainID = pVal; }
        public int getExamSubDomainID() { return this.ExamSubDomainID; }

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
