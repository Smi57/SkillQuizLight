using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamUser_TestController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getUser_TestIDs")]
        public bool getUser_TestIDs(int pExamUserID, int pExamTestID)
        {
            mUserExam User_TestRes = new mUserExam();
            var User_TestTmp = db.tUserExam
                            .Where(b => b.tUserID == pExamUserID &&
                                        b.tUserExamID == pExamTestID)
                            .FirstOrDefault();
            bool vResFind = false;
            if (User_TestTmp != null)
            {
                vResFind = true;
            }
            return vResFind;
        }

        [HttpGet("getUser_Test")]
        public List<mUserExam_Display> getUser_Test()
        {
            return (from a in db.tUserExam
                    join b in db.tUser on a.tUserID equals b.tUserID
                    join c in db.tExamTest on a.tExamTestID equals c.tExamTestID
                    join d in db.tParamTestStatus on a.tParamTestStatusID equals d.tParamTestStatusID
                    select new
                    {
                        a.tUserExamID,
                        a.tUserID,
                        a.tExamTestID,
                        a.Deadline,
                        a.FinishedDate,
                        a.Comment,
                        a.tParamTestStatusID,
                        a.CreatDate,
                        a.CreatUser,
                        a.ModifDate,
                        a.ModifUser,
                        Desc1 = b.FirstName + " " + b.LastName + " (" + b.Login + ")",
                        Desc2 = c.Description,
                        Desc3 = c.Description
                    }).Select(u => new mUserExam_Display()
                    {
                        _ID = u.tUserExamID,
                        _Dead_line = u.Deadline,
                        _Finished_Date = u.FinishedDate,
                        _Comment = u.Comment,
                        _NameFirstNameLogin = u.Desc1,
                        _ID_User = u.tUserID,
                        _Test = u.Desc2,
                        _ID_Test = u.tExamTestID,
                        _Test_Status = u.Desc3,
                        _ID_Test_Status = u.tParamTestStatusID,
                    }).ToList();
        }

        [HttpPost("postUser_Test/{user}")]
        public async void postUser_Test(mUserExam_Display pExamUser_TestDisplay, int user)
        {
            mUserExam vExamUser_Test = new mUserExam(pExamUser_TestDisplay, user);
            tUserExam vUser_TestTmp = new tUserExam();
            vUser_TestTmp.tUserID = vExamUser_Test.gettUserID();
            vUser_TestTmp.tUserExamID = vExamUser_Test.gettUserExamID();
            vUser_TestTmp.Deadline = vExamUser_Test.getDeadline();
            vUser_TestTmp.FinishedDate = vExamUser_Test.getFinishedDate();
            vUser_TestTmp.Comment = vExamUser_Test.getComment();
            vUser_TestTmp.tParamTestStatusID = vExamUser_Test.getParamTestStatusID();
            vUser_TestTmp.CreatDate = vExamUser_Test.getCreatDate();
            vUser_TestTmp.CreatUser = vExamUser_Test.getCreatUser();
            vUser_TestTmp.ModifDate = vExamUser_Test.getModifDate();
            vUser_TestTmp.ModifUser = vExamUser_Test.getModifUser();

            db.tUserExam.AddAsync(vUser_TestTmp);
            await db.SaveChangesAsync();
        }

        [HttpDelete("delUser_Test/{ID}")]
        public void delUser_Test(Int32 ID)
        {
            var vUser_TestTmp = db.tUserExam.Find(ID);
            db.tUserExam.Remove(vUser_TestTmp);
            db.SaveChanges();
        }
    }
}
