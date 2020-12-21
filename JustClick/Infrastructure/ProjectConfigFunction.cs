
using Dapper;
using JustClick.DataAccess.Data;
using JustClick.DataAccess.Repository.IRepository;

using JustClick.Models.Identity;
using JustClick.Models.ViewModels;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JustClick.Infrastructure
{




    public  class ProjectConfigFunction : IProjectConfigFunction
    {


        private readonly IUnitOfWork _unitOfWork;
    
        public ProjectConfigFunction(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
          
        }



 

        public void Dispose()
        {
            _unitOfWork.Dispose();
            
        }



        public IEnumerable<T> SelectProjectCode<T>( )
        {
            var sqlstr = "SELECT   PROJECT_CODE " +
                        " FROM TBL_PROJECT_CONFIG  WITH(NOLOCK) ";
          
   
            IEnumerable<T> selectListItems = _unitOfWork.SQLRAW_Call.Listraw<T>(sqlstr, null);

            return (selectListItems);

        }




        public IEnumerable<T> SelectProjectConfig<T>(string project_code)
        {
            var sqlstr = "SELECT * " +
                        " FROM TBL_PROJECT_CONFIG   WITH(NOLOCK) ";

            if (project_code != null)
            {
                sqlstr = sqlstr + " WHERE  PROJECT_CODE = " + project_code;
            }

            IEnumerable<T> selectListItems = _unitOfWork.SQLRAW_Call.Listraw<T>(sqlstr, null);

            return (selectListItems);

        }


     }


}
