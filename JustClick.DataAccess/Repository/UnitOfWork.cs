using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository;
using JustClick.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
    public class UnitOfWork : IUnitOfWork
    {


        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            CreditCardType = new CreditCardTypeRepository(_db);
            Nontarget = new NonTargetRepository(_db);
            ProjectConfig = new ProjectConfigRepository(_db);
            Title = new TitleRepository(_db);
      
        SP_Call = new SP_Call(_db);
        }
    public IApplicationUserRepository ApplicationUser { get; private set; }
    public ICreditCardTypeRepository  CreditCardType { get; private set; }
 
        public IProjectConfigRepository  ProjectConfig { get; private set; }
        public ITitleRepository  Title{ get; private set; }

        public ISP_Call SP_Call { get; private set; }
        public ISQLRAW_Call SQLRAW_Call { get; private set; }

    //call statud
       public INontargetRepository  Nontarget { get; private set; }
        public IRefuseRepository Refuse { get; private set; }

    public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }

