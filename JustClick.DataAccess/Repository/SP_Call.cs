using Dapper;
using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustClick.DataAccess.Repository
{
    public class SP_Call : ISP_Call


    {


        private readonly ApplicationDbContext _db;
        private static string Connectionstring = "";

        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            Connectionstring = db.Database.GetDbConnection().ConnectionString;
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                sqlcon.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
               return  sqlcon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                var result = SqlMapper.QueryMultiple(sqlcon, procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();


                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }

            }

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }
        

        public T OneRecord<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(Connectionstring))
            {
                sqlCon.Open();
                var value = sqlCon.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        public T Single<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(Connectionstring))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }




        public IEnumerable<T> Listraw<T>(string sqlstr, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                return sqlcon.Query<T>(sqlstr, param);
            }
        }


    }
}
