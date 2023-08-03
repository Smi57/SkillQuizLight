using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Context;
using SkillQuizLight.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamDomain_SubDomainController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getDomain_SubDomainID/{ID}")]
        public string[] getDomain_SubDomainID(int ID)
        {
            mExamDomain_SubDomain domain_SubDomainRes = new mExamDomain_SubDomain();
            var domain_SubDomainTmp = db.tExamDomain_SubDomain
                            .Where(b => b.tExamDomain_SubDomainID == ID)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (domain_SubDomainTmp != null)
            {
                vResTab = new string[]{ domain_SubDomainTmp.tExamDomain_SubDomainID.ToString(),
                                            domain_SubDomainTmp.CreatDate.ToString(),
                                            domain_SubDomainTmp.CreatUser.ToString(),
                                            domain_SubDomainTmp.ModifDate.ToString(),
                                            domain_SubDomainTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getDomain_SubDomain")]
        public List<mExamDomain_SubDomain_Display> getDomain_SubDomain()
        {
            return db.tExamDomain_SubDomain.Select(u => new mExamDomain_SubDomain_Display()
            {
                tExamDomain_SubDomainID = u.tExamDomain_SubDomainID,

            }).ToList();
        }

        [HttpPost("postDomain_SubDomain/{user}")]
        public async void postDomain_SubDomain(mExamDomain_SubDomain_Display pExamDomain_SubDomainDisplay, int user)
        {
            mExamDomain_SubDomain vExamDomain_SubDomain = new mExamDomain_SubDomain(pExamDomain_SubDomainDisplay, user);
            tExamDomain_SubDomain vDomain_SubDomainTmp = new tExamDomain_SubDomain();
            vDomain_SubDomainTmp.CreatDate = vExamDomain_SubDomain.getCreatDate();
            vDomain_SubDomainTmp.CreatUser = vExamDomain_SubDomain.getCreatUser();
            vDomain_SubDomainTmp.ModifDate = vExamDomain_SubDomain.getModifDate();
            vDomain_SubDomainTmp.ModifUser = vExamDomain_SubDomain.getModifUser();

            db.tExamDomain_SubDomain.AddAsync(vDomain_SubDomainTmp);
            await db.SaveChangesAsync();
        }

        [HttpDelete("delDomain_SubDomain/{ID}")]
        public void delDomain_SubDomain(Int32 ID)
        {
            var vDomain_SubDomainTmp = db.tExamDomain_SubDomain.Find(ID);
            db.tExamDomain_SubDomain.Remove(vDomain_SubDomainTmp);
            db.SaveChanges();
        }
    }
}
