using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Models;
using SkillQuizLight.Context;

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamTestController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getTestID/{ID}")]
        public string[] getTestID(int ID)
        {
            mExamTest TestRes = new mExamTest();
            var TestTmp = db.tExamTest
                            .Where(b => b.tExamTestID == ID)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (TestTmp != null)
            {
                vResTab = new string[]{ TestTmp.tExamTestID.ToString(),
                                            TestTmp.Description,
                                            TestTmp.IsWithChrono.ToString(),
                                            TestTmp.NbQuestionRevise.ToString(),
                                            TestTmp.TotalTime.ToString(),
                                            TestTmp.TotalPoint.ToString(),
                                            TestTmp.Comment.ToString(),
                                            TestTmp.ExamDomainID.ToString(),
                                            TestTmp.ExamSubDomainID.ToString(),
                                            TestTmp.CreatDate.ToString(),
                                            TestTmp.CreatUser.ToString(),
                                            TestTmp.ModifDate.ToString(),
                                            TestTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getTest")]
        public List<mExamTest_Display> getTest()
        {
            //return db.tExamTest.Select(u => new mExamTest_Display()
            return (from a in db.tExamTest
                    join b in db.tExamDomain on a.ExamDomainID equals b.tExamDomainID
                    join c in db.tExamSubDomain on a.ExamSubDomainID equals c.tExamSubDomainID
                    select new
                    {
                        a.tExamTestID,
                        a.Description,
                        a.IsWithChrono,
                        a.NbQuestionRevise,
                        a.TotalTime,
                        a.TotalPoint,
                        a.Comment,
                        Desc2 = b.Description,
                        a.ExamDomainID,
                        Desc3 = c.Description,
                        a.ExamSubDomainID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser
                    }).Select(u => new mExamTest_Display()
                    {

                        _ID = u.tExamTestID,
                        _Description = u.Description,
                        _Is_With_Chrono = u.IsWithChrono,
                        _Nb_Question_Revise = u.NbQuestionRevise,
                        _Total_Time = u.TotalTime,
                        _Total_Point = u.TotalPoint,
                        _Comment = u.Comment,
                        _Domain = u.Desc2,
                        _ID_Domain = u.ExamDomainID,
                        _Sub_Domain = u.Desc3,
                        _ID_Sub_Domain = u.ExamSubDomainID

                    }).ToList();
        }

        [HttpPost("postTest/{user}")]
        public async void postTest(mExamTest_Display pExamTestDisplay, int user)
        {
            mExamTest vExamTest = new mExamTest(pExamTestDisplay, user);
            tExamTest vTestTmp = new tExamTest();
            vTestTmp.Description = vExamTest.getDescription();
            vTestTmp.IsWithChrono = vExamTest.getIsWithChrono();
            vTestTmp.NbQuestionRevise = vExamTest.getNbQuestionRevise();
            vTestTmp.TotalTime = vExamTest.getTotalTime();
            vTestTmp.TotalPoint = vExamTest.getTotalPoint();
            vTestTmp.Comment = vExamTest.getComment();
            vTestTmp.ExamDomainID = vExamTest.getExamDomainID();
            vTestTmp.ExamSubDomainID = vExamTest.getExamSubDomainID();
            vTestTmp.CreatDate = vExamTest.getCreatDate();
            vTestTmp.CreatUser = vExamTest.getCreatUser();
            vTestTmp.ModifDate = vExamTest.getModifDate();
            vTestTmp.ModifUser = vExamTest.getModifUser();

            db.tExamTest.AddAsync(vTestTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putTest/{user}")]
        public async void putTest(mExamTest_Display pExamTestDisplay, int user)
        {
            var vTestTmp = db.tExamTest
                        .Where(b => b.tExamTestID == pExamTestDisplay._ID)
                        .FirstOrDefault();
            mExamTest vExamTest = new mExamTest(pExamTestDisplay, user);
            if (vExamTest.getDescription() != null) { vTestTmp.Description = vExamTest.getDescription(); }
            if (vExamTest.getIsWithChrono() != null) { vTestTmp.IsWithChrono = vExamTest.getIsWithChrono(); }
            if (vExamTest.getNbQuestionRevise() > 0) { vTestTmp.NbQuestionRevise = vExamTest.getNbQuestionRevise(); }
            if (vExamTest.getTotalTime() > 0) { vTestTmp.TotalTime = vExamTest.getTotalTime(); }
            if (vExamTest.getTotalPoint() > 0) { vTestTmp.TotalPoint = vExamTest.getTotalPoint(); }
            if (vExamTest.getComment() != null) { vTestTmp.Comment = vExamTest.getComment(); }
            if (vExamTest.getExamDomainID() != 0) { vTestTmp.ExamDomainID = vExamTest.getExamDomainID(); }
            if (vExamTest.getExamSubDomainID() != 0) { vTestTmp.ExamSubDomainID = vExamTest.getExamSubDomainID(); }
            if (vExamTest.getModifDate() != null) { vTestTmp.ModifDate = vExamTest.getModifDate(); }
            if (vExamTest.getModifUser() != null) { vTestTmp.ModifUser = vExamTest.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delTest/{ID}")]
        public void delTest(Int32 ID)
        {
            var vTestTmp = db.tExamTest.Find(ID);
            db.tExamTest.Remove(vTestTmp);
            db.SaveChanges();
        }
    }
}
