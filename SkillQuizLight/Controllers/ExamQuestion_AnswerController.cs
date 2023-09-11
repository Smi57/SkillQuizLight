using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamQuestion_AnswerController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getQuestion_AnswerIDs")]
        public bool getQuestion_AnswerIDs(int pExamQuestionID, int pExamAnswerID)
        {
            mExamQuestion_Answer Question_AnswerRes = new mExamQuestion_Answer();
            var Question_AnswerTmp = db.tExamQuestion_Answer
                            .Where(b => b.tExamQuestionID == pExamQuestionID &&
                                        b.tExamAnswerID == pExamAnswerID)
                            .FirstOrDefault();
            bool vResFind = false;
            if (Question_AnswerTmp != null)
            {
                vResFind = true;
            }
            return vResFind;
        }

        [HttpGet("getQuestion_Answer")]
        public List<mExamQuestion_Answer_Display> getQuestion_Answer()
        {


            return (from a in db.tExamQuestion_Answer
                    join b in db.tExamQuestion on a.tExamQuestionID equals b.tExamQuestionID
                    join c in db.tExamAnswer on a.tExamAnswerID equals c.tExamAnswerID
                    select new
                    {
                        a.tExamQuestion_AnswerID,
                        a.tExamQuestionID,
                        a.tExamAnswerID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser,
                        b.Description,
                        Desc2 = c.Description
                    }).Select(u => new mExamQuestion_Answer_Display()
                    {
                        _ID = u.tExamQuestion_AnswerID,
                        _Question = u.Description,
                        _ID_Question = u.tExamQuestionID,
                        _ID_Answer = u.tExamAnswerID,
                        _Answer = u.Desc2
                    }).ToList();
        }

        [HttpGet("getQuestion_Answer_QuestionID/{QuestionID}")]
        public List<mExamQuestion_Answer_Display> getQuestion_Answer_QuestionID(int QuestionID)
        {
            return (from a in db.tExamQuestion_Answer
                    join b in db.tExamQuestion on a.tExamQuestionID equals b.tExamQuestionID
                    join c in db.tExamAnswer on a.tExamAnswerID equals c.tExamAnswerID
                    where a.tExamQuestionID == QuestionID
                    select new
                    {
                        a.tExamQuestion_AnswerID,
                        a.tExamQuestionID,
                        a.tExamAnswerID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser,
                        b.Description,
                        Desc2 = c.Description
                    }).Select(u => new mExamQuestion_Answer_Display()
                    {
                        _ID = u.tExamQuestion_AnswerID,
                        _Question = u.Description,
                        _ID_Question = u.tExamQuestionID,
                        _ID_Answer = u.tExamAnswerID,
                        _Answer = u.Desc2
                    }).ToList();
        }

        [HttpPost("postQuestion_Answer/{user}")]
        public async void postQuestion_Answer(mExamQuestion_Answer_Display pExamQuestion_AnswerDisplay, int user)
        {
            mExamQuestion_Answer vExamQuestion_Answer = new mExamQuestion_Answer(pExamQuestion_AnswerDisplay, user);
            tExamQuestion_Answer vQuestion_AnswerTmp = new tExamQuestion_Answer();
            vQuestion_AnswerTmp.tExamQuestionID = vExamQuestion_Answer.gettExamQuestionID();
            vQuestion_AnswerTmp.tExamAnswerID = vExamQuestion_Answer.gettExamAnswerID();
            vQuestion_AnswerTmp.CreatDate = vExamQuestion_Answer.getCreatDate();
            vQuestion_AnswerTmp.CreatUser = vExamQuestion_Answer.getCreatUser();
            vQuestion_AnswerTmp.ModifDate = vExamQuestion_Answer.getModifDate();
            vQuestion_AnswerTmp.ModifUser = vExamQuestion_Answer.getModifUser();

            db.tExamQuestion_Answer.AddAsync(vQuestion_AnswerTmp);
            await db.SaveChangesAsync();
        }

        [HttpDelete("delQuestion_Answer/{ID}")]
        public void delQuestion_Answer(Int32 ID)
        {
            var vQuestion_AnswerTmp = db.tExamQuestion_Answer.Find(ID);
            db.tExamQuestion_Answer.Remove(vQuestion_AnswerTmp);
            db.SaveChanges();
        }
    }
}
