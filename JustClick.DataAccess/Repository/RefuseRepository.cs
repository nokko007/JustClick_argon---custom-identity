using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustClick.DataAccess.Repository
{
   public class RefuseRepository : RepositoryAsync<RefuseModel>,IRefuseRepository
    {


        private readonly ApplicationDbContext _db;
        public RefuseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(RefuseModel Refuse)
        {

            var objFromDb = _db.TBL_REFUSE.FirstOrDefault(s => s.RefuseCODE == Refuse.RefuseCODE);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = Refuse.PROJECT_CODE;

                objFromDb.RefuseREASON = Refuse.RefuseREASON;


            }

        }


    }


}
