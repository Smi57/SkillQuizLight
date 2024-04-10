using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserExamController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getUser_TestIDs")]
        public bool getUser_TestIDs(int pExamUserID, int pExamTestID)
        {
            mUserExam User_TestRes = new mUserExam();
            var User_TestTmp = db.tUserExam
                            .Where(b => b.tUserID == pExamUserID &&
                                        b.tExamTestID == pExamTestID)
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

        [HttpGet("getUser_Test_UserID/{UserID}")]
        public List<mUserExam_Display> getUser_Test_UserID(int UserID)
        {
            return (from a in db.tUserExam
                    join b in db.tUser on a.tUserID equals b.tUserID
                    join c in db.tExamTest on a.tExamTestID equals c.tExamTestID
                    join d in db.tParamTestStatus on a.tParamTestStatusID equals d.tParamTestStatusID
                    where b.tUserID == UserID
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
                        Desc3 = d.Description
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

        [HttpGet("getUser_Test_TestID/{TestID}")]
        public List<mUserExam_Display> getUser_Test_TestID(int TestID)
        {
            return (from a in db.tUserExam
                    join b in db.tUser on a.tUserID equals b.tUserID
                    join c in db.tExamTest on a.tExamTestID equals c.tExamTestID
                    join d in db.tParamTestStatus on a.tParamTestStatusID equals d.tParamTestStatusID
                    where a.tExamTestID == TestID
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
                        Desc3 = d.Description
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

        [HttpPost("postUser/{user}")]
        public async void postUser(mUserExam_Display pExamUserDisplay, int user)
        {
            mUserExam vExamUser = new mUserExam(pExamUserDisplay, user);
            tUserExam vUserTmp = new tUserExam();
            vUserTmp.tUserID = vExamUser.gettUserID();
            vUserTmp.tExamTestID = vExamUser.gettExamTestID();
            vUserTmp.Deadline = vExamUser.getDeadline();
            vUserTmp.FinishedDate = vExamUser.getFinishedDate();
            vUserTmp.Comment = vExamUser.getComment();
            vUserTmp.tParamTestStatusID = vExamUser.getParamTestStatusID();
            vUserTmp.CreatDate = vExamUser.getCreatDate();
            vUserTmp.CreatUser = vExamUser.getCreatUser();
            vUserTmp.ModifDate = vExamUser.getModifDate();
            vUserTmp.ModifUser = vExamUser.getModifUser();

            db.tUserExam.AddAsync(vUserTmp);
            await db.SaveChangesAsync();
        }

        [HttpDelete("delUser/{ID}")]
        public void delUser(Int32 ID)
        {
            var vUserTmp = db.tUserExam.Find(ID);
            db.tUserExam.Remove(vUserTmp);
            db.SaveChanges();
        }
    }
}
