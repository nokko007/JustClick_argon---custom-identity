using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.DataAccess.Repository.IRepository
{
    public interface ISuccessRepository : IRepositoryAsync<SuccessModel>
    {
        void Update(SuccessModel Success);

    }
}
