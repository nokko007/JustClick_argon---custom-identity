using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustClick.DataAccess.Repository
{
   public class NonTargetRepository : RepositoryAsync<NonTargetModel>,INontargetRepository
    {


        private readonly ApplicationDbContext _db;
        public NonTargetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(NonTargetModel Nontarget)
        {

            var objFromDb = _db.TBL_NONTARGET.FirstOrDefault(s => s.NONTARGETCODE == Nontarget.NONTARGETCODE);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = Nontarget.PROJECT_CODE;

                objFromDb.NONTARGETREASON = Nontarget.NONTARGETREASON;


            }

        }


    }


}
