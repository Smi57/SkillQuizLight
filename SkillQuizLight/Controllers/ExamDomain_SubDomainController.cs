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

        [HttpGet("getDomain_SubDomainIDs")]
        public bool getDomain_SubDomainIDs(int pExamDomainID, int pExamSubDomainID)
        {
            mExamDomain_SubDomain domain_SubDomainRes = new mExamDomain_SubDomain();
            var domain_SubDomainTmp = db.tExamDomain_SubDomain
                            .Where(b => b.tExamDomainID == pExamDomainID &&
                                        b.tExamSubDomainID == pExamSubDomainID)
                            .FirstOrDefault();
            bool vResFind = false;
            if (domain_SubDomainTmp != null)
            {
                vResFind = true;
            }
            return vResFind;
        }

        [HttpGet("getDomain_SubDomain")]
        public List<mExamDomain_SubDomain_Display> getDomain_SubDomain()
        {


            return (from a in db.tExamDomain_SubDomain
                         join b in db.tExamDomain on a.tExamDomainID equals b.tExamDomainID
                         join c in db.tExamSubDomain on a.tExamSubDomainID equals c.tExamSubDomainID
                         select new { a.tExamDomain_SubDomainID, a.tExamDomainID, a.tExamSubDomainID,
                             a.CreatDate,
                             a.CreatUser,
                             a.ModifDate,
                             a.ModifUser,
                             b.Description,
                             Desc2=c.Description
                         }).Select(u => new mExamDomain_SubDomain_Display()
                         {
                             _ID = u.tExamDomain_SubDomainID,
                             _Domain = u.Description,
                             _ID_Domain = u.tExamDomainID,
                             _ID_Sub_Domain = u.tExamSubDomainID,
                             _Sub_Domain = u.Desc2
                         }).ToList();
        }

        [HttpPost("postDomain_SubDomain/{user}")]
        public async void postDomain_SubDomain(mExamDomain_SubDomain_Display pExamDomain_SubDomainDisplay, int user)
        {
            mExamDomain_SubDomain vExamDomain_SubDomain = new mExamDomain_SubDomain(pExamDomain_SubDomainDisplay, user);
            tExamDomain_SubDomain vDomain_SubDomainTmp = new tExamDomain_SubDomain();
            vDomain_SubDomainTmp.tExamDomainID = vExamDomain_SubDomain.gettExamDomainID();
            vDomain_SubDomainTmp.tExamSubDomainID = vExamDomain_SubDomain.gettExamSubDomainID();
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
