using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Models;
using SkillQuizLight.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParamUserTypeController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getParamUserTypeDescription/{description}")]
        public string[] getParamUserTypeDescription(string description)
        {
            mParamUserType ParamUserType = new mParamUserType();
            var ParamUserTypeTmp = db.tParamUserType
                                    .Where(b => b.Description == description)
                                    .FirstOrDefault();
            string[] vResTab = new string[5];
            if (ParamUserTypeTmp != null)
            {
                vResTab = new string[]{ ParamUserTypeTmp.tParamUserTypeID.ToString(),
                                            ParamUserTypeTmp.Description,
                                            ParamUserTypeTmp.CreatDate.ToString(),
                                            ParamUserTypeTmp.CreatUser.ToString(),
                                            ParamUserTypeTmp.ModifDate.ToString(),
                                            ParamUserTypeTmp.ModifUser.ToString() }
                ;
            }
            return vResTab;
        }

        [HttpGet("getParamUserTypeID/{ID}")]
        public string[] getParamUserTypeID(int ID)
        {
            mParamUserType ParamUserTypeRes = new mParamUserType();
            var ParamUserTypeTmp = db.tParamUserType
                                    .Where(b => b.tParamUserTypeID == ID)
                                    .FirstOrDefault();
            string[] vResTab = new string[5];
            if (ParamUserTypeTmp != null)
            {
                vResTab = new string[]{ ParamUserTypeTmp.tParamUserTypeID.ToString(),
                                            ParamUserTypeTmp.Description,
                                            ParamUserTypeTmp.CreatDate.ToString(),
                                            ParamUserTypeTmp.CreatUser.ToString(),
                                            ParamUserTypeTmp.ModifDate.ToString(),
                                            ParamUserTypeTmp.ModifUser.ToString() };
            }
            return vResTab;
        }

        [HttpGet("getParamUserType")]
        public List<mParamUserType_Display> getParamUserType()
        {
            return db.tParamUserType.Select(u => new mParamUserType_Display()
            {
                _ID = u.tParamUserTypeID,
                _Description = u.Description

            }).ToList();
        }

        [HttpPost("postParamUserType/{user}")]
        public async void postParamUserType(mParamUserType_Display pParamUserTypeDisplay, int user)
        {
            mParamUserType vParamUserType = new mParamUserType(pParamUserTypeDisplay, user);
            tParamUserType vTabTmp = new tParamUserType();
            vTabTmp.Description = vParamUserType.getDescription();
            vTabTmp.CreatDate = vParamUserType.getCreatDate();
            vTabTmp.CreatUser = vParamUserType.getCreatUser();
            vTabTmp.ModifDate = vParamUserType.getModifDate();
            vTabTmp.ModifUser = vParamUserType.getModifUser();

            db.tParamUserType.AddAsync(vTabTmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putParamUserType/{user}")]
        public async void putParamUserType(mParamUserType_Display pParamUserTypeDisplay, int user)
        {
            var vTabTmp = db.tParamUserType
                        .Where(b => b.tParamUserTypeID == pParamUserTypeDisplay._ID)
                        .FirstOrDefault();
            mParamUserType vParamUserType = new mParamUserType(pParamUserTypeDisplay, user);
            if (vParamUserType.getDescription() != null) { vTabTmp.Description = vParamUserType.getDescription(); }
            if (vParamUserType.getModifDate() != null) { vTabTmp.ModifDate = vParamUserType.getModifDate(); }
            if (vParamUserType.getModifUser() != null) { vTabTmp.ModifUser = vParamUserType.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delParamUserType/{ID}")]
        public void delParamUserType(Int32 ID)
        {
            var vTabTmp = db.tParamUserType.Find(ID);
            db.tParamUserType.Remove(vTabTmp);
            db.SaveChanges();
        }
    }
}
