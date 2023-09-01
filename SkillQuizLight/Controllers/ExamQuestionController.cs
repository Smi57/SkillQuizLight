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

        [HttpGet("getQuestionDescription/{description}")]
        public string[] getQuestionDescription(string description)
        {
            mExamQuestion QuestionRes = new mExamQuestion();
            var QuestionTmp = db.tExamQuestion
                            .Where(b => b.Description == description)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (QuestionTmp != null)
            {
                vResTab = new string[]{ QuestionTmp.tExamQuestionID.ToString(),
                                            QuestionTmp.Description,
                                            QuestionTmp.CreatDate.ToString(),
                                            QuestionTmp.CreatUser.ToString(),
                                            QuestionTmp.ModifDate.ToString(),
                                            QuestionTmp.ModifUser.ToString() }



                //QuestionRes.settExamQuestionID(QuestionTmp.tExamQuestionID);
                //QuestionRes.setDescription(QuestionTmp.Description);
                //QuestionRes.setCreatDate(QuestionTmp.CreatDate);
                //QuestionRes.setCreatUser(QuestionTmp.CreatUser);
                //QuestionRes.setModifDate(QuestionTmp.ModifDate);
                //QuestionRes.setModifUser(QuestionTmp.ModifUser);

                ;
            }
            //return QuestionRes;

            return vResTab;
        }

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
                                            QuestionTmp.CreatDate.ToString(),
                                            QuestionTmp.CreatUser.ToString(),
                                            QuestionTmp.ModifDate.ToString(),
                                            QuestionTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getQuestion")]
        public List<mExamQuestion_Display> getQuestion()
        {
            return db.tExamQuestion.Select(u => new mExamQuestion_Display()
            {
                _ID = u.tExamQuestionID,
                _Description = u.Description

            }).ToList();
        }

        [HttpPost("postQuestion/{user}")]
        public async void postQuestion(mExamQuestion_Display pExamQuestionDisplay, int user)
        {
            mExamQuestion vExamQuestion = new mExamQuestion(pExamQuestionDisplay, user);
            tExamQuestion vQuestionTmp = new tExamQuestion();
            vQuestionTmp.Description = vExamQuestion.getDescription();
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
