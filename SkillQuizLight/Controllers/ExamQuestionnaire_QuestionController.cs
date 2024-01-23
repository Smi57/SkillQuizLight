using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamQuestionnaire_QuestionController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getQuestionnaire_QuestionIDs")]
        public bool getQuestionnaire_QuestionIDs(int pExamQuestionnaireID, int pExamQuestionID)
        {
            mExamQuestionnaire_Question Questionnaire_QuestionRes = new mExamQuestionnaire_Question();
            var Questionnaire_QuestionTmp = db.tExamQuestionnaire_Question
                            .Where(b => b.tExamQuestionnaireID == pExamQuestionnaireID &&
                                        b.tExamQuestionID == pExamQuestionID)
                            .FirstOrDefault();
            bool vResFind = false;
            if (Questionnaire_QuestionTmp != null)
            {
                vResFind = true;
            }
            return vResFind;
        }

        [HttpGet("getQuestionnaire_Question")]
        public List<mExamQuestionnaire_Question_Display> getQuestionnaire_Question()
        {

            return (from a in db.tExamQuestionnaire_Question
                    join b in db.tExamQuestionnaire on a.tExamQuestionnaireID equals b.tExamQuestionnaireID
                    join c in db.tExamQuestion on a.tExamQuestionID equals c.tExamQuestionID
                    select new
                    {
                        a.tExamQuestionnaire_QuestionID,
                        a.tExamQuestionnaireID,
                        a.tExamQuestionID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser,
                        b.Description,
                        Desc2 = c.Description,
                        c.Time
                    }).Select(u => new mExamQuestionnaire_Question_Display()
                    {
                        _ID = u.tExamQuestionnaire_QuestionID,
                        _Questionnaire = u.Description,
                        _ID_Questionnaire = u.tExamQuestionnaireID,
                        _Question = u.Desc2,
                        _ID_Question = u.tExamQuestionID,
                        _QuestionTime = u.Time
                    }).ToList();
        }


        [HttpGet("getQuestionnaire_Question_QuestionnaireID/{QuestionnaireID}")]
        public List<mExamQuestionnaire_Question_Display> getQuestionnaire_Question_QuestionnaireID(int QuestionnaireID)
        {

            return (from a in db.tExamQuestionnaire_Question
                    join b in db.tExamQuestionnaire on a.tExamQuestionnaireID equals b.tExamQuestionnaireID
                    join c in db.tExamQuestion on a.tExamQuestionID equals c.tExamQuestionID
                    where a.tExamQuestionnaireID == QuestionnaireID
                    select new
                    {
                        a.tExamQuestionnaire_QuestionID,
                        a.tExamQuestionnaireID,
                        a.tExamQuestionID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser,
                        b.Description,
                        Desc2 = c.Description,
                        c.Time
                    }).Select(u => new mExamQuestionnaire_Question_Display()
                    {
                        _ID = u.tExamQuestionnaire_QuestionID,
                        _Questionnaire = u.Description,
                        _ID_Questionnaire = u.tExamQuestionnaireID,
                        _Question = u.Desc2,
                        _ID_Question = u.tExamQuestionID,
                        _QuestionTime = u.Time
                    }).ToList();
        }

        [HttpPost("postQuestionnaire_Question/{user}")]
        public async void postQuestionnaire_Question(mExamQuestionnaire_Question_Display pExamQuestionnaire_QuestionDisplay, int user)
        {
            mExamQuestionnaire_Question vExamQuestionnaire_Question = new mExamQuestionnaire_Question(pExamQuestionnaire_QuestionDisplay, user);
            tExamQuestionnaire_Question vQuestionnaire_QuestionTmp = new tExamQuestionnaire_Question();
            vQuestionnaire_QuestionTmp.tExamQuestionnaireID = vExamQuestionnaire_Question.gettExamQuestionnaireID();
            vQuestionnaire_QuestionTmp.tExamQuestionID = vExamQuestionnaire_Question.gettExamQuestionID();
            vQuestionnaire_QuestionTmp.CreatDate = vExamQuestionnaire_Question.getCreatDate();
            vQuestionnaire_QuestionTmp.CreatUser = vExamQuestionnaire_Question.getCreatUser();
            vQuestionnaire_QuestionTmp.ModifDate = vExamQuestionnaire_Question.getModifDate();
            vQuestionnaire_QuestionTmp.ModifUser = vExamQuestionnaire_Question.getModifUser();

            db.tExamQuestionnaire_Question.AddAsync(vQuestionnaire_QuestionTmp);
            await db.SaveChangesAsync();
        }

        [HttpDelete("delQuestionnaire_Question/{ID}")]
        public void delQuestionnaire_Question(Int32 ID)
        {
            var vQuestionnaire_QuestionTmp = db.tExamQuestionnaire_Question.Find(ID);
            db.tExamQuestionnaire_Question.Remove(vQuestionnaire_QuestionTmp);
            db.SaveChanges();
        }
    }
}
