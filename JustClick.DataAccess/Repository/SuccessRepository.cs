using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustClick.DataAccess.Repository
{
   public class SuccessRepository : RepositoryAsync<SuccessModel>,ISuccessRepository
    {


        private readonly ApplicationDbContext _db;
        public SuccessRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(SuccessModel Success)
        {

            var objFromDb = _db.TBL_SUCCESS.FirstOrDefault(s => s.SUCCESSCODE == Success.SUCCESSCODE);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = Success.PROJECT_CODE;

                objFromDb.SUCCESSREASON = Success.SUCCESSREASON;


            }

        }


    }


}
