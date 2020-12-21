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
            ProjectConfig = new ProjectConfigRepository(_db);
            Title = new TitleRepository(_db);
            SP_Call = new SP_Call(_db);
            SQLRAW_Call= new SQLRAW_Call(_db);
            Nontarget = new NonTargetRepository(_db);
            Refuse = new RefuseRepository(_db);
            Success = new SuccessRepository(_db);
            Callback = new CallbackRepository(_db);
            Fail = new FailRepository(_db);
            IDCardType = new IDCardTypeRepository(_db);
            Bank = new BankRepository(_db);
            Script = new ScriptRepository(_db);
            Intranet = new IntranetRepository(_db);



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

        public ISuccessRepository Success { get; private set; }

        public ICallbackRepository Callback { get; private set; }

        public IFailRepository Fail { get; private set; }

        public IIDCardTypeRepository IDCardType { get; private set; }

        public IBankRepository Bank { get; private set; }

         public IScriptRepository Script { get; private set; }

        public IIntranetRepository Intranet { get; private set; }


    public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }

