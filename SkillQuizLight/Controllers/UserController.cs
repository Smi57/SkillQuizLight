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

        [HttpGet("getUserLogin/{LOGIN}")]
        public User getUserLogin(string login)
        {
            User userRes = new User();
            var userTmp = db.tUser
                            .Where(b => b.Login == login)
                            .FirstOrDefault();
            if (userTmp != null)
            { 
                userRes.tUserID = userTmp.tUserID;
                userRes.Login = userTmp.Login;
                userRes.PasswordEncrypted = userTmp.Password;
                userRes.AccessFailedCount = userTmp.AccessFailedCount;
            }
            return userRes;
        }

        [HttpGet("getUserID/{ID}")]
        public UserDisplay getUserID(Int32 ID)
        {
            UserDisplay userRes = new UserDisplay();
            var userTmp = db.tUser
                                    .Where(b => b.tUserID == ID)
                                    .FirstOrDefault();
            if (userTmp != null)
            {
                userRes.tUserID = userTmp.tUserID;
                userRes.tUserID = userTmp.tUserID;
                userRes.FirstName = userTmp.FirstName;
                userRes.LastName = userTmp.LastName;
                userRes.Email = userTmp.Email;
                userRes.Comment = userTmp.Comment;
            }
            return userRes;
        }

        [HttpGet("getUser")]
        public List<UserDisplay> getUser()
        {
            return db.tUser.Select(u => new UserDisplay()
            {
                tUserID = u.tUserID,
                Login = u.Login,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Comment = u.Comment
            }).ToList();
        }

        [HttpPost("postUser")]
        public async void postUser(User userParam)
        {
            tUser userTmp = new tUser();
            userTmp.Login = userParam.Login;
            userTmp.FirstName = userParam.FirstName;
            userTmp.LastName = userParam.LastName;
            userTmp.Email = userParam.Email;
            userTmp.Comment = userParam.Comment;
            userTmp.Password = userParam.getPassword();
            userTmp.IsActivate = true;
            userTmp.ParamUserTypeID = 0;

            db.tUser.AddAsync(userTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putUser")]
        public async void putUser(User userParam)
        {
            var user = db.tUser
                        .Where(b => b.tUserID == Convert.ToInt32(userParam.tUserID))
                        .FirstOrDefault();
            if (userParam.Login != null) { user.Login = userParam.Login; }
            if (userParam.FirstName != null) { user.FirstName = userParam.FirstName; }
            if (userParam.LastName != null) { user.LastName = userParam.LastName; }
            if (userParam.Email != null) { user.Email = userParam.Email; }
            if (userParam.Comment != null) { user.Comment = userParam.Comment; }
            if (userParam.AccessFailedCount != null) { user.AccessFailedCount = userParam.AccessFailedCount; }
            db.SaveChanges();
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
