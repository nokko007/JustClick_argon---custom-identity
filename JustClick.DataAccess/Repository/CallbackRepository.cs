using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustClick.DataAccess.Repository
{
   public class CallbackRepository : RepositoryAsync<CallbackModel>,ICallbackRepository
    {


        private readonly ApplicationDbContext _db;
        public CallbackRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CallbackModel Callback)
        {

            var objFromDb = _db.TBL_CALLBACK.FirstOrDefault(s => s.CALLBACKCODE == Callback.CALLBACKCODE);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = Callback.PROJECT_CODE;

                objFromDb.CALLBACKREASON = Callback.CALLBACKREASON;
                objFromDb.NEEDTERMINATE = Callback.NEEDTERMINATE;


            }

        }


    }


}
