using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsrController : ControllerBase
    {
        private LocalSkillQuizDbSebContext db = new LocalSkillQuizDbSebContext();
        // GET: api/<UsrController>
        [HttpGet]
        public IQueryable<Usr> GetUsr()
        {
            return db.Usrs;
            //return db.Usrs;
        }
    }
}
