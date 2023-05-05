using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillQuizLight.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsrController : ControllerBase
    {
        private LocalSkillQuizDbSebContext db = new LocalSkillQuizDbSebContext();
        // GET: api/<UsrController>
        [HttpGet]
        [Route("getUsr")]
        public IQueryable<Usr> getUsr()
        {
            return db.Usrs;
        }
        [HttpPost]
        [Route("postUsr")]
        public async void postUsr(UsrToShow usrParam)
        {
            Usr usrTmp = new Usr();
            usrTmp.LoginTxt = usrParam.LoginTxt;
            usrTmp.FirstName = usrParam.FirstName;
            usrTmp.LastName = usrParam.LastName;
            usrTmp.Email = usrParam.Email;
            usrTmp.Comment = usrParam.Comment;
            usrTmp.Passwordtxt = "";
            usrTmp.IsActive = 0;
            usrTmp.TypeUserId = 0;

            db.Usrs.AddAsync(usrTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut]
        [Route("putUsr")]
        public async void putUsr(UsrToShow usrParam)
        {
            Usr usrTmp = new Usr();
            usrTmp.LoginId = usrParam.LoginId;
            usrTmp.LoginTxt = usrParam.LoginTxt;
            usrTmp.FirstName = usrParam.FirstName;
            usrTmp.LastName = usrParam.LastName;
            usrTmp.Email = usrParam.Email;
            usrTmp.Comment = usrParam.Comment;

            db.Usrs.Update(usrTmp) ;
            await db.SaveChangesAsync();
        }

        [HttpDelete]
        [Route("delUsr/{ID}")]
        public async void delUsr(Int32 ID)
        {
            var usrTmp = await db.Usrs.FindAsync(ID);
            db.Usrs.Remove(usrTmp);
            await db.SaveChangesAsync();
        }
    }
    
}
