using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.DataAccess.Repository.IRepository
{
    public interface IBankRepository : IRepository<BankModel>
    {

        void Update(BankModel Bank);
    }
}
