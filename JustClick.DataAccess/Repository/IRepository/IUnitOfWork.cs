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

      
        IApplicationUserRepository ApplicationUser { get; }
  ISP_Call SP_Call { get; }

        ISQLRAW_Call SQLRAW_Call { get; }

  
        INontargetRepository  Nontarget { get; }
        IRefuseRepository Refuse { get; }

        ISuccessRepository Success { get; }

        ICallbackRepository Callback { get; }

        IFailRepository Fail { get; }

        IIDCardTypeRepository IDCardType { get; }

        IBankRepository Bank { get; }
        IScriptRepository Script { get; }
        IIntranetRepository Intranet { get; }


        void Save();
    }
}
