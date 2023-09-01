using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Models;
using SkillQuizLight.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamSubDomainController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getSubDomainDescription/{description}")]
        public string[] getSubDomainDescription(string description)
        {
            mExamSubDomain subDomainRes = new mExamSubDomain();
            var subDomainTmp = db.tExamSubDomain
                            .Where(b => b.Description == description)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (subDomainTmp != null)
            {
                vResTab = new string[]{ subDomainTmp.tExamSubDomainID.ToString(),
                                            subDomainTmp.Description,
                                            subDomainTmp.CreatDate.ToString(),
                                            subDomainTmp.CreatUser.ToString(),
                                            subDomainTmp.ModifDate.ToString(),
                                            subDomainTmp.ModifUser.ToString() };

            }
            return vResTab;
        }

        [HttpGet("getSubDomainID/{ID}")]
        public string[] getSubDomainID(int ID)
        {
            mExamSubDomain subDomainRes = new mExamSubDomain();
            var subDomainTmp = db.tExamSubDomain
                            .Where(b => b.tExamSubDomainID == ID)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (subDomainTmp != null)
            {
                vResTab = new string[]{ subDomainTmp.tExamSubDomainID.ToString(),
                                            subDomainTmp.Description,
                                            subDomainTmp.CreatDate.ToString(),
                                            subDomainTmp.CreatUser.ToString(),
                                            subDomainTmp.ModifDate.ToString(),
                                            subDomainTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getSubDomain")]
        public List<mExamSubDomain_Display> getSubDomain()
        {
            return db.tExamSubDomain.Select(u => new mExamSubDomain_Display()
            {
                _ID = u.tExamSubDomainID,
                _Description = u.Description

            }).ToList();
        }

        [HttpPost("postSubDomain/{user}")]
        public async void postSubDomain(mExamSubDomain_Display pExamSubDomainDisplay, int user)
        {
            mExamSubDomain vExamSubDomain = new mExamSubDomain(pExamSubDomainDisplay, user);
            tExamSubDomain vSubDomainTmp = new tExamSubDomain();
            vSubDomainTmp.Description = vExamSubDomain.getDescription();
            vSubDomainTmp.CreatDate = vExamSubDomain.getCreatDate();
            vSubDomainTmp.CreatUser = vExamSubDomain.getCreatUser();
            vSubDomainTmp.ModifDate = vExamSubDomain.getModifDate();
            vSubDomainTmp.ModifUser = vExamSubDomain.getModifUser();

            db.tExamSubDomain.AddAsync(vSubDomainTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putSubDomain/{user}")]
        public async void putSubDomain(mExamSubDomain_Display pExamSubDomainDisplay, int user)
        {
            var vSubDomainTmp = db.tExamSubDomain
                        .Where(b => b.tExamSubDomainID == pExamSubDomainDisplay._ID)
                        .FirstOrDefault();
            mExamSubDomain vExamSubDomain = new mExamSubDomain(pExamSubDomainDisplay, user);
            if (vExamSubDomain.getDescription() != null) { vSubDomainTmp.Description = vExamSubDomain.getDescription(); }
            if (vExamSubDomain.getModifDate() != null) { vSubDomainTmp.ModifDate = vExamSubDomain.getModifDate(); }
            if (vExamSubDomain.getModifUser() != null) { vSubDomainTmp.ModifUser = vExamSubDomain.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delSubDomain/{ID}")]
        public void delSubDomain(Int32 ID)
        {
            var vSubDomainTmp = db.tExamSubDomain.Find(ID);
            db.tExamSubDomain.Remove(vSubDomainTmp);
            db.SaveChanges();
        }
    }
}
