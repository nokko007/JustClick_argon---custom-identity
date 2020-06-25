using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork :IDisposable
    {
        ICreditCardTypeRepository CreditCardType { get; }
      
        IProjectConfigRepository  ProjectConfig { get; }
        ITitleRepository  Title { get; }

        ISP_Call SP_Call { get; }
        IApplicationUserRepository ApplicationUser { get; }


        ISQLRAW_Call SQLRAW_Call { get; }

  INontargetRepository  Nontarget { get; }
        IRefuseRepository Refuse { get; }
        void Save();
    }
}
