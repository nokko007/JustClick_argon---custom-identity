using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace JustClick.DataAccess.Repository
{
   public class TitleRepository : Repository<TitleModel>, ITitleRepository
    {


        private readonly ApplicationDbContext _db;
        public TitleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(TitleModel title)
        {


        }


    }


}
