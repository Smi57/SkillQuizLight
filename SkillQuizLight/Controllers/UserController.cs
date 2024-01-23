using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillQuizLight.Models;
using SkillQuizLight.Context;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getUserLogin/{login}")]
        public mUser getUserLogin(string login)
        {
            mUser userRes = new mUser();
            var userTmp = db.tUser
                            .Where(b => b.Login == login)
                            .FirstOrDefault();
            if (userTmp != null)
            { 
                userRes.tUserID = userTmp.tUserID;
                userRes.Login = userTmp.Login;
                userRes.PasswordEncrypted = userTmp.Password;
                userRes.AccessFailedCount = userTmp.AccessFailedCount;
                userRes.tParamLangID = userTmp.tParamLangID;
                userRes.tParamUserTypeID = userTmp.tParamUserTypeID;
            }
            return userRes;
        }

        [HttpGet("getUserID/{ID}")]
        public mUser_Display getUserID(Int32 ID)
        {
            mUser_Display userRes = new mUser_Display();
            var userTmp = db.tUser
                                    .Where(b => b.tUserID == ID)
                                    .FirstOrDefault();
            if (userTmp != null)
            {
                userRes._ID = userTmp.tUserID;
                userRes._Login = userTmp.Login;
                userRes._First_Name = userTmp.FirstName;
                userRes._Last_Name = userTmp.LastName;
                userRes._Email = userTmp.Email;
                userRes._Comment = userTmp.Comment;
                userRes._ID_Lang = userTmp.tParamLangID;
                userRes._ID_Type = userTmp.tParamUserTypeID;
            }
            return userRes;
        }

        [HttpGet("getUser")]
        public List<mUser_Display> getUser()
        {
            return db.tUser.Select(u => new mUser_Display()
            {
                _ID = u.tUserID,
                _Login = u.Login,
                _First_Name = u.FirstName,
                _Last_Name = u.LastName,
                _Email = u.Email,
                _Comment = u.Comment,
                _ID_Lang = u.tParamLangID,
                _ID_Type = u.tParamUserTypeID,
                _Access_Failed_Count = u.AccessFailedCount
            }).ToList();
        }

        [HttpGet("getIsQuestOpen/{pUserID}")]
        public bool[] getIsQuestOpen(Int32 pUserID)
        {
            bool[] vIsQuestOpen = new bool[] { false };
            var userTmp = db.tUser
                                    .Where(b => b.tUserID == pUserID)
                                    .FirstOrDefault();
            if (userTmp != null)
            {
                vIsQuestOpen[0] = userTmp.IsQuestOpen;
            }
            return vIsQuestOpen;
        }

        [HttpPost("postUser")]
        public async void postUser(mUser userParam)
        {
            tUser userTmp = new tUser();
            userTmp.Login = userParam.Login;
            userTmp.FirstName = userParam.FirstName;
            userTmp.LastName = userParam.LastName;
            userTmp.Email = userParam.Email;
            userTmp.Comment = userParam.Comment;
            userTmp.Password = userParam.getPassword();
            userTmp.IsActivate = userParam.IsActivate;
            userTmp.tParamUserTypeID = userParam.tParamUserTypeID;
            userTmp.AccessFailedCount = userParam.AccessFailedCount;
            userTmp.tParamLangID = userParam.tParamLangID;
            userTmp.tParamUserTypeID = userParam.tParamUserTypeID;
            userTmp.IsActivate = userParam.IsActivate;
            userTmp.CreatDate = userParam.CreatDate;
            userTmp.CreatUserID = userParam.CreatUserID;
            userTmp.ModifDate = userParam.ModifDate;
            userTmp.ModifUserID = userParam.ModifUserID;

            db.tUser.AddAsync(userTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putUser")]
        public async void putUser(mUser userParam)
        {
            var user = db.tUser
                        .Where(b => b.tUserID == Convert.ToInt32(userParam.tUserID))
                        .FirstOrDefault();
            if (userParam.Login != null) { user.Login = userParam.Login; }
            if (userParam.FirstName != null) { user.FirstName = userParam.FirstName; }
            if (userParam.LastName != null) { user.LastName = userParam.LastName; }
            if (userParam.Email != null) { user.Email = userParam.Email; }
            if (userParam.Comment != null) { user.Comment = userParam.Comment; }
            if (userParam.tParamLangID != null) { user.tParamLangID = userParam.tParamLangID; }
            if (userParam.tParamUserTypeID != null) { user.tParamUserTypeID = userParam.tParamUserTypeID; }
            if (userParam.AccessFailedCount != null) { user.AccessFailedCount = userParam.AccessFailedCount; }
            db.SaveChanges();
        }

        [HttpPut("putUserPassword/{pOldPassword}")]
        public async void putUserPassword(mUser userParam, string pOldPassword)
        {
            var user = db.tUser
                        .Where(b => b.tUserID == Convert.ToInt32(userParam.tUserID))
                        .FirstOrDefault();
            if (userParam.PasswordEncrypted != null && userParam.PasswordEncrypted != pOldPassword)
            {
                user.Password = userParam.PasswordEncrypted;
            }
            db.SaveChanges();
        }

        [HttpPut("putIsQuestOpenTrue/{pId}")]
        public async void putIsQuestOpenTrue(int pId)
        {
            var user = db.tUser
                        .Where(b => b.tUserID == Convert.ToInt32(pId))
                        .FirstOrDefault();
            if (user != null)
            {
                user.IsQuestOpen = true;
                db.SaveChanges();
            }

        }

        [HttpPut("putIsQuestOpenFalse/{pId}")]
        public async void putIsQuestOpenFalse(int pId)
        {
            var user = db.tUser
                        .Where(b => b.tUserID == Convert.ToInt32(pId))
                        .FirstOrDefault();
            if (user != null)
            {
                user.IsQuestOpen = true;
                db.SaveChanges();
            }

        }
        [HttpDelete("delUser/{ID}")]
        public void delUser(Int32 ID)
        {
            var userTmp = db.tUser.Find(ID);
            db.tUser.Remove(userTmp);
            db.SaveChanges();
        }

    }
}
