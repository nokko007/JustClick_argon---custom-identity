using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JustClick.DataAccess.Repository
{
    public class IDCardTypeRepository : Repository<IDCardTypeModel>, IIDCardTypeRepository

    {

        private readonly ApplicationDbContext _db;
        public IDCardTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(IDCardTypeModel IDCardType)
        {

            var objFromDb = _db.TBL_IDCARD.FirstOrDefault(s => s.IDCARD_ID == IDCardType.IDCARD_ID);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = IDCardType.PROJECT_CODE;

                objFromDb.IDCARD_NAME = IDCardType.IDCARD_NAME;
               
            
            }

        }
    

    }
}
