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
    public class SQLRAW_Call : ISQLRAW_Call


    {


        private readonly ApplicationDbContext _db;
        private static string Connectionstring = "";

        public SQLRAW_Call(ApplicationDbContext db)
        {
            _db = db;
            Connectionstring = db.Database.GetDbConnection().ConnectionString;
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string sqlstr, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                sqlcon.Execute(sqlstr, param);
            }
        }

        


        public IEnumerable<T> Listraw<T>(string sqlstr, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                //return sqlcon.Query<T>().FromSql(sql, parameters).ToList();
                return sqlcon.Query<T>(sqlstr, param);
            }
        }

        
    }
}
