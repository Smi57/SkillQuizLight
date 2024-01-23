using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserQuestionController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getUserQuestion_IDs")]
        public List<mUserQuestion_Display> getUserQuestion_IDs(int ptQuestionnaireID, int ptExamTest_QuestionnaireID)
        {
            return (from a in db.tUserQuestion
                    where a.tExamQuestionID == ptQuestionnaireID
                    && a.tExamTest_QuestionnaireID == ptExamTest_QuestionnaireID
                    select new
                    {
                        a.tUserQuestionID,
                        a.TimeOpen,
                        a.tUserExamID,
                        a.tExamQuestionnaire_QuestionID,
                        a.tExamTest_QuestionnaireID,
                        a.tExamQuestionID
                    }
                    ).Select(u => new mUserQuestion_Display()
                    {
                        _ID = u.tUserQuestionID,
                        _TimeOpen = u.TimeOpen,
                        _tUserExamID = u.tUserExamID,
                        _tExamQuestionnaire_QuestionID = u.tExamQuestionnaire_QuestionID,
                        _tExamTest_QuestionnaireID = u.tExamTest_QuestionnaireID,
                        _tExamQuestionID = u.tExamQuestionID

                    }).ToList();
            //mUserQuestion_Display User_TestRes = new mUserQuestion_Display();
            //var User_TestTmp = db.tUserExam
            //                .Where(b => b.tUserID == pUserExamID)
            //                .FirstOrDefault();
            //bool vResFind = false;
            //if (User_TestTmp != null)
            //{
            //    vResFind = true;
            //}
            //return vResFind;
        }


        [HttpGet("getUserQuestion/{ptExamTest_QuestionnaireID}")]
        public List<mUserQuestion_Display> getUserQuestion(int ptExamTest_QuestionnaireID)
        {
            return (from a in db.tUserQuestion
                    where a.tExamTest_QuestionnaireID == ptExamTest_QuestionnaireID
                    select new
                    {
                        a.tUserQuestionID,
                        a.TimeOpen,
                        a.tUserExamID,
                        a.tExamQuestionnaire_QuestionID,
                        a.tExamTest_QuestionnaireID,
                        a.tExamQuestionID
                    }).Select(u => new mUserQuestion_Display()
                    {
                        _ID = u.tUserQuestionID,
                        _TimeOpen = u.TimeOpen,
                        _tUserExamID = u.tUserExamID,
                        _tExamQuestionnaire_QuestionID = u.tExamQuestionnaire_QuestionID,
                        _tExamTest_QuestionnaireID = u.tExamTest_QuestionnaireID,
                        _tExamQuestionID = u.tExamQuestionID
                    }).ToList();
        }

        [HttpPost("postUserQuestion/{pUser}")]
        public async void postUser_Test(mUserQuestion_Display pUserQuestion_Display, int pUser)
        {
            mUserQuestion vUserQuestion = new mUserQuestion(pUserQuestion_Display, pUser);
            tUserQuestion vUserQuestion_Tmp = new tUserQuestion();
            vUserQuestion_Tmp.TimeOpen = vUserQuestion.getTimeOpen();
            vUserQuestion_Tmp.tUserExamID = vUserQuestion.gettUserExamID();
            vUserQuestion_Tmp.tExamTest_QuestionnaireID = vUserQuestion.gettExamTest_QuestionnaireID();
            vUserQuestion_Tmp.tExamQuestionnaire_QuestionID = vUserQuestion.gettExamQuestionnaire_QuestionID();
            vUserQuestion_Tmp.tExamQuestionID = vUserQuestion.gettExamQuestionID();
            vUserQuestion_Tmp.CreatDate = vUserQuestion.getCreatDate();
            vUserQuestion_Tmp.CreatUser = vUserQuestion.getCreatUser();
            vUserQuestion_Tmp.ModifDate = vUserQuestion.getModifDate();
            vUserQuestion_Tmp.ModifUser = vUserQuestion.getModifUser();

            db.tUserQuestion.AddAsync(vUserQuestion_Tmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putUserQuestion/{pUser}")]
        public async void putUserQuestion(mUserQuestion_Display pUserQuestion_Display, int pUser)
        {
            var vUserQuestionTmp = db.tUserQuestion
                        .Where(b => b.tUserQuestionID == pUserQuestion_Display._ID)
                        .FirstOrDefault();
            mUserQuestion vUserQuestion = new mUserQuestion(pUserQuestion_Display, pUser);
            var vTimeTmp = vUserQuestion.getTimeOpen();
            if (vTimeTmp != null) { vUserQuestionTmp.TimeOpen = Convert.ToInt32(vTimeTmp); }
            if (vUserQuestion.getModifDate() != null) { vUserQuestionTmp.ModifDate = vUserQuestion.getModifDate(); }
            if (vUserQuestion.getModifUser() != null) { vUserQuestionTmp.ModifUser = vUserQuestion.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delUserQuestion/{ID}")]
        public void delUserQuestion(Int32 ID)
        {
            var vUserQuestion = db.tUserQuestion.Find(ID);
            db.tUserQuestion.Remove(vUserQuestion);
            db.SaveChanges();
        }
    }
}
