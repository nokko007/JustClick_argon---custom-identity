using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace JustClick.DataAccess.Repository.IRepository
{
   public interface ISQLRAW_Call : IDisposable
    {
        //T Single<T>(string procedureName, DynamicParameters param = null);

        void Execute(string sqlstr, DynamicParameters param = null);

        //T OneRecord<T>(string procedureName, DynamicParameters param = null);

        //IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null);

        //Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null);

        IEnumerable<T> Listraw<T>(string sqlstr, DynamicParameters param = null);
    }
}
