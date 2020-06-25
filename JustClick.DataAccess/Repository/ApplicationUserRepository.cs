using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using JustClick.Models;
using JustClick.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JustClick.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository

    {

        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

    }
}
