using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamAnswerController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getAnswerID/{ID}")]
        public string[] getAnswerID(int ID)
        {
            mExamAnswer answerRes = new mExamAnswer();
            var answerTmp = db.tExamAnswer
                            .Where(b => b.tExamAnswerID == ID)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (answerTmp != null)
            {
                vResTab = new string[]{ answerTmp.tExamAnswerID.ToString(),
                                        answerTmp.Description,
                                        answerTmp.CreatDate.ToString(),
                                        answerTmp.CreatUser.ToString(),
                                        answerTmp.ModifDate.ToString(),
                                        answerTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getAnswer")]
        public List<mExamAnswer_Display> getAnswer()
        {
            return db.tExamAnswer.Select(u => new mExamAnswer_Display()
            {
                _ID = u.tExamAnswerID,
                _Description = u.Description

            }).ToList();
        }

        [HttpPost("postAnswer/{user}")]
        public async void postAnswer(mExamAnswer_Display pExamAnswerDisplay, int user)
        {
            mExamAnswer vExamAnswer = new mExamAnswer(pExamAnswerDisplay, user);
            tExamAnswer vAnswerTmp = new tExamAnswer();
            vAnswerTmp.Description = vExamAnswer.getDescription();
            vAnswerTmp.CreatDate = vExamAnswer.getCreatDate();
            vAnswerTmp.CreatUser = vExamAnswer.getCreatUser();
            vAnswerTmp.ModifDate = vExamAnswer.getModifDate();
            vAnswerTmp.ModifUser = vExamAnswer.getModifUser();

            db.tExamAnswer.AddAsync(vAnswerTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putAnswer/{user}")]
        public async void putAnswer(mExamAnswer_Display pExamAnswerDisplay, int user)
        {
            var vAnswerTmp = db.tExamAnswer
                        .Where(b => b.tExamAnswerID == pExamAnswerDisplay._ID)
                        .FirstOrDefault();
            mExamAnswer vExamAnswer = new mExamAnswer(pExamAnswerDisplay, user);
            if (vExamAnswer.getDescription() != null) { vAnswerTmp.Description = vExamAnswer.getDescription(); }
            if (vExamAnswer.getModifDate() != null) { vAnswerTmp.ModifDate = vExamAnswer.getModifDate(); }
            if (vExamAnswer.getModifUser() != null) { vAnswerTmp.ModifUser = vExamAnswer.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delAnswer/{ID}")]
        public void delAnswer(Int32 ID)
        {
            var vAnswerTmp = db.tExamAnswer.Find(ID);
            db.tExamAnswer.Remove(vAnswerTmp);
            db.SaveChanges();
        }
    }
}
