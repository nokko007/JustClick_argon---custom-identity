using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JustClick.DataAccess.Repository
{
    public class BankRepository : Repository<BankModel>, IBankRepository

    {

        private readonly ApplicationDbContext _db;
        public BankRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BankModel Bank)
        {

            var objFromDb = _db.TBL_BANK.FirstOrDefault(s => s.URN == Bank.URN);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = Bank.PROJECT_CODE;

                objFromDb.BANKNAME = Bank.BANKNAME;
               
            
            }

        }
    

    }
}
