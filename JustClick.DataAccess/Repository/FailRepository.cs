using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustClick.DataAccess.Repository
{
   public class FailRepository : RepositoryAsync<FailModel>,IFailRepository
    {


        private readonly ApplicationDbContext _db;
        public FailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(FailModel Fail)
        {

            var objFromDb = _db.TBL_FAIL.FirstOrDefault(s => s.FAILCODE == Fail.FAILCODE);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = Fail.PROJECT_CODE;

                objFromDb.FAILREASON = Fail.FAILREASON;
                objFromDb.NEEDTERMINATE = Fail.NEEDTERMINATE;


            }

        }


    }


}
