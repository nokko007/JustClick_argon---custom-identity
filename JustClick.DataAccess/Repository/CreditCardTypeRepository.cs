using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JustClick.DataAccess.Repository
{
    public class CreditCardTypeRepository : Repository<CreditCardTypeModel>, ICreditCardTypeRepository

    {

        private readonly ApplicationDbContext _db;
        public CreditCardTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CreditCardTypeModel creditCardType)
        {

            var objFromDb = _db.TBL_CARDTYPE.FirstOrDefault(s => s.CARDCODE == creditCardType.CARDCODE);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = creditCardType.PROJECT_CODE;

                objFromDb.CARDTYPE = creditCardType.CARDTYPE;
               
            
            }

        }
    

    }
}
