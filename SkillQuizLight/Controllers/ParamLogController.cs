using Microsoft.AspNetCore.Mvc;
using SkillQuizLight.Models;
using SkillQuizLight.Context;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkillQuizLight.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParamLogController : ControllerBase
    {
        private Db_SkillQuizLight db = new Db_SkillQuizLight();

        [HttpGet("getParamLogID")]
        public List<mParamLog_Display> getParamLogID(int ptUserID, string pNameTypLog)
        {
            return (from a in db.tParamLog
                    join b in db.tParamTypeLog on a.tParamTypeLogID equals b.tParamTypeLogID
                    where b.Name == pNameTypLog && a.CreatUser == ptUserID
                    select new
                    {
                        a.tParamLogID,
                        a.tParamTypeLogID,
                        b.Name,
                        a.Info01,
                        a.Info02,
                        a.Info03
                    }
                    ).Select(u => new mParamLog_Display()
                    {
                        _ID = u.tParamLogID,
                        _tTypLogID = u.tParamTypeLogID,
                        _NameTypLog = u.Name,
                        _Info01 = u.Info01,
                        _Info02 = u.Info02,
                        _Info03 = u.Info03
                    }
                    ).ToList();
        }

        [HttpGet("getParamLog")]
        public List<mParamLog_Display> getParamLog()
        {
            return (from a in db.tParamLog
                    join b in db.tParamTypeLog on a.tParamTypeLogID equals b.tParamTypeLogID
                    select new
                    {
                        a.tParamLogID,
                        a.tParamTypeLogID,
                        b.Name,
                        a.Info01,
                        a.Info02,
                        a.Info03
                    }
                    ).Select(u => new mParamLog_Display()
                    {
                        _ID = u.tParamLogID,
                        _tTypLogID = u.tParamTypeLogID,
                        _NameTypLog = u.Name,
                        _Info01 = u.Info01,
                        _Info02 = u.Info02,
                        _Info03 = u.Info03
                    }
                    ).ToList();
        }

        [HttpGet("getTypLogID/{pName}")]
        public int[] getIsQuestOpen(string pName)
        {
            int[] vTypLogID = new int[] {0};
            var TypLogTmp = db.tParamTypeLog
                                    .Where(b => b.Name == pName)
                                    .FirstOrDefault();
            if (TypLogTmp != null)
            {
                vTypLogID[0] = TypLogTmp.tParamTypeLogID;
            }
            return vTypLogID;
        }

        [HttpPost("postParamLog/{pUser}")]
        public async void postParamLog(int pUser, mParamLog_Display pParamLog )
        {
            mParamLog vParamLog = new mParamLog(pParamLog, pUser);
            tParamLog vParamLog_Tmp = new tParamLog();
            vParamLog_Tmp.tParamTypeLogID = vParamLog.gettParamTypeLogID();
            vParamLog_Tmp.Info01 = vParamLog.getInfo01();
            vParamLog_Tmp.Info02 = vParamLog.getInfo02();
            vParamLog_Tmp.Info03 = vParamLog.getInfo03();
            vParamLog_Tmp.CreatDate = vParamLog.getCreatDate();
            vParamLog_Tmp.CreatUser = vParamLog.getCreatUser();
            vParamLog_Tmp.ModifDate = vParamLog.getModifDate();
            vParamLog_Tmp.ModifUser = vParamLog.getModifUser();

            db.tParamLog.AddAsync(vParamLog_Tmp);
            await db.SaveChangesAsync();
        }

        [HttpPut("putParamLog/{pUser}")]
        public async void putParamLog(int pUser, mParamLog_Display pParamLog)
        {
            var vParamLogTmp = db.tParamLog
                        .Where(b => b.tParamLogID == pParamLog._ID)
                        .FirstOrDefault();
            mParamLog vParamLog = new mParamLog(pParamLog, pUser);
            if (vParamLog.gettParamTypeLogID() != null) { vParamLogTmp.tParamTypeLogID = vParamLog.gettParamTypeLogID(); }
            if (vParamLog.getInfo01() != null) { vParamLogTmp.Info01 = vParamLog.getInfo01(); }
            if (vParamLog.getInfo02() != null) { vParamLogTmp.Info02 = vParamLog.getInfo02(); }
            if (vParamLog.getInfo03() != null) { vParamLogTmp.Info03 = vParamLog.getInfo03(); }
            if (vParamLog.getModifDate() != null) { vParamLogTmp.ModifDate = vParamLog.getModifDate(); }
            if (vParamLog.getModifUser() != null) { vParamLogTmp.ModifUser = vParamLog.getModifUser(); }
            db.SaveChanges();
        }

        [HttpDelete("delParamLog")]
        public void delParamLog(string pNameTypLog, int ptUserID) //
        {
            (from a in db.tParamLog
            join b in db.tParamTypeLog on a.tParamTypeLogID equals b.tParamTypeLogID
             where b.Name == pNameTypLog && a.CreatUser == ptUserID
             select a).ExecuteDelete();
        }

    }
}
