using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAnswerController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getAnswerID/{ID}")]
        public string[] getAnswerID(int ID)
        {
            mUserAnswer answerRes = new mUserAnswer();
            var answerTmp = db.tUserAnswer
                            .Where(b => b.tUserAnswerID == ID)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (answerTmp != null)
            {
                vResTab = new string[]{ answerTmp.tUserAnswerID.ToString(),
                                        answerTmp.Description,
                                        answerTmp.Comment,
                                        answerTmp.IsSelectByUser.ToString(),
                                        answerTmp.tUserExamID.ToString(),
                                        answerTmp.tExamTest_QuestionnaireID.ToString(),
                                        answerTmp.tExamQuestionnaire_QuestionID.ToString(),
                                        answerTmp.tUserAnswerID.ToString(),
                                        answerTmp.tParamAnswerLevelID.ToString(),
                                        answerTmp.CreatDate.ToString(),
                                        answerTmp.CreatUser.ToString(),
                                        answerTmp.ModifDate.ToString(),
                                        answerTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getAnswer")]
        public List<mUserAnswer_Display> getAnswer()
        {
            return db.tUserAnswer.Select(u => new mUserAnswer_Display()
            {
                _ID = u.tUserAnswerID,
                _Description = u.Description,
                _Comment = u.Comment,
                _IsSelectByUser = u.IsSelectByUser,
                _tUserExamID = u.tUserExamID,
                _tExamTest_QuestionnaireID = u.tExamTest_QuestionnaireID,
                _tExamQuestionnaire_QuestionID = u.tExamQuestionnaire_QuestionID,
                _tExamAnswerID = u.tExamAnswerID,
                _tParamAnswerLevelID = u.tParamAnswerLevelID

            }).ToList();
        }

        [HttpPost("postAnswer/{user}")]
        public async void postAnswer(mUserAnswer_Display pUserAnswerDisplay, int user)
        //public int postAnswer(mUserAnswer_Display pUserAnswerDisplay, int user)
        {
            mUserAnswer vUserAnswer = new mUserAnswer(pUserAnswerDisplay, user);
            tUserAnswer vAnswerTmp = new tUserAnswer();
            vAnswerTmp.Description = vUserAnswer.getDescription();
            vAnswerTmp.Comment = vUserAnswer.getComment();
            vAnswerTmp.IsSelectByUser = vUserAnswer.getIsSelectByUser();
            vAnswerTmp.tUserExamID = vUserAnswer.gettUserExamID();
            vAnswerTmp.tExamTest_QuestionnaireID = vUserAnswer.gettExamTest_QuestionnaireID();
            vAnswerTmp.tExamQuestionnaire_QuestionID = vUserAnswer.gettExamQuestionnaire_QuestionID();
            vAnswerTmp.tParamAnswerLevelID = vUserAnswer.gettParamAnswerLevelID();
            vAnswerTmp.tExamAnswerID = vUserAnswer.gettExamAnswerID();
            vAnswerTmp.CreatDate = vUserAnswer.getCreatDate();
            vAnswerTmp.CreatUser = vUserAnswer.getCreatUser();
            vAnswerTmp.ModifDate = vUserAnswer.getModifDate();
            vAnswerTmp.ModifUser = vUserAnswer.getModifUser();
            
            //var vAnswerRes = db.tUserAnswer.Add(vAnswerTmp);
            //db.SaveChanges();
            //vAnswerRes.ReloadAsync();
            //return vAnswerRes.Entity.tUserAnswerID;

            db.tUserAnswer.AddAsync(vAnswerTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putAnswer/{user}")]
        public async void putAnswer(mUserAnswer_Display pUserAnswerDisplay, int user)
        {
            var vAnswerTmp = db.tUserAnswer
                        .Where(b => b.tUserAnswerID == pUserAnswerDisplay._ID)
                        .FirstOrDefault();
            mUserAnswer vUserAnswer = new mUserAnswer(pUserAnswerDisplay, user);
            if (vUserAnswer.getDescription() != null) { vAnswerTmp.Description = vUserAnswer.getDescription(); }
            if (vUserAnswer.getComment() != null) { vAnswerTmp.Comment = vUserAnswer.getComment(); }
            if (vUserAnswer.getIsSelectByUser() != null) { vUserAnswer.getIsSelectByUser(); }
            if (vUserAnswer.gettExamAnswerID() != null) { vAnswerTmp.tUserAnswerID = vUserAnswer.gettExamAnswerID(); }
            if (vUserAnswer.gettExamTest_QuestionnaireID() != null) {  vAnswerTmp.tExamTest_QuestionnaireID = vUserAnswer.gettExamTest_QuestionnaireID(); }
            if (vUserAnswer.gettExamQuestionnaire_QuestionID() != null) { vAnswerTmp.tExamQuestionnaire_QuestionID = vUserAnswer.gettExamQuestionnaire_QuestionID(); }
            if (vUserAnswer.gettUserExamID() != null) { vAnswerTmp.tUserExamID = vUserAnswer.gettUserExamID(); }
            if (vUserAnswer.gettParamAnswerLevelID() != null) { vAnswerTmp.tParamAnswerLevelID = vUserAnswer.gettParamAnswerLevelID(); }
            if (vUserAnswer.getModifDate() != null) { vAnswerTmp.ModifDate = vUserAnswer.getModifDate(); }
            if (vUserAnswer.getModifUser() != null) { vAnswerTmp.ModifUser = vUserAnswer.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delAnswer/{ID}")]
        public void delAnswer(Int32 ID)
        {
            var vAnswerTmp = db.tUserAnswer.Find(ID);
            db.tUserAnswer.Remove(vAnswerTmp);
            db.SaveChanges();
        }
    }
}
