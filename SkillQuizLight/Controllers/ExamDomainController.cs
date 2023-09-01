using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Models;
using SkillQuizLight.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamDomainController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getDomainDescription/{description}")]
        public string[] getDomainDescription(string description)
        {
            mExamDomain domainRes = new mExamDomain();
            var domainTmp = db.tExamDomain
                            .Where(b => b.Description == description)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (domainTmp != null)
            {
                vResTab = new string[]{ domainTmp.tExamDomainID.ToString(),
                                            domainTmp.Description,
                                            domainTmp.CreatDate.ToString(),
                                            domainTmp.CreatUser.ToString(),
                                            domainTmp.ModifDate.ToString(),
                                            domainTmp.ModifUser.ToString() }



                //domainRes.settExamDomainID(domainTmp.tExamDomainID);
                //domainRes.setDescription(domainTmp.Description);
                //domainRes.setCreatDate(domainTmp.CreatDate);
                //domainRes.setCreatUser(domainTmp.CreatUser);
                //domainRes.setModifDate(domainTmp.ModifDate);
                //domainRes.setModifUser(domainTmp.ModifUser);

                ;
            }
            //return domainRes;

            return vResTab;
        }

        [HttpGet("getDomainID/{ID}")]
        public string[] getDomainID(int ID)
        {
            mExamDomain domainRes = new mExamDomain();
            var domainTmp = db.tExamDomain
                            .Where(b => b.tExamDomainID == ID)
                            .FirstOrDefault();
            string[] vResTab = new string[5];
            if (domainTmp != null)
            {
                vResTab = new string[]{ domainTmp.tExamDomainID.ToString(),
                                            domainTmp.Description,
                                            domainTmp.CreatDate.ToString(),
                                            domainTmp.CreatUser.ToString(),
                                            domainTmp.ModifDate.ToString(),
                                            domainTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getDomain")]
        public List<mExamDomain_Display> getDomain()
        {
            return db.tExamDomain.Select(u => new mExamDomain_Display()
            {
                _ID = u.tExamDomainID,
                _Description = u.Description

            }).ToList();
        }

        [HttpPost("postDomain/{user}")]
        public async void postDomain(mExamDomain_Display pExamDomainDisplay, int user)
        {
            mExamDomain vExamDomain = new mExamDomain(pExamDomainDisplay, user);
            tExamDomain vDomainTmp = new tExamDomain();
            vDomainTmp.Description = vExamDomain.getDescription();
            vDomainTmp.CreatDate = vExamDomain.getCreatDate();
            vDomainTmp.CreatUser = vExamDomain.getCreatUser();
            vDomainTmp.ModifDate = vExamDomain.getModifDate();
            vDomainTmp.ModifUser = vExamDomain.getModifUser();

            db.tExamDomain.AddAsync(vDomainTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putDomain/{user}")]
        public async void putDomain(mExamDomain_Display pExamDomainDisplay, int user)
        {
            var vDomainTmp = db.tExamDomain
                        .Where(b => b.tExamDomainID == pExamDomainDisplay._ID)
                        .FirstOrDefault();
            mExamDomain vExamDomain = new mExamDomain(pExamDomainDisplay, user);
            if (vExamDomain.getDescription() != null) { vDomainTmp.Description = vExamDomain.getDescription(); }
            if (vExamDomain.getModifDate() != null) { vDomainTmp.ModifDate = vExamDomain.getModifDate(); }
            if (vExamDomain.getModifUser() != null) { vDomainTmp.ModifUser = vExamDomain.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delDomain/{ID}")]
        public void delDomain(Int32 ID)
        {
            var vDomainTmp = db.tExamDomain.Find(ID);
            db.tExamDomain.Remove(vDomainTmp);
            db.SaveChanges();
        }
    }
}
