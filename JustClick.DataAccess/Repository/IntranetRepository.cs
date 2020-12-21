using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JustClick.DataAccess.Repository
{
    public class IntranetRepository : Repository<IntranetModel>, IIntranetRepository

    {

        private readonly ApplicationDbContext _db;
        public IntranetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(IntranetModel Intranet)
        {

            var objFromDb = _db.TBL_INTRANET.FirstOrDefault(s => s.INTRANET_ID == Intranet.INTRANET_ID);
            if (objFromDb != null)
            {
                objFromDb.PROJECT_CODE = Intranet.PROJECT_CODE;
                objFromDb.INTRANET_HEADER = Intranet.INTRANET_HEADER;
				objFromDb.INTRANET_URL = Intranet.INTRANET_URL;
               
            
            }

        }
    

    }
}
