using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamTest_QuestionnaireController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getTest_QuestionnaireIDs")]
        public bool getTest_QuestionnaireIDs(int pExamTestID, int pExamQuestionnaireID)
        {
            mExamTest_Questionnaire Test_QuestionnaireRes = new mExamTest_Questionnaire();
            var Test_QuestionnaireTmp = db.tExamTest_Questionnaire
                            .Where(b => b.tExamTestID == pExamTestID &&
                                        b.tExamQuestionnaireID == pExamQuestionnaireID)
                            .FirstOrDefault();
            bool vResFind = false;
            if (Test_QuestionnaireTmp != null)
            {
                vResFind = true;
            }
            return vResFind;
        }

        [HttpGet("getTest_Questionnaire")]
        public List<mExamTest_Questionnaire_Display> getTest_Questionnaire()
        {


            return (from a in db.tExamTest_Questionnaire
                    join b in db.tExamTest on a.tExamTestID equals b.tExamTestID
                    join c in db.tExamQuestionnaire on a.tExamQuestionnaireID equals c.tExamQuestionnaireID
                    select new
                    {
                        a.tExamTest_QuestionnaireID,
                        a.tExamTestID,
                        a.tExamQuestionnaireID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser,
                        b.Description,
                        Desc2 = c.Description
                    }).Select(u => new mExamTest_Questionnaire_Display()
                    {
                        _ID = u.tExamTest_QuestionnaireID,
                        _Test = u.Description,
                        _ID_Test = u.tExamTestID,
                        _Questionnaire = u.Desc2,
                        _ID_Questionnaire = u.tExamQuestionnaireID
                    }).ToList();
        }

        [HttpPost("postTest_Questionnaire/{user}")]
        public async void postTest_Questionnaire(mExamTest_Questionnaire_Display pExamTest_QuestionnaireDisplay, int user)
        {
            mExamTest_Questionnaire vExamTest_Questionnaire = new mExamTest_Questionnaire(pExamTest_QuestionnaireDisplay, user);
            tExamTest_Questionnaire vTest_QuestionnaireTmp = new tExamTest_Questionnaire();
            vTest_QuestionnaireTmp.tExamTestID = vExamTest_Questionnaire.gettExamTestID();
            vTest_QuestionnaireTmp.tExamQuestionnaireID = vExamTest_Questionnaire.gettExamQuestionnaireID();
            vTest_QuestionnaireTmp.CreatDate = vExamTest_Questionnaire.getCreatDate();
            vTest_QuestionnaireTmp.CreatUser = vExamTest_Questionnaire.getCreatUser();
            vTest_QuestionnaireTmp.ModifDate = vExamTest_Questionnaire.getModifDate();
            vTest_QuestionnaireTmp.ModifUser = vExamTest_Questionnaire.getModifUser();

            db.tExamTest_Questionnaire.AddAsync(vTest_QuestionnaireTmp);
            await db.SaveChangesAsync();
        }

        [HttpDelete("delTest_Questionnaire/{ID}")]
        public void delTest_Questionnaire(Int32 ID)
        {
            var vTest_QuestionnaireTmp = db.tExamTest_Questionnaire.Find(ID);
            db.tExamTest_Questionnaire.Remove(vTest_QuestionnaireTmp);
            db.SaveChanges();
        }
    }
}
