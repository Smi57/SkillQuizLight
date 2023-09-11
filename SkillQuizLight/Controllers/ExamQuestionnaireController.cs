using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamQuestionnaireController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getQuestionnaireID/{ID}")]
        public string[] getQuestionnaireID(int ID)
        {
            mExamQuestionnaire QuestionnaireRes = new mExamQuestionnaire();
            var QuestionnaireTmp = db.tExamQuestionnaire
                            .Where(b => b.tExamQuestionnaireID == ID)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (QuestionnaireTmp != null)
            {
                vResTab = new string[]{ QuestionnaireTmp.tExamQuestionnaireID.ToString(),
                                            QuestionnaireTmp.Description,
                                            QuestionnaireTmp.TotalTime.ToString(),
                                            QuestionnaireTmp.TotalPoint.ToString(),
                                            QuestionnaireTmp.Weight.ToString(),
                                            QuestionnaireTmp.Comment.ToString(),
                                            QuestionnaireTmp.ExamDomainID.ToString(),
                                            QuestionnaireTmp.ExamSubDomainID.ToString(),
                                            QuestionnaireTmp.CreatDate.ToString(),
                                            QuestionnaireTmp.CreatUser.ToString(),
                                            QuestionnaireTmp.ModifDate.ToString(),
                                            QuestionnaireTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getQuestionnaire")]
        public List<mExamQuestionnaire_Display> getQuestionnaire()
        {
            //return db.tExamQuestionnaire.Select(u => new mExamQuestionnaire_Display()

            return (from a in db.tExamQuestionnaire
                    join b in db.tExamDomain on a.ExamDomainID equals b.tExamDomainID
                    join c in db.tExamSubDomain on a.ExamSubDomainID equals c.tExamSubDomainID
                    select new
                    {
                        a.tExamQuestionnaireID,
                        a.Description,
                        a.TotalTime,
                        a.TotalPoint,
                        a.Weight,
                        a.Comment,
                        Desc2 = b.Description,
                        a.ExamDomainID,
                        Desc3 = c.Description,
                        a.ExamSubDomainID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser
                    }).Select(u => new mExamQuestionnaire_Display()

                    {
                        _ID = u.tExamQuestionnaireID,
                        _Description = u.Description,
                        _TotalTime = u.TotalTime,
                        _TotalPoint = u.TotalPoint,
                        _Weight = u.Weight,
                        _Comment = u.Comment,
                        _Domain = u.Desc2,
                        _ID_Domain = u.ExamDomainID,
                        _Sub_Domain = u.Desc3,
                        _ID_Sub_Domain = u.ExamSubDomainID

                    }).ToList();
        }

        [HttpPost("postQuestionnaire/{user}")]
        public async void postQuestionnaire(mExamQuestionnaire_Display pExamQuestionnaireDisplay, int user)
        {
            mExamQuestionnaire vExamQuestionnaire = new mExamQuestionnaire(pExamQuestionnaireDisplay, user);
            tExamQuestionnaire vQuestionnaireTmp = new tExamQuestionnaire();
            vQuestionnaireTmp.Description = vExamQuestionnaire.getDescription();
            vQuestionnaireTmp.TotalTime = vExamQuestionnaire.getTotalTime();
            vQuestionnaireTmp.TotalPoint = vExamQuestionnaire.getTotalPoint();
            vQuestionnaireTmp.Weight = vExamQuestionnaire.getWeight();
            vQuestionnaireTmp.Comment = vExamQuestionnaire.getComment();
            vQuestionnaireTmp.ExamDomainID = vExamQuestionnaire.getExamDomainID();
            vQuestionnaireTmp.ExamSubDomainID = vExamQuestionnaire.getExamSubDomainID();
            vQuestionnaireTmp.CreatDate = vExamQuestionnaire.getCreatDate();
            vQuestionnaireTmp.CreatUser = vExamQuestionnaire.getCreatUser();
            vQuestionnaireTmp.ModifDate = vExamQuestionnaire.getModifDate();
            vQuestionnaireTmp.ModifUser = vExamQuestionnaire.getModifUser();

            db.tExamQuestionnaire.AddAsync(vQuestionnaireTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putQuestionnaire/{user}")]
        public async void putQuestionnaire(mExamQuestionnaire_Display pExamQuestionnaireDisplay, int user)
        {
            var vQuestionnaireTmp = db.tExamQuestionnaire
                        .Where(b => b.tExamQuestionnaireID == pExamQuestionnaireDisplay._ID)
                        .FirstOrDefault();
            mExamQuestionnaire vExamQuestionnaire = new mExamQuestionnaire(pExamQuestionnaireDisplay, user);
            if (vExamQuestionnaire.getDescription() != null) { vQuestionnaireTmp.Description = vExamQuestionnaire.getDescription(); }
            if (vExamQuestionnaire.getTotalTime() > 0) { vQuestionnaireTmp.TotalTime = vExamQuestionnaire.getTotalTime(); }
            if (vExamQuestionnaire.getTotalPoint() != 0) { vQuestionnaireTmp.TotalPoint = vExamQuestionnaire.getTotalPoint(); }
            if (vExamQuestionnaire.getWeight() > 0) { vQuestionnaireTmp.Weight = vExamQuestionnaire.getWeight(); }
            if (vExamQuestionnaire.getComment() != null) { vQuestionnaireTmp.Comment = vExamQuestionnaire.getComment(); }
            if (vExamQuestionnaire.getExamDomainID() != 0) { vQuestionnaireTmp.ExamDomainID = vExamQuestionnaire.getExamDomainID(); }
            if (vExamQuestionnaire.getExamSubDomainID() != 0) { vQuestionnaireTmp.ExamSubDomainID = vExamQuestionnaire.getExamSubDomainID(); }
            if (vExamQuestionnaire.getModifDate() != null) { vQuestionnaireTmp.ModifDate = vExamQuestionnaire.getModifDate(); }
            if (vExamQuestionnaire.getModifUser() != null) { vQuestionnaireTmp.ModifUser = vExamQuestionnaire.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delQuestionnaire/{ID}")]
        public void delQuestionnaire(Int32 ID)
        {
            var vQuestionnaireTmp = db.tExamQuestionnaire.Find(ID);
            db.tExamQuestionnaire.Remove(vQuestionnaireTmp);
            db.SaveChanges();
        }
    }
}
