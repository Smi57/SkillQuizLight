using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Models;
using SkillQuizLight.Context;


namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamQuestionController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getQuestionID/{ID}")]
        public string[] getQuestionID(int ID)
        {
            mExamQuestion QuestionRes = new mExamQuestion();
            var QuestionTmp = db.tExamQuestion
                            .Where(b => b.tExamQuestionID == ID)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (QuestionTmp != null)
            {
                vResTab = new string[]{ QuestionTmp.tExamQuestionID.ToString(),
                                            QuestionTmp.Description,
                                            QuestionTmp.Time.ToString(),
                                            QuestionTmp.Weight.ToString(),
                                            QuestionTmp.Comment.ToString(),
                                            QuestionTmp.tParamQuestionLevelID.ToString(),
                                            QuestionTmp.tExamDomainID.ToString(),
                                            QuestionTmp.tExamSubDomainID.ToString(),
                                            QuestionTmp.CreatDate.ToString(),
                                            QuestionTmp.CreatUser.ToString(),
                                            QuestionTmp.ModifDate.ToString(),
                                            QuestionTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getQuestion_IdQuestionaire/{pIdQuestionaire}")]
        public List<mExamQuestion_Display> getQuestion_IdQuestionaire(int pIdQuestionaire)
        {
            //return db.tExamQuestion.Select(u => new mExamQuestion_Display()
            return (from a in db.tExamQuestion
                    join b in db.tExamDomain on a.tExamDomainID equals b.tExamDomainID
                    join c in db.tExamSubDomain on a.tExamSubDomainID equals c.tExamSubDomainID
                    join d in db.tExamQuestionnaire_Question on a.tExamQuestionID equals d.tExamQuestionID
                    where d.tExamQuestionnaireID == pIdQuestionaire
                    select new
                    {
                        a.tExamQuestionID,
                        a.Description,
                        a.Time,
                        a.Weight,
                        a.Comment,
                        a.tParamQuestionLevelID,
                        Desc2 = b.Description,
                        a.tExamDomainID,
                        Desc3 = c.Description,
                        a.tExamSubDomainID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser
                    }).Select(u => new mExamQuestion_Display()
                    {

                        _ID = u.tExamQuestionID,
                        _Description = u.Description,
                        _Time = u.Time,
                        _Weight = u.Weight,
                        _Comment = u.Comment,
                        _ID_Level_Question = u.tParamQuestionLevelID,
                        _Domain = u.Desc2,
                        _ID_Domain = u.tExamDomainID,
                        _Sub_Domain = u.Desc3,
                        _ID_Sub_Domain = u.tExamSubDomainID

                    }).ToList();
        }

        [HttpGet("getQuestion")]
        public List<mExamQuestion_Display> getQuestion()
        {
            //return db.tExamQuestion.Select(u => new mExamQuestion_Display()
            return (from a in db.tExamQuestion
                    join b in db.tExamDomain on a.tExamDomainID equals b.tExamDomainID
                    join c in db.tExamSubDomain on a.tExamSubDomainID equals c.tExamSubDomainID
                    select new
                    {
                        a.tExamQuestionID,
                        a.Description,
                        a.Time,
                        a.Weight,
                        a.Comment,
                        a.tParamQuestionLevelID,
                        Desc2 = b.Description,
                        a.tExamDomainID,
                        Desc3 = c.Description,
                        a.tExamSubDomainID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser
                    }).Select(u => new mExamQuestion_Display()
                    {

                        _ID = u.tExamQuestionID,
                        _Description = u.Description,
                        _Time = u.Time,
                        _Weight = u.Weight,
                        _Comment = u.Comment,
                        _ID_Level_Question = u.tParamQuestionLevelID,
                        _Domain = u.Desc2,
                        _ID_Domain = u.tExamDomainID,
                        _Sub_Domain = u.Desc3,
                        _ID_Sub_Domain = u.tExamSubDomainID

                    }).ToList();
        }

        [HttpPost("postQuestion/{user}")]
        public async void postQuestion(mExamQuestion_Display pExamQuestionDisplay, int user)
        {
            mExamQuestion vExamQuestion = new mExamQuestion(pExamQuestionDisplay, user);
            tExamQuestion vQuestionTmp = new tExamQuestion();
            vQuestionTmp.Description = vExamQuestion.getDescription();
            vQuestionTmp.Time = vExamQuestion.getTime();
            vQuestionTmp.Weight = vExamQuestion.getWeight();
            vQuestionTmp.Comment = vExamQuestion.getComment();
            vQuestionTmp.tParamQuestionLevelID = vExamQuestion.getParamQuestionLevelID();
            vQuestionTmp.tExamDomainID = vExamQuestion.getExamDomainID();
            vQuestionTmp.tExamSubDomainID = vExamQuestion.getExamSubDomainID();
            vQuestionTmp.CreatDate = vExamQuestion.getCreatDate();
            vQuestionTmp.CreatUser = vExamQuestion.getCreatUser();
            vQuestionTmp.ModifDate = vExamQuestion.getModifDate();
            vQuestionTmp.ModifUser = vExamQuestion.getModifUser();

            db.tExamQuestion.AddAsync(vQuestionTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putQuestion/{user}")]
        public async void putQuestion(mExamQuestion_Display pExamQuestionDisplay, int user)
        {
            var vQuestionTmp = db.tExamQuestion
                        .Where(b => b.tExamQuestionID == pExamQuestionDisplay._ID)
                        .FirstOrDefault();
            mExamQuestion vExamQuestion = new mExamQuestion(pExamQuestionDisplay, user);
            if (vExamQuestion.getDescription() != null) { vQuestionTmp.Description = vExamQuestion.getDescription(); }
            if (vExamQuestion.getTime() > 0) { vQuestionTmp.Time = vExamQuestion.getTime(); }
            if (vExamQuestion.getWeight() > 0) { vQuestionTmp.Weight = vExamQuestion.getWeight();}
            if (vExamQuestion.getComment() != null) { vQuestionTmp.Comment = vExamQuestion.getComment(); }
            if (vExamQuestion.getParamQuestionLevelID() != 0) { vQuestionTmp.tParamQuestionLevelID = vExamQuestion.getParamQuestionLevelID(); }
            if (vExamQuestion.getExamDomainID() != 0) { vQuestionTmp.tExamDomainID = vExamQuestion.getExamDomainID(); }
            if (vExamQuestion.getExamSubDomainID() != 0) { vQuestionTmp.tExamSubDomainID = vExamQuestion.getExamSubDomainID(); }
            if (vExamQuestion.getModifDate() != null) { vQuestionTmp.ModifDate = vExamQuestion.getModifDate(); }
            if (vExamQuestion.getModifUser() != null) { vQuestionTmp.ModifUser = vExamQuestion.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delQuestion/{ID}")]
        public void delQuestion(Int32 ID)
        {
            var vQuestionTmp = db.tExamQuestion.Find(ID);
            db.tExamQuestion.Remove(vQuestionTmp);
            db.SaveChanges();
        }
    }
}
