using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JustClick.DataAccess.Repository
{
    public class ScriptRepository : Repository<ScriptModel>, IScriptRepository

    {

        private readonly ApplicationDbContext _db;
        public ScriptRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ScriptModel Script)
        {

            var objFromDb = _db.TBL_SCRIPT.FirstOrDefault(s => s.SCRIPTID == Script.SCRIPTID);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = Script.PROJECT_CODE;
                objFromDb.SCRIPTHEADER = Script.SCRIPTHEADER;
				objFromDb.SCRIPTDESC = Script.SCRIPTDESC;
               
            
            }

        }
    

    }
}
