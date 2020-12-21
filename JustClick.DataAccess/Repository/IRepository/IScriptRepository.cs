using JustClick.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.DataAccess.Repository.IRepository
{
    public interface IScriptRepository : IRepository<ScriptModel>
    {

        void Update(ScriptModel Script);
    }
}
