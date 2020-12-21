using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.DataAccess.Repository.IRepository
{
    public interface IIDCardTypeRepository : IRepository<IDCardTypeModel>
    {

        void Update(IDCardTypeModel IDCardType);
    }
}
